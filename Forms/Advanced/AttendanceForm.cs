using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new string[] { "Present", "Absent", "Late" });
            cmbStatus.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            dtpCheckIn.Value = DateTime.Today.AddHours(9);
            dtpCheckOut.Value = DateTime.Today.AddHours(17);
            LoadAttendance();
            LoadAnalytics();
        }

        private async void LoadAttendance()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                string filter = txtFilterID.Text.Trim();
                
                var query = db.Attendances.AsQueryable();
                if (!string.IsNullOrEmpty(filter))
                    query = System.Linq.Queryable.Where(query, a => a.EmployeeId == filter);
                    
                var results = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.OrderByDescending(query, a => a.AttendanceId));
                    
                dgvAttendance.DataSource = results;
                ColorRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                row.DefaultCellStyle.BackColor = status switch
                {
                    "Present" => Color.FromArgb(198, 239, 206),
                    "Absent" => Color.FromArgb(255, 199, 206),
                    "Late" => Color.FromArgb(255, 235, 156),
                    _ => Color.White
                };
            }
        }

        private async void LoadAnalytics()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                string month = DateTime.Today.ToString("MM"), year = DateTime.Today.ToString("yyyy");
                string prefix = $"{year}-{month}";
                
                var stats = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.GroupBy(
                            System.Linq.Queryable.Where(db.Attendances, a => a.Date != null && a.Date.StartsWith(prefix)),
                            a => a.Status
                        ),
                        g => new { Status = g.Key, Cnt = System.Linq.Enumerable.Count(g) }
                    )
                );

                int present = 0, absent = 0, late = 0;
                foreach (var s in stats)
                {
                    switch (s.Status)
                    {
                        case "Present": present = s.Cnt; break;
                        case "Absent": absent = s.Cnt; break;
                        case "Late": late = s.Cnt; break;
                    }
                }

                lblPresent.Text = $"? Present: {present}";
                lblAbsent.Text = $"? Absent: {absent}";
                lblLate.Text = $"?? Late: {late}";
                int total = present + absent + late;
                lblRate.Text = total > 0 ? $"?? Attendance Rate: {(present * 100 / total)}%" : "?? Attendance Rate: N/A";
            }
            catch { }
        }

        private async void btnMark_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text))
            {
                MessageBox.Show("Please enter Employee ID.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var newAtt = new Employeemanagment.Data.Models.Attendance
                {
                    EmployeeId = txtEmpID.Text.Trim(),
                    Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                    CheckIn = dtpCheckIn.Value.ToString("HH:mm"),
                    CheckOut = dtpCheckOut.Value.ToString("HH:mm"),
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Present"
                };
                
                db.Attendances.Add(newAtt);
                await db.SaveChangesAsync();
                
                MessageBox.Show("Attendance marked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpID.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadAttendance(); LoadAnalytics(); }
        }

        private void btnLoad_Click(object sender, EventArgs e) => LoadAttendance();
        private void btnClear_Click(object sender, EventArgs e) { txtFilterID.Clear(); LoadAttendance(); }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var a = new MainDashboard();
            a.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}

