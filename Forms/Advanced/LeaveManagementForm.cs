using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class LeaveManagementForm : Form
    {
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        public LeaveManagementForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void LeaveManagementForm_Load(object sender, EventArgs e)
        {
            cmbLeaveType.Items.AddRange(new string[] { "Annual Leave", "Sick Leave", "Casual Leave", "Maternity Leave", "Paternity Leave", "Unpaid Leave" });
            cmbLeaveType.SelectedIndex = 0;
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddDays(1);
            LoadPendingLeaves();
            LoadAllLeaves();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReqEmpID.Text) || string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpEnd.Value < dtpStart.Value)
            {
                MessageBox.Show("End Date cannot be before Start Date.", "Invalid Date");
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var newLeave = new Employeemanagment.Data.Models.LeaveRequest
                {
                    EmployeeId = txtReqEmpID.Text.Trim(),
                    LeaveType = cmbLeaveType.SelectedItem?.ToString(),
                    StartDate = dtpStart.Value.ToString("yyyy-MM-dd"),
                    EndDate = dtpEnd.Value.ToString("yyyy-MM-dd"),
                    Reason = txtReason.Text.Trim(),
                    Status = "Pending"
                };
                db.LeaveRequests.Add(newLeave);
                await db.SaveChangesAsync();

                MessageBox.Show("Leave request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReqEmpID.Clear(); txtReason.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadPendingLeaves(); LoadAllLeaves(); }
        }

        private async void LoadPendingLeaves()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var pending = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.OrderByDescending(
                            System.Linq.Queryable.Where(db.LeaveRequests, l => l.Status == "Pending"),
                            l => l.LeaveId),
                        l => new { l.LeaveId, l.EmployeeId, l.LeaveType, l.StartDate, l.EndDate, l.Reason }
                    )
                );
                dgvPending.DataSource = pending;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LoadAllLeaves()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var all = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.OrderByDescending(db.LeaveRequests, l => l.LeaveId),
                        l => new { l.LeaveId, l.EmployeeId, l.LeaveType, l.StartDate, l.EndDate, l.Status, l.ApprovedBy, l.ApprovedDate }
                    )
                );
                dgvAll.DataSource = all;
                ColorLeaveRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ColorLeaveRows()
        {
            foreach (DataGridViewRow row in dgvAll.Rows)
            {
                if (row.IsNewRow) continue;
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                row.DefaultCellStyle.BackColor = status switch
                {
                    "Approved" => Color.FromArgb(198, 239, 206),
                    "Rejected" => Color.FromArgb(255, 199, 206),
                    _ => Color.FromArgb(255, 235, 156)
                };
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e) => UpdateLeaveStatus("Approved");
        private void BtnReject_Click(object sender, EventArgs e) => UpdateLeaveStatus("Rejected");

        private async void UpdateLeaveStatus(string status)
        {
            if (dgvPending.CurrentRow == null) { MessageBox.Show("Select a leave request first."); return; }
            int leaveId = Convert.ToInt32(dgvPending.CurrentRow.Cells["LeaveId"].Value);
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var request = await db.LeaveRequests.FindAsync(leaveId);
                if (request != null)
                {
                    request.Status = status;
                    request.ApprovedBy = "Admin";
                    request.ApprovedDate = DateTime.Today.ToString("yyyy-MM-dd");
                    await db.SaveChangesAsync();
                    MessageBox.Show($"Leave {status} successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadPendingLeaves(); LoadAllLeaves(); }
        }

        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}

