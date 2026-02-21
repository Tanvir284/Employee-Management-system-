using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelSidebar       = new Panel();
            panelHeader        = new Panel();
            panelContent       = new Panel();
            panelSidebarTop    = new Panel();   // Logo area inside sidebar
            lblSidebarTitle    = new Label();
            lblSidebarSub      = new Label();
            panelNavScroll     = new Panel();   // Scrollable nav area
            lblAppName         = new Label();
            lblTagline         = new Label();
            lblClock           = new Label();
            lblDate            = new Label();
            lblUser            = new Label();
            btnNotifications   = new Button();
            lblKpiSection      = new Label();
            pnlKpi1 = new Panel(); pnlKpi2 = new Panel();
            pnlKpi3 = new Panel(); pnlKpi4 = new Panel();
            lblActivitySection = new Label();
            dgvActivity        = new DataGridView();

            // Nav buttons
            btnNavEmployees   = MakeNavBtn("👥", "Employees");
            btnNavAttendance  = MakeNavBtn("📅", "Attendance");
            btnNavLeave       = MakeNavBtn("🏖", "Leave Mgmt");
            btnNavPerformance = MakeNavBtn("⭐", "Performance");
            btnNavPayroll     = MakeNavBtn("💼", "Payroll");
            btnNavOffboarding = MakeNavBtn("🚪", "Offboarding");
            btnNavDepartments = MakeNavBtn("🏢", "Departments");
            btnNavReports     = MakeNavBtn("📊", "Reports");
            btnNavAI          = MakeNavBtn("🤖", "AI Insights");
            btnLogout         = MakeNavBtn("⬅", "Logout");

            panelSidebar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActivity).BeginInit();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize  = new Size(1200, 720);
            MinimumSize = new Size(1000, 640);
            Text = "EMS Pro — Dashboard";
            BackColor = UITheme.BackDark;
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Load   += MainDashboard_Load;
            Resize += MainDashboard_Resize;

            // ══════════════════════════════════════════════════════════════════
            // SIDEBAR  (240px, left-docked, dark navy)
            // ══════════════════════════════════════════════════════════════════
            panelSidebar.BackColor = UITheme.Sidebar;
            panelSidebar.Dock      = DockStyle.Left;
            panelSidebar.Width     = 240;
            panelSidebar.Paint    += PanelSidebar_Paint;

            // --- Logo area (top of sidebar) ------------------------------------
            panelSidebarTop.Dock      = DockStyle.Top;
            panelSidebarTop.Height    = 80;
            panelSidebarTop.BackColor = System.Drawing.Color.FromArgb(5, 15, 32);
            panelSidebarTop.Paint    += PanelSidebarTop_Paint;

            // --- Scrollable nav area ------------------------------------------
            panelNavScroll.Dock      = DockStyle.Fill;
            panelNavScroll.BackColor = UITheme.Sidebar;
            panelNavScroll.AutoScroll = false;

            // --- SECTION labels -----------------------------------------------
            var lblS1 = MakeSepLabel("  MAIN");
            var lblS2 = MakeSepLabel("  ADVANCED");
            var lblS3 = MakeSepLabel("  SYSTEM");

            // NOTE: DockStyle.Top stacks bottom-to-top visually.
            // Add in REVERSE order so visual rendering equals top→bottom.
            panelNavScroll.Controls.Add(btnLogout);         // appears LAST = bottom
            panelNavScroll.Controls.Add(lblS3);
            panelNavScroll.Controls.Add(btnNavAI);
            panelNavScroll.Controls.Add(btnNavReports);
            panelNavScroll.Controls.Add(btnNavDepartments);
            panelNavScroll.Controls.Add(btnNavOffboarding);
            panelNavScroll.Controls.Add(btnNavPayroll);
            panelNavScroll.Controls.Add(btnNavPerformance);
            panelNavScroll.Controls.Add(btnNavLeave);
            panelNavScroll.Controls.Add(btnNavAttendance);
            panelNavScroll.Controls.Add(lblS2);
            panelNavScroll.Controls.Add(btnNavEmployees);
            panelNavScroll.Controls.Add(lblS1);             // appears FIRST = top

            // Logout special style (Danger red ghost)
            btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(20, UITheme.Danger);
            btnLogout.ForeColor = System.Drawing.Color.FromArgb(180, 200, 200, 200);

            // Wire sidebar clicks
            btnNavAttendance.Click  += btnNavAttendance_Click;
            btnNavLeave.Click       += btnNavLeave_Click;
            btnNavPerformance.Click += btnNavPerformance_Click;
            btnNavPayroll.Click     += btnNavPayroll_Click;
            btnNavOffboarding.Click += btnNavOffboarding_Click;
            btnNavDepartments.Click += btnNavDepartments_Click;
            btnNavReports.Click     += btnNavReports_Click;
            btnNavAI.Click          += btnNavAI_Click;
            btnNavEmployees.Click   += btnNavEmployees_Click;
            btnLogout.Click         += btnLogout_Click;

            panelSidebar.Controls.Add(panelNavScroll);
            panelSidebar.Controls.Add(panelSidebarTop);

            // ══════════════════════════════════════════════════════════════════
            // HEADER  (62px, top-docked, gradient)
            // ══════════════════════════════════════════════════════════════════
            panelHeader.Dock      = DockStyle.Top;
            panelHeader.Height    = 62;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Paint    += panelHeader_Paint;
            panelHeader.Controls.AddRange(new Control[] {
                lblAppName, lblTagline, btnNotifications, lblUser, lblDate, lblClock });

            lblAppName.Text      = "Employee Management System";
            lblAppName.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAppName.ForeColor = System.Drawing.Color.White;
            lblAppName.AutoSize  = true;
            lblAppName.Location  = new Point(14, 10);
            lblAppName.BackColor = System.Drawing.Color.Transparent;

            lblTagline.Text      = "PRO Edition  •  Admin Dashboard";
            lblTagline.Font      = new Font("Segoe UI", 8F);
            lblTagline.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
            lblTagline.AutoSize  = true;
            lblTagline.Location  = new Point(16, 38);
            lblTagline.BackColor = System.Drawing.Color.Transparent;

            // Right-side controls — positioned in Load/Resize (panelHeader.Width=0 here)
            lblClock.Text      = "--:--:--";
            lblClock.Font      = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblClock.ForeColor = UITheme.Gold;
            lblClock.AutoSize  = false;
            lblClock.Size      = new Size(140, 30);
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            lblClock.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblClock.Location  = new Point(900, 6);

            lblDate.Text      = "--";
            lblDate.Font      = new Font("Segoe UI", 7F);
            lblDate.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
            lblDate.AutoSize  = false;
            lblDate.Size      = new Size(140, 18);
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            lblDate.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Location  = new Point(900, 38);

            lblUser.Text      = "👤  Administrator";
            lblUser.Font      = UITheme.FontBold;
            lblUser.ForeColor = System.Drawing.Color.White;
            lblUser.AutoSize  = false;
            lblUser.Size      = new Size(150, 30);
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            lblUser.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.Location  = new Point(740, 16);

            btnNotifications.Text              = "🔔";
            btnNotifications.Font              = new Font("Segoe UI", 12F);
            btnNotifications.FlatStyle         = FlatStyle.Flat;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.BackColor         = System.Drawing.Color.Transparent;
            btnNotifications.ForeColor         = System.Drawing.Color.White;
            btnNotifications.Size              = new Size(46, 40);
            btnNotifications.Anchor            = AnchorStyles.Top | AnchorStyles.Right;
            btnNotifications.Location          = new Point(690, 10);
            btnNotifications.Cursor            = Cursors.Hand;
            btnNotifications.Click            += btnNotifications_Click;

            // ══════════════════════════════════════════════════════════════════
            // CONTENT  (fill remaining space)
            // ══════════════════════════════════════════════════════════════════
            panelContent.BackColor = UITheme.BackDark;
            panelContent.Dock      = DockStyle.Fill;
            panelContent.Padding   = new Padding(22, 18, 22, 18);
            panelContent.Controls.Add(dgvActivity);
            panelContent.Controls.Add(lblActivitySection);
            panelContent.Controls.Add(pnlKpi4);
            panelContent.Controls.Add(pnlKpi3);
            panelContent.Controls.Add(pnlKpi2);
            panelContent.Controls.Add(pnlKpi1);
            panelContent.Controls.Add(lblKpiSection);

            // KPI section label
            lblKpiSection.Text      = "  📊  LIVE OVERVIEW";
            lblKpiSection.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKpiSection.ForeColor = UITheme.TextSecondary;
            lblKpiSection.AutoSize  = false;
            lblKpiSection.Size      = new Size(900, 26);
            lblKpiSection.Location  = new Point(0, 0);
            lblKpiSection.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblKpiSection.BackColor = System.Drawing.Color.Transparent;

            // KPI cards (initial positions, recalculated in Resize)
            int cardH = 130, cardY = 30, gap = 14;
            int cardW = (920 - gap * 3) / 4;
            void SetKpi(Panel p, int col, System.Windows.Forms.PaintEventHandler handler) {
                p.BackColor = System.Drawing.Color.Transparent;
                p.Size      = new Size(cardW, cardH);
                p.Location  = new Point(col * (cardW + gap), cardY);
                p.Paint    += handler;
            }
            SetKpi(pnlKpi1, 0, pnlKpi1_Paint);
            SetKpi(pnlKpi2, 1, pnlKpi2_Paint);
            SetKpi(pnlKpi3, 2, pnlKpi3_Paint);
            SetKpi(pnlKpi4, 3, pnlKpi4_Paint);

            // Activity section label
            lblActivitySection.Text      = "  📋  RECENT ACTIVITY";
            lblActivitySection.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActivitySection.ForeColor = UITheme.TextSecondary;
            lblActivitySection.AutoSize  = false;
            lblActivitySection.Size      = new Size(900, 26);
            lblActivitySection.Location  = new Point(0, cardY + cardH + 14);
            lblActivitySection.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblActivitySection.BackColor = System.Drawing.Color.Transparent;

            // Activity grid
            dgvActivity.Location = new Point(0, cardY + cardH + 44);
            dgvActivity.Anchor   = AnchorStyles.Top | AnchorStyles.Left
                                 | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvActivity.Size     = new Size(920, 400);
            UITheme.StyleDataGrid(dgvActivity);

            panelSidebar.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActivity).EndInit();
            ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private static Button MakeNavBtn(string icon, string title)
        {
            var btn = new Button
            {
                Text      = $"  {icon}   {title}",
                Dock      = DockStyle.Top,
                Height    = 44,
                FlatStyle = FlatStyle.Flat,
                BackColor = UITheme.Sidebar,
                ForeColor = UITheme.TextSecondary,
                Font      = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor    = Cursors.Hand,
                Padding   = new Padding(8, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = UITheme.NavHover;
            btn.MouseEnter += (s, e) => { if (btn.Tag?.ToString() != "active") btn.ForeColor = UITheme.TextPrimary; };
            btn.MouseLeave += (s, e) => { if (btn.Tag?.ToString() != "active") btn.ForeColor = UITheme.TextSecondary; };
            return btn;
        }

        private static Label MakeSepLabel(string text)
        {
            return new Label
            {
                Text      = text,
                Font      = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(80, 120, 140),
                AutoSize  = false, Height = 30, Dock = DockStyle.Top,
                TextAlign = ContentAlignment.BottomLeft,
                Padding   = new Padding(10, 0, 0, 4),
                BackColor = UITheme.Sidebar
            };
        }

        // ── Sidebar branding panel paint ──────────────────────────────────────
        private void PanelSidebarTop_Paint(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int W = panelSidebarTop.Width, H = panelSidebarTop.Height;
            using var bg = new LinearGradientBrush(new Rectangle(0, 0, W, H),
                System.Drawing.Color.FromArgb(8, 18, 45), System.Drawing.Color.FromArgb(5, 12, 30),
                LinearGradientMode.Vertical);
            g.FillRectangle(bg, 0, 0, W, H);
            // Bottom separator
            using var sepPen = new Pen(System.Drawing.Color.FromArgb(30, UITheme.Accent), 1);
            g.DrawLine(sepPen, 0, H - 1, W, H - 1);
            // Logo text
            using var bigFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var subFont = new Font("Segoe UI", 7.5F);
            g.DrawString("💼  EMS PRO", bigFont, new SolidBrush(UITheme.Accent), 12, 14);
            g.DrawString("Employee Management System", subFont,
                new SolidBrush(System.Drawing.Color.FromArgb(120, 180, 220)), 12, 52);
        }

        private void PanelSidebar_Paint(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Right-edge glow line
            using var pen = new Pen(System.Drawing.Color.FromArgb(18, UITheme.Accent), 1);
            e.Graphics.DrawLine(pen, panelSidebar.Width - 1, 0, panelSidebar.Width - 1, panelSidebar.Height);
        }

        // Fields
        private Panel panelSidebar, panelHeader, panelContent;
        private Panel panelSidebarTop, panelNavScroll;
        private Panel pnlKpi1, pnlKpi2, pnlKpi3, pnlKpi4;
        private Label lblAppName, lblTagline, lblClock, lblDate, lblUser;
        private Label lblKpiSection, lblActivitySection, lblSidebarTitle, lblSidebarSub;
        private Button btnNotifications, btnLogout;
        private Button btnNavEmployees, btnNavAttendance, btnNavLeave, btnNavPerformance;
        private Button btnNavPayroll, btnNavOffboarding, btnNavDepartments, btnNavReports, btnNavAI;
        private DataGridView dgvActivity;
    }
}
