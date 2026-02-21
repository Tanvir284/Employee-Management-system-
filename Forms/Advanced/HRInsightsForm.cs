using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Employeemanagment.Data;

namespace Employeemanagment
{
    public partial class HRInsightsForm : Form
    {
        public HRInsightsForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void HRInsightsForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvInsights.Columns.Clear();
            dgvInsights.Columns.Add("Severity", "🔴 Severity");
            dgvInsights.Columns.Add("Category", "📋 Category");
            dgvInsights.Columns.Add("EmployeeID", "Employee ID");
            dgvInsights.Columns.Add("Name", "Name");
            dgvInsights.Columns.Add("Insight", "💡 Insight / Recommendation");
            dgvInsights.Columns["Severity"].Width = 90;
            dgvInsights.Columns["Category"].Width = 160;
            dgvInsights.Columns["EmployeeID"].Width = 100;
            dgvInsights.Columns["Name"].Width = 140;
            dgvInsights.Columns["Insight"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            dgvInsights.Rows.Clear();
            lblStatus.Text = "⏳ Running AI analysis...";
            lblStatus.ForeColor = Color.DarkOrange;
            Refresh();

            try
            {
                using var db = new EmployeeDbContext();
                
                await RunAbsenteeismCheck(db);
                await RunLeaveOverloadCheck(db);
                await RunReviewDueCheck(db);
                await RunIncrementReadyCheck(db);
                await RunPayrollTrendCheck(db);
                await RunTurnoverRiskCheck(db);
                await RunOffboardingTrendCheck(db);
                await RunHighPerformerCheck(db);

                int total = dgvInsights.Rows.Count;
                lblStatus.Text = total == 0
                    ? "✅ No issues detected. All employees are healthy!"
                    : $"⚠️ Analysis complete — {total} insight(s) found.";
                lblStatus.ForeColor = total == 0 ? Color.DarkGreen : Color.Brown;

                ColorInsightRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); lblStatus.Text = "❌ Error during analysis."; lblStatus.ForeColor = Color.Red; }
        }

        private void AddInsight(string severity, string category, string empId, string name, string insight)
            => dgvInsights.Rows.Add(severity, category, empId, name, insight);

        private async System.Threading.Tasks.Task RunAbsenteeismCheck(EmployeeDbContext db)
        {
            string month = DateTime.Today.ToString("yyyy-MM");
            var absentees = await db.Attendances
                .Where(a => a.Status == "Absent" && a.Date != null && a.Date.StartsWith(month))
                .GroupBy(a => a.EmployeeId)
                .Where(g => g.Count() >= 3)
                .Select(g => new { EmpId = g.Key, Count = g.Count() })
                .ToListAsync();

            foreach (var a in absentees)
            {
                var emp = await db.Employees.FindAsync(a.EmpId);
                AddInsight("🔴 HIGH", "Absenteeism Alert", a.EmpId ?? "-", emp?.Name ?? "Unknown", 
                    $"High absenteeism: {a.Count} absent days this month. Consider follow-up.");
            }
        }

        private async System.Threading.Tasks.Task RunLeaveOverloadCheck(EmployeeDbContext db)
        {
            var loads = await db.LeaveRequests
                .Where(l => l.Status == "Pending")
                .GroupBy(l => l.EmployeeId)
                .Where(g => g.Count() > 2)
                .Select(g => new { EmpId = g.Key, Count = g.Count() })
                .ToListAsync();
                
            foreach (var a in loads)
            {
                var emp = await db.Employees.FindAsync(a.EmpId);
                AddInsight("🟡 MEDIUM", "Leave Overload", a.EmpId ?? "-", emp?.Name ?? "Unknown", 
                    $"{a.Count} pending leave requests — requires admin attention.");
            }
        }

        private async System.Threading.Tasks.Task RunReviewDueCheck(EmployeeDbContext db)
        {
            var sixMonthsAgo = DateTime.Today.AddMonths(-6).ToString("yyyy-MM-dd");
            var employees = await db.Employees.ToListAsync();
            var reviews = await db.PerformanceReviews.ToListAsync();

            foreach (var emp in employees)
            {
                bool hasRecent = reviews.Any(pr => pr.EmployeeId == emp.Id && string.Compare(pr.ReviewDate, sixMonthsAgo) >= 0);
                if (!hasRecent)
                {
                    AddInsight("🟡 MEDIUM", "Review Due", emp.Id, emp.Name ?? "Unknown", "No performance review in the last 6 months. Schedule a review soon.");
                }
            }
        }

        private async System.Threading.Tasks.Task RunIncrementReadyCheck(EmployeeDbContext db)
        {
            var ready = await db.PerformanceReviews
                .GroupBy(pr => pr.EmployeeId)
                .Select(g => g.OrderByDescending(p => p.ReviewId).FirstOrDefault())
                .Where(pr => pr != null && pr.IncrementRecommended == "Yes")
                .ToListAsync();

            foreach (var pr in ready)
            {
                var emp = await db.Employees.FindAsync(pr!.EmployeeId);
                AddInsight("🟢 LOW", "Increment Ready", pr.EmployeeId ?? "-", emp?.Name ?? "Unknown", 
                    $"Recommended for {pr.IncrementPercent}% salary increment based on latest review.");
            }
        }

        private async System.Threading.Tasks.Task RunPayrollTrendCheck(EmployeeDbContext db)
        {
            var trends = await db.PayrollForecasts
                .GroupBy(pf => pf.EmployeeId)
                .Select(g => new { 
                    EmpId = g.Key, 
                    Max = g.Max(p => p.NetSalary ?? 0m), 
                    Min = g.Min(p => p.NetSalary ?? 0m), 
                    Avg = g.Average(p => p.NetSalary ?? 0m) 
                })
                .Where(x => (x.Max - x.Min) > (x.Avg * 0.15m))
                .ToListAsync();

            foreach (var t in trends)
            {
                var emp = await db.Employees.FindAsync(t.EmpId);
                AddInsight("🟡 MEDIUM", "Payroll Variance", t.EmpId ?? "-", emp?.Name ?? "Unknown", 
                    $"High payroll variance detected. Min: {t.Min:F0} / Max: {t.Max:F0} BDT — review consistency.");
            }
        }

        private async System.Threading.Tasks.Task RunTurnoverRiskCheck(EmployeeDbContext db)
        {
            string month = DateTime.Today.ToString("yyyy-MM");
            
            var lowPerformers = await db.PerformanceReviews
                .GroupBy(pr => pr.EmployeeId)
                .Select(g => g.OrderByDescending(p => p.ReviewId).FirstOrDefault())
                .Where(pr => pr != null && pr.Rating <= 2)
                .Select(pr => pr!.EmployeeId)
                .ToListAsync();

            var highAbsentees = await db.Attendances
                .Where(a => a.Status == "Absent" && a.Date != null && a.Date.StartsWith(month))
                .GroupBy(a => a.EmployeeId)
                .Where(g => g.Count() >= 2)
                .Select(g => g.Key)
                .ToListAsync();

            var riskIds = lowPerformers.Intersect(highAbsentees).ToList();

            foreach (var id in riskIds)
            {
                var emp = await db.Employees.FindAsync(id);
                AddInsight("🔴 HIGH", "Turnover Risk", id ?? "-", emp?.Name ?? "Unknown", 
                    "⚠️ AI Alert: Low performance rating + high absenteeism = elevated turnover risk. Consider HR intervention.");
            }
        }

        private async System.Threading.Tasks.Task RunOffboardingTrendCheck(EmployeeDbContext db)
        {
            var trend = await db.OffboardedEmployees
                .Where(o => o.Shift != null)
                .GroupBy(o => o.Shift)
                .Select(g => new { Shift = g.Key, Cnt = g.Count() })
                .OrderByDescending(x => x.Cnt)
                .FirstOrDefaultAsync();

            if (trend != null && trend.Cnt >= 2)
            {
                AddInsight("🟡 MEDIUM", "Offboarding Trend", "—", "—", 
                    $"Shift '{trend.Shift}' has the highest offboarding count ({trend.Cnt}). Investigate retention in this shift.");
            }
        }

        private async System.Threading.Tasks.Task RunHighPerformerCheck(EmployeeDbContext db)
        {
            var stars = await db.PerformanceReviews
                .GroupBy(pr => pr.EmployeeId)
                .Select(g => g.OrderByDescending(p => p.ReviewId).FirstOrDefault())
                .Where(pr => pr != null && pr.Rating == 5)
                .ToListAsync();

            foreach (var pr in stars)
            {
                var emp = await db.Employees.FindAsync(pr!.EmployeeId);
                AddInsight("🟢 LOW", "High Performer", pr.EmployeeId ?? "-", emp?.Name ?? "Unknown", 
                    "⭐ Top performer with Rating 5. Consider retention bonus or fast-track promotion.");
            }
        }

        private void ColorInsightRows()
        {
            foreach (DataGridViewRow row in dgvInsights.Rows)
            {
                string sev = row.Cells["Severity"].Value?.ToString() ?? "";
                if (sev.Contains("HIGH"))
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 199, 206);
                else if (sev.Contains("MEDIUM"))
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 156);
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(198, 239, 206);
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
