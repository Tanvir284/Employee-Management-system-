using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class EmployeePanel : Form
    {
        private readonly string _empId;
        private readonly string _empName;
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        public EmployeePanel(string empId, string empName)
        {
            _empId   = empId;
            _empName = empName;
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void EmployeePanel_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"👤  Welcome, {_empName}  (ID: {_empId})";

            // ── Fix: Restore header gradient + reposition Logout ─────────────
            // ApplyThemeToForm overwrites the header BackColor; repaint it here.
            panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Paint -= OnHeaderPaint;   // remove any previous handler
            panelHeader.Paint += OnHeaderPaint;

            // Re-anchor Logout now that panelHeader has its real Width
            RepositionLogout();
            Resize += (s, _) => RepositionLogout();

            // ── Style Logout button explicitly (ApplyTheme may have overridden) ──
            btnLogout.BackColor = Color.Transparent;
            btnLogout.ForeColor = Color.White;
            btnLogout.Font      = UITheme.FontBold;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderColor = Color.White;
            btnLogout.FlatAppearance.BorderSize  = 1;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);

            LoadProfile();
            LoadMyAttendance();
            LoadMyLeaves();
            LoadMyPayslips();
            LoadMyPerformance();
        }

        private void OnHeaderPaint(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (sender is Panel p && p.Width > 0 && p.Height > 0)
                UITheme.PaintGradientHeader(e, new Rectangle(0, 0, p.Width, p.Height));
        }

        private void RepositionLogout()
        {
            btnLogout.Anchor   = AnchorStyles.None;   // temporarily remove anchor
            btnLogout.Location = new Point(panelHeader.Width - btnLogout.Width - 15,
                                           (panelHeader.Height - btnLogout.Height) / 2);
            btnLogout.Anchor   = AnchorStyles.Top | AnchorStyles.Right;   // re-set with correct margins
        }

        // ── Profile ────────────────────────────────────────────────────────────
        private void LoadProfile()
        {
            try
            {
                Con.Open();
                using var cmd = new SqlCommand(
                    "SELECT name, age, email, salary, num, shift, gender, joindate FROM employee WHERE ID=@id", Con);
                cmd.Parameters.AddWithValue("@id", _empId);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    lblName.Text     = $"Name:       {r["name"]}";
                    lblAge.Text      = $"Age:        {r["age"]}";
                    lblEmail.Text    = $"Email:      {r["email"]}";
                    lblSalary.Text   = $"Salary:     ${r["salary"]}";
                    lblPhone.Text    = $"Phone:      {r["num"]}";
                    lblShift.Text    = $"Shift:      {r["shift"]}";
                    lblGender.Text   = $"Gender:     {r["gender"]}";
                    lblJoin.Text     = $"Joined:     {r["joindate"]}";
                }
                else
                {
                    lblName.Text = "Profile not found in employee records.";
                }
            }
            catch (Exception ex) { lblName.Text = $"Error: {ex.Message}"; }
            finally { Con.Close(); }
        }

        // ── Attendance ─────────────────────────────────────────────────────────
        private void LoadMyAttendance()
        {
            try
            {
                Con.Open();
                var sda = new SqlDataAdapter(
                    "SELECT Date,CheckIn,CheckOut,Status FROM attendance WHERE EmployeeID=@id ORDER BY AttendanceId DESC",
                    Con);
                sda.SelectCommand.Parameters.AddWithValue("@id", _empId);
                var dt = new DataTable(); sda.Fill(dt);
                dgvAttendance.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Con.Close(); }
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                // Check if already marked
                using var chk = new SqlCommand(
                    "SELECT COUNT(*) FROM attendance WHERE EmployeeID=@id AND Date=@d", Con);
                chk.Parameters.AddWithValue("@id", _empId);
                chk.Parameters.AddWithValue("@d",  today);
                if ((int)chk.ExecuteScalar() > 0)
                { MessageBox.Show("Attendance already marked for today.", "Info"); return; }

                using var cmd = new SqlCommand(
                    "INSERT INTO attendance (EmployeeID,Date,CheckIn,Status) VALUES (@id,@d,@ci,'Present')", Con);
                cmd.Parameters.AddWithValue("@id", _empId);
                cmd.Parameters.AddWithValue("@d",  today);
                cmd.Parameters.AddWithValue("@ci", DateTime.Now.ToString("HH:mm"));
                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Attendance marked as Present for today!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Con.Close(); LoadMyAttendance(); }
        }

        // ── Leave ──────────────────────────────────────────────────────────────
        private async void LoadMyLeaves()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var leaves = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.OrderByDescending(
                            System.Linq.Queryable.Where(db.LeaveRequests, l => l.EmployeeId == _empId),
                            l => l.LeaveId),
                        l => new { l.LeaveType, l.StartDate, l.EndDate, l.Status, l.ApprovedBy }
                    )
                );
                dgvLeaves.DataSource = leaves;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnSubmitLeave_Click(object sender, EventArgs e)
        {
            if (cmbLeaveType.SelectedItem == null || dtpStart.Value >= dtpEnd.Value)
            { MessageBox.Show("Select a leave type and valid date range.", "Validation"); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var newLeave = new Employeemanagment.Data.Models.LeaveRequest
                {
                    EmployeeId = _empId,
                    LeaveType = cmbLeaveType.SelectedItem.ToString(),
                    StartDate = dtpStart.Value.ToString("yyyy-MM-dd"),
                    EndDate = dtpEnd.Value.ToString("yyyy-MM-dd"),
                    Status = "Pending"
                };
                db.LeaveRequests.Add(newLeave);
                await db.SaveChangesAsync();
                
                MessageBox.Show("✅ Leave request submitted! Awaiting admin approval.", "Submitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadMyLeaves(); }
        }

        // ── Payslip ────────────────────────────────────────────────────────────
        private void LoadMyPayslips()
        {
            try
            {
                Con.Open();
                var sda = new SqlDataAdapter(
                    "SELECT Month,Year,BaseSalary,Bonus,Deductions,NetSalary FROM payroll_forecast WHERE EmployeeID=@id ORDER BY ForecastId DESC",
                    Con);
                sda.SelectCommand.Parameters.AddWithValue("@id", _empId);
                var dt = new DataTable(); sda.Fill(dt);
                dgvPayslips.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Con.Close(); }
        }

        // ── Performance ────────────────────────────────────────────────────────
        private void LoadMyPerformance()
        {
            try
            {
                Con.Open();
                var sda = new SqlDataAdapter(
                    "SELECT ReviewDate,Rating,IncrementRecommended,IncrementPercent,Comments FROM performance_reviews WHERE EmployeeID=@id ORDER BY ReviewId DESC",
                    Con);
                sda.SelectCommand.Parameters.AddWithValue("@id", _empId);
                var dt = new DataTable(); sda.Fill(dt);
                dgvPerformance.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Con.Close(); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new ModernLogin().Show();
            this.Hide();
        }
    }
}
