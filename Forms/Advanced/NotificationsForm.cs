using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class NotificationsForm : Form
    {

        public NotificationsForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            this.BackColor = UITheme.BackDark;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            UITheme.StyleDataGrid(dgvNotifications);
            // Make the grid wider on the Message column
            dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvNotifications.CellDoubleClick += DgvNotifications_CellDoubleClick;
            dgvNotifications.CursorChanged += (s, ev) => { };
            dgvNotifications.Cursor = Cursors.Hand;
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            var dt = new DataTable();
            dt.Columns.Add("Severity");
            dt.Columns.Add("Category");
            dt.Columns.Add("Message");
            dt.Columns.Add("Time");

            try
            {
                using var Con = new SqlConnection(ConfigHelper.GetConnectionString());
                Con.Open();

                // 1. Pending leave requests
                using (var cmd = new SqlCommand("SELECT EmployeeID, LeaveType, StartDate FROM leave_requests WHERE Status='Pending'", Con))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        dt.Rows.Add("🟡 PENDING", "Leave Request", $"Employee {r["EmployeeID"]} requested {r["LeaveType"]} from {r["StartDate"]}", DateTime.Now.ToString("HH:mm"));

                // 2. High absenteeism this month
                string month = DateTime.Today.ToString("yyyy-MM");
                using (var cmd2 = new SqlCommand($"SELECT EmployeeID, COUNT(*) as Cnt FROM attendance WHERE Status='Absent' AND Date LIKE '{month}%' GROUP BY EmployeeID HAVING COUNT(*) >= 3", Con))
                using (var r2 = cmd2.ExecuteReader())
                    while (r2.Read())
                        dt.Rows.Add("🔴 URGENT", "Absenteeism", $"Employee {r2["EmployeeID"]} has {r2["Cnt"]} absences this month — follow up needed", DateTime.Now.ToString("HH:mm"));

                // 3. Reviews overdue (no review in 6+ months)
                using (var cmd3 = new SqlCommand(@"SELECT e.ID FROM employee e WHERE NOT EXISTS (SELECT 1 FROM performance_reviews pr WHERE pr.EmployeeID=e.ID AND DATEDIFF(month,CAST(pr.ReviewDate AS DATE),GETDATE())<=6)", Con))
                using (var r3 = cmd3.ExecuteReader())
                    while (r3.Read())
                        dt.Rows.Add("🟡 INFO", "Review Due", $"Employee {r3["ID"]} has no performance review in 6+ months", DateTime.Now.ToString("HH:mm"));

                // 4. No attendance logged today
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                using (var cmd4 = new SqlCommand($"SELECT ID FROM employee WHERE ID NOT IN (SELECT EmployeeID FROM attendance WHERE Date='{today}')", Con))
                using (var r4 = cmd4.ExecuteReader())
                    while (r4.Read())
                        dt.Rows.Add("🟡 INFO", "Missing Attendance", $"Employee {r4["ID"]} has no attendance record for today", DateTime.Now.ToString("HH:mm"));

                // 5. Increment-recommended employees
                using (var cmd5 = new SqlCommand(@"SELECT EmployeeID, IncrementPercent FROM performance_reviews WHERE IncrementRecommended='Yes' AND ReviewId IN (SELECT MAX(ReviewId) FROM performance_reviews GROUP BY EmployeeID)", Con))
                using (var r5 = cmd5.ExecuteReader())
                    while (r5.Read())
                        dt.Rows.Add("🟢 GOOD", "Increment Ready", $"Employee {r5["EmployeeID"]} is eligible for a {r5["IncrementPercent"]}% salary increment", DateTime.Now.ToString("HH:mm"));
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            dgvNotifications.DataSource = dt;

            // Fix column widths so Message is never cut off
            if (dgvNotifications.Columns.Count >= 4)
            {
                dgvNotifications.Columns[0].Width = 110; // Severity
                dgvNotifications.Columns[1].Width = 160; // Category
                dgvNotifications.Columns[2].Width = 480; // Message — wide
                dgvNotifications.Columns[3].Width = 70;  // Time
            }

            lblCount.Text = $"{dt.Rows.Count} notification(s) found  •  Double-click any row to open the feature";
            lblCount.ForeColor = dt.Rows.Count > 0 ? UITheme.Warning : UITheme.Success;

            // Color rows
            foreach (DataGridViewRow row in dgvNotifications.Rows)
            {
                if (row.IsNewRow) continue;
                string sev = row.Cells["Severity"].Value?.ToString() ?? "";
                row.DefaultCellStyle.BackColor = sev.Contains("URGENT") ? Color.FromArgb(60, 180, 40, 40) :
                                                  sev.Contains("PENDING") ? Color.FromArgb(60, 180, 120, 0) :
                                                  sev.Contains("GOOD") ? Color.FromArgb(50, 30, 130, 50) :
                                                  UITheme.Card;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // ── Double-click a notification row → open the relevant feature ────────
        private void DgvNotifications_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string category = dgvNotifications.Rows[e.RowIndex].Cells["Category"].Value?.ToString() ?? "";

            Form? target = category switch
            {
                "Leave Request"      => new LeaveManagementForm(),
                "Absenteeism"        => new AttendanceForm(),
                "Missing Attendance" => new AttendanceForm(),
                "Review Due"         => new PerformanceReviewForm(),
                "Increment Ready"    => new PayrollForecastForm(),
                _                   => null
            };

            if (target == null)
            {
                MessageBox.Show("No specific feature linked to this notification.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Show the feature form; keep Notifications open so user can come back
            target.Show();
            this.Close();
        }
    }
}
