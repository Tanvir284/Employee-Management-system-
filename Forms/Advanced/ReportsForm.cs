using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class ReportsForm : Form
    {

        public ReportsForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            this.BackColor = UITheme.BackDark;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            UITheme.StyleDataGrid(dgvPreview);
            foreach (Button b in new[] { btnEmployee, btnAttendance, btnPayroll, btnLeave, btnPerformance })
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 1;
                b.Cursor = Cursors.Hand;
                b.Font = UITheme.FontBold;
            }
            btnEmployee.FlatAppearance.BorderColor    = UITheme.Accent;
            btnEmployee.ForeColor    = UITheme.Accent;    btnEmployee.BackColor    = UITheme.NavActive;
            btnAttendance.FlatAppearance.BorderColor  = UITheme.Success;
            btnAttendance.ForeColor  = UITheme.Success;   btnAttendance.BackColor  = UITheme.NavActive;
            btnPayroll.FlatAppearance.BorderColor     = UITheme.Gold;
            btnPayroll.ForeColor     = UITheme.Gold;      btnPayroll.BackColor     = UITheme.NavActive;
            btnLeave.FlatAppearance.BorderColor       = UITheme.Warning;
            btnLeave.ForeColor       = UITheme.Warning;   btnLeave.BackColor       = UITheme.NavActive;
            btnPerformance.FlatAppearance.BorderColor = UITheme.Purple;
            btnPerformance.ForeColor = UITheme.Purple;    btnPerformance.BackColor = UITheme.NavActive;
            UITheme.StyleFlatButton(btnExport, UITheme.Gold);
            UITheme.StyleFlatButton(btnBack, UITheme.TextSecondary);
        }

        private void LoadPreview<T>(System.Collections.Generic.IEnumerable<T> data, string title)
        {
            try
            {
                dgvPreview.DataSource = new System.ComponentModel.BindingList<T>(System.Linq.Enumerable.ToList(data));
                int count = dgvPreview.Rows.Count;
                lblPreviewTitle.Text = $"Preview: {title}  ({count} rows)";
                _currentTitle = title;
                btnExport.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string _currentTitle = "";

        private async void btnEmployee_Click(object s, EventArgs e)
        {
            using var db = new Employeemanagment.Data.EmployeeDbContext();
            var data = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                System.Linq.Queryable.OrderBy(db.Employees, emp => emp.Id));
            LoadPreview(data, "Employee Report");
        }
        
        private async void btnAttendance_Click(object s, EventArgs e)
        {
            using var db = new Employeemanagment.Data.EmployeeDbContext();
            var data = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                System.Linq.Queryable.OrderByDescending(db.Attendances, a => a.AttendanceId));
            LoadPreview(data, "Attendance Report");
        }

        private async void btnPayroll_Click(object s, EventArgs e)
        {
            using var db = new Employeemanagment.Data.EmployeeDbContext();
            var data = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                System.Linq.Queryable.OrderByDescending(db.PayrollForecasts, f => f.ForecastId));
            LoadPreview(data, "Payroll Forecast Report");
        }
        
        private async void btnLeave_Click(object s, EventArgs e)
        {
            using var db = new Employeemanagment.Data.EmployeeDbContext();
            var data = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                System.Linq.Queryable.OrderByDescending(db.LeaveRequests, l => l.LeaveId));
            LoadPreview(data, "Leave Report");
        }
        
        private async void btnPerformance_Click(object s, EventArgs e)
        {
            using var db = new Employeemanagment.Data.EmployeeDbContext();
            var data = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                System.Linq.Queryable.OrderByDescending(db.PerformanceReviews, p => p.ReviewId));
            LoadPreview(data, "Performance Report");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPreview.DataSource == null) { MessageBox.Show("Load a report first."); return; }
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV File|*.csv",
                FileName = $"{_currentTitle.Replace(" ", "_")}_{DateTime.Today:yyyyMMdd}.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var sw = new StreamWriter(sfd.FileName);
                // Header
                var headers = new System.Collections.Generic.List<string>();
                foreach (DataGridViewColumn col in dgvPreview.Columns) headers.Add(col.HeaderText);
                sw.WriteLine(string.Join(",", headers));
                // Rows
                foreach (DataGridViewRow row in dgvPreview.Rows)
                {
                    if (row.IsNewRow) continue;
                    var vals = new System.Collections.Generic.List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                        vals.Add($"\"{cell.Value?.ToString()?.Replace("\"", "\"\"") ?? ""}\"");
                    sw.WriteLine(string.Join(",", vals));
                }
                MessageBox.Show($"✅ Exported {dgvPreview.Rows.Count} rows to:\n{sfd.FileName}",
                    "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show($"Export failed: {ex.Message}"); }
        }

        private void btnBack_Click(object s, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
    }
}
