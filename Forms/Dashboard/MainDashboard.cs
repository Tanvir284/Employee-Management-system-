using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Employeemanagment
{
    public partial class MainDashboard : Form
    {
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());
        private System.Windows.Forms.Timer _clockTimer = new();
        private System.Windows.Forms.Timer _refreshTimer = new();

        // KPI values (painted on card panels)
        private string _kpiEmployees = "--";
        private string _kpiPresent   = "--";
        private string _kpiLeave     = "--";
        private string _kpiPending   = "--";

        // Charts
        private LiveCharts.WinForms.CartesianChart _chartAttendance;
        private LiveCharts.WinForms.PieChart _chartDepts;

        public MainDashboard()
        {
            InitializeComponent();
            btnNavEmployees.Tag = "AdminOnly";
            btnNavDepartments.Tag = "AdminOnly";
            btnNavPayroll.Tag = "AdminOnly";
            btnNavOffboarding.Tag = "AdminOnly";
            btnNavAI.Tag = "AdminOnly";
            btnNavReports.Tag = "AdminOnly";
            
            UITheme.ApplyThemeToForm(this);
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"👤  {Core.SessionManager.CurrentUserName} ({Core.SessionManager.CurrentRole})";

            // Initialize Charts
            _chartAttendance = new LiveCharts.WinForms.CartesianChart { BackColor = Color.Transparent };
            _chartDepts = new LiveCharts.WinForms.PieChart { BackColor = Color.Transparent, InnerRadius = 30, LegendLocation = LegendLocation.Right };

            panelContent.Controls.Add(_chartAttendance);
            panelContent.Controls.Add(_chartDepts);

            // Clock
            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, _) => UpdateClock();
            _clockTimer.Start();
            UpdateClock();

            // Auto-refresh every 30s
            _refreshTimer.Interval = 30000;
            _refreshTimer.Tick += (s, _) => { LoadKPIs(); LoadRecentActivity(); UpdateNotificationBadge(); LoadCharts(); };
            _refreshTimer.Start();

            LoadKPIs();
            LoadRecentActivity();
            UpdateNotificationBadge();
            LoadCharts();

            // Trigger initial layout for KPI cards and right-aligned header controls
            MainDashboard_Resize(this, EventArgs.Empty);
        }

        private void UpdateClock()
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text  = DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }

        private async void LoadKPIs()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                
                _kpiEmployees = (await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.CountAsync(db.Employees)).ToString();
                
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                _kpiPresent = (await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.CountAsync(
                    System.Linq.Queryable.Where(db.Attendances, a => a.Date == today && a.Status == "Present"))).ToString();

                // Read all active requests and filter locally to avoid weird string compare translation errors in older SQL Server / EF versions
                var approvedLeaves = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Where(db.LeaveRequests, l => l.Status == "Approved"));
                _kpiLeave = approvedLeaves.Count(l => 
                    string.Compare(l.StartDate, today) <= 0 && string.Compare(l.EndDate, today) >= 0).ToString();

                _kpiPending = (await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.CountAsync(
                    System.Linq.Queryable.Where(db.LeaveRequests, l => l.Status == "Pending"))).ToString();
            }
            catch { }

            // Repaint KPI cards
            pnlKpi1.Invalidate(); pnlKpi2.Invalidate(); pnlKpi3.Invalidate(); pnlKpi4.Invalidate();
        }

        private async void LoadRecentActivity()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                
                var attendanceActs = System.Linq.Queryable.Select(db.Attendances, a => new {
                    Type = "Attendance",
                    ID = a.EmployeeId,
                    Detail = a.Status + " on " + a.Date,
                    Time = a.Date
                }).OrderByDescending(x => x.Time).Take(8);
                
                var leaveActs = System.Linq.Queryable.Select(db.LeaveRequests, l => new {
                    Type = "Leave",
                    ID = l.EmployeeId,
                    Detail = l.Status + " - " + l.LeaveType,
                    Time = l.StartDate
                }).OrderByDescending(x => x.Time).Take(8);
                
                var acts = (await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(attendanceActs))
                    .Concat(await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(leaveActs))
                    .OrderByDescending(x => x.Time)
                    .Take(8)
                    .ToList();
                    
                dgvActivity.DataSource = acts;
            }
            catch { }
        }

        private async void UpdateNotificationBadge()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                int pending = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.CountAsync(
                    System.Linq.Queryable.Where(db.LeaveRequests, l => l.Status == "Pending"));
                
                btnNotifications.Text = pending > 0 ? $"🔔 {pending}" : "🔔";
                btnNotifications.ForeColor = pending > 0 ? UITheme.Danger : UITheme.TextSecondary;
            }
            catch { }
        }

        private async void LoadCharts()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                
                // 1. Department Pie Chart
                var deptGroups = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.GroupBy(db.Employees, e => e.Shift),
                        g => new { Dept = string.IsNullOrEmpty(g.Key) ? "Unassigned" : g.Key, Count = g.Count() }
                    )
                );

                var pieSeries = new SeriesCollection();
                foreach (var d in deptGroups)
                {
                    pieSeries.Add(new PieSeries
                    {
                        Title = d.Dept,
                        Values = new ChartValues<int> { d.Count },
                        DataLabels = true,
                        LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P})"
                    });
                }
                _chartDepts.Series = pieSeries;

                // 2. Attendance Line Chart
                var endDate = DateTime.Today;
                var startDate = endDate.AddDays(-6);
                string startStr = startDate.ToString("yyyy-MM-dd");
                string endStr = endDate.ToString("yyyy-MM-dd");

                var records = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Where(db.Attendances, a => string.Compare(a.Date, startStr) >= 0 && string.Compare(a.Date, endStr) <= 0)
                );

                var dateLabels = new System.Collections.Generic.List<string>();
                var presentVals = new ChartValues<int>();
                var absentVals = new ChartValues<int>();

                // Build values for the last 7 days
                for (int i = 0; i <= 6; i++)
                {
                    var d = startDate.AddDays(i).ToString("yyyy-MM-dd");
                    dateLabels.Add(startDate.AddDays(i).ToString("MMM dd"));
                    presentVals.Add(System.Linq.Enumerable.Count(records, r => r.Date == d && r.Status == "Present"));
                    absentVals.Add(System.Linq.Enumerable.Count(records, r => r.Date == d && r.Status == "Absent"));
                }

                _chartAttendance.Series = new SeriesCollection
                {
                    new LineSeries { Title = "Present", Values = presentVals, Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(76, 175, 80)) },
                    new LineSeries { Title = "Absent", Values = absentVals, Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(244, 67, 54)) }
                };

                _chartAttendance.AxisX.Clear();
                _chartAttendance.AxisX.Add(new Axis { Title = "Date", Labels = dateLabels });
                _chartAttendance.AxisY.Clear();
                _chartAttendance.AxisY.Add(new Axis { Title = "Employees", MinValue = 0, LabelFormatter = value => value.ToString("N0") });
            }
            catch { }
        }

        // ── KPI Card painters ─────────────────────────────────────────────────
        private void pnlKpi1_Paint(object s, PaintEventArgs e) =>
            UITheme.PaintKPICard(e, new Rectangle(0,0,pnlKpi1.Width,pnlKpi1.Height), "🧑‍💼", _kpiEmployees, "Total Employees", UITheme.Accent);
        private void pnlKpi2_Paint(object s, PaintEventArgs e) =>
            UITheme.PaintKPICard(e, new Rectangle(0,0,pnlKpi2.Width,pnlKpi2.Height), "✅", _kpiPresent, "Present Today", UITheme.Success);
        private void pnlKpi3_Paint(object s, PaintEventArgs e) =>
            UITheme.PaintKPICard(e, new Rectangle(0,0,pnlKpi3.Width,pnlKpi3.Height), "🏖️", _kpiLeave, "On Leave", UITheme.Warning);
        private void pnlKpi4_Paint(object s, PaintEventArgs e) =>
            UITheme.PaintKPICard(e, new Rectangle(0,0,pnlKpi4.Width,pnlKpi4.Height), "⏳", _kpiPending, "Pending Approvals", UITheme.Danger);

        // ── Header gradient paint ─────────────────────────────────────────────
        private void panelHeader_Paint(object sender, PaintEventArgs e)
            => UITheme.PaintGradientHeader(e, new Rectangle(0, 0, panelHeader.Width, panelHeader.Height));

        // ── Navigation Click Handlers ─────────────────────────────────────────
        private void OpenForm(Form f, Button navBtn)
        {
            UITheme.ActivateNav(navBtn, panelNavScroll);  // nav buttons live in panelNavScroll
            f.Show(); this.Hide();
        }

        private void btnNavAttendance_Click(object s, EventArgs e)   => OpenForm(new AttendanceForm(),       btnNavAttendance);
        private void btnNavLeave_Click(object s, EventArgs e)        => OpenForm(new LeaveManagementForm(),  btnNavLeave);
        private void btnNavPerformance_Click(object s, EventArgs e)  => OpenForm(new PerformanceReviewForm(), btnNavPerformance);
        private void btnNavPayroll_Click(object s, EventArgs e)      => OpenForm(new PayrollForecastForm(),  btnNavPayroll);
        private void btnNavOffboarding_Click(object s, EventArgs e)  => OpenForm(new OffboardingForm(),      btnNavOffboarding);
        private void btnNavDepartments_Click(object s, EventArgs e)  => OpenForm(new DepartmentForm(),       btnNavDepartments);
        private void btnNavReports_Click(object s, EventArgs e)      => OpenForm(new ReportsForm(),          btnNavReports);
        private void btnNavAI_Click(object s, EventArgs e)           => OpenForm(new HRInsightsForm(),       btnNavAI);

        private void btnNavEmployees_Click(object s, EventArgs e)
        {
            UITheme.ActivateNav(btnNavEmployees, panelNavScroll);
            var a = new admin(); a.Show(); this.Hide();
        }

        private void btnNotifications_Click(object s, EventArgs e)
        {
            new NotificationsForm().Show();
        }

        private void btnLogout_Click(object s, EventArgs e)
        {
            _clockTimer.Stop(); _refreshTimer.Stop();
            var login = new ModernLogin();
            login.Show(); this.Hide();
        }

        // ── Resize: reflow KPI cards and right-aligned header labels ─────────
        private void MainDashboard_Resize(object sender, EventArgs e)
        {
            if (panelContent.Width < 10) return;
            int gap = 14;
            int pad = panelContent.Padding.Left + panelContent.Padding.Right;
            int w   = (panelContent.Width - pad - gap * 3) / 4;
            int y   = 30;
            pnlKpi1.Width = w; pnlKpi1.Left = 0;
            pnlKpi2.Width = w; pnlKpi2.Left = w + gap;
            pnlKpi3.Width = w; pnlKpi3.Left = (w + gap) * 2;
            pnlKpi4.Width = w; pnlKpi4.Left = (w + gap) * 3;
            pnlKpi1.Top = pnlKpi2.Top = pnlKpi3.Top = pnlKpi4.Top = y;

            // Section labels move too
            int afterCards = y + pnlKpi1.Height + 14;
            lblActivitySection.Top = afterCards;
            dgvActivity.Top = afterCards + 28;

            // Right-side header controls — reposition now that we have the real width
            int rEdge = panelHeader.Width;
            if (rEdge >= 300)
            {
                lblClock.Left         = rEdge - 290;
                lblDate.Left          = rEdge - 290;
                lblUser.Left          = rEdge - 145;
                btnNotifications.Left = rEdge - 305;
            }

            dgvActivity.Width = (panelContent.Width - pad) / 2 - 10;
            
            if (_chartAttendance != null)
            {
                int cX = dgvActivity.Right + 20;
                int cW = panelContent.Width - pad - cX;
                int cH = dgvActivity.Height / 2 - 10;
                
                _chartAttendance.Location = new Point(cX, dgvActivity.Top);
                _chartAttendance.Size = new Size(cW, cH);
                _chartAttendance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                _chartDepts.Location = new Point(cX, _chartAttendance.Bottom + 20);
                _chartDepts.Size = new Size(cW, cH);
                _chartDepts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
    }
}
