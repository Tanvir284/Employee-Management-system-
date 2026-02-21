using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class ModernLogin
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelLeft     = new Panel();
            panelRight    = new Panel();
            lblWelcome    = new Label();
            lblSubRight   = new Label();
            lblIdHint     = new Label();
            txtID         = new TextBox();
            lineId        = new Panel();
            lblPwHint     = new Label();
            txtPassword   = new TextBox();
            linePw        = new Panel();
            btnLogin      = new Button();
            btnExit       = new Button();
            btnSignUp     = new Button();
            lblError      = new Label();
            lblClock      = new Label();

            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize    = new Size(950, 580);
            MinimumSize   = new Size(800, 500);
            Text = "EMS Pro — Login";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition   = FormStartPosition.CenterScreen;
            BackColor       = UITheme.BackDark;
            DoubleBuffered  = true;
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Load += ModernLogin_Load;

            // ── LEFT branding panel ───────────────────────────────────────────
            panelLeft.Dock      = DockStyle.Left;
            panelLeft.Width     = 370;
            panelLeft.BackColor = UITheme.HeaderGrad2;
            panelLeft.Paint    += PanelLeft_Paint;
            // Drag-to-move on the left panel
            panelLeft.MouseDown += (s, e) => { if (e.Button == System.Windows.Forms.MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };

            // ── RIGHT form panel ──────────────────────────────────────────────
            panelRight.Dock      = DockStyle.Fill;
            panelRight.BackColor = UITheme.Card;
            panelRight.Padding   = new Padding(50, 0, 50, 0);
            panelRight.Controls.AddRange(new Control[] {
                lblClock, lblWelcome, lblSubRight,
                lblIdHint, txtID, lineId,
                lblPwHint, txtPassword, linePw,
                lblError, btnLogin, btnExit, btnSignUp
            });

            // ── Clock (top right of right panel) ─────────────────────────────
            lblClock.AutoSize  = true;
            lblClock.Font      = UITheme.FontSmall;
            lblClock.ForeColor = UITheme.TextSecondary;
            lblClock.Location  = new Point(50, 18);
            lblClock.BackColor = System.Drawing.Color.Transparent;
            lblClock.Text      = "";

            // ── Welcome heading ───────────────────────────────────────────────
            lblWelcome.Text      = "Welcome Back 👋";
            lblWelcome.Font      = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = UITheme.TextPrimary;
            lblWelcome.AutoSize  = true;
            lblWelcome.Location  = new Point(50, 100);
            lblWelcome.BackColor = System.Drawing.Color.Transparent;

            lblSubRight.Text      = "Login to your account to continue";
            lblSubRight.Font      = UITheme.FontBody;
            lblSubRight.ForeColor = UITheme.TextSecondary;
            lblSubRight.AutoSize  = true;
            lblSubRight.Location  = new Point(50, 140);
            lblSubRight.BackColor = System.Drawing.Color.Transparent;

            // ── ID field ──────────────────────────────────────────────────────
            lblIdHint.Text      = "USER ID  /  EMPLOYEE ID";
            lblIdHint.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblIdHint.ForeColor = UITheme.Accent;
            lblIdHint.AutoSize  = true;
            lblIdHint.Location  = new Point(50, 200);
            lblIdHint.BackColor = System.Drawing.Color.Transparent;

            txtID.BorderStyle    = BorderStyle.None;
            txtID.BackColor      = UITheme.Card;
            txtID.ForeColor      = UITheme.TextPrimary;
            txtID.Font           = new Font("Segoe UI", 14F);
            txtID.Size           = new Size(380, 32);
            txtID.Location       = new Point(50, 224);
            txtID.PlaceholderText = "Enter your ID...";

            lineId.BackColor = UITheme.Accent;
            lineId.Size      = new Size(380, 2);
            lineId.Location  = new Point(50, 258);

            // ── Password field ────────────────────────────────────────────────
            lblPwHint.Text      = "PASSWORD";
            lblPwHint.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPwHint.ForeColor = UITheme.Accent;
            lblPwHint.AutoSize  = true;
            lblPwHint.Location  = new Point(50, 280);
            lblPwHint.BackColor = System.Drawing.Color.Transparent;

            txtPassword.BorderStyle    = BorderStyle.None;
            txtPassword.BackColor      = UITheme.Card;
            txtPassword.ForeColor      = UITheme.TextPrimary;
            txtPassword.Font           = new Font("Segoe UI", 14F);
            txtPassword.Size           = new Size(380, 32);
            txtPassword.Location       = new Point(50, 304);
            txtPassword.PasswordChar   = '●';
            txtPassword.PlaceholderText = "Enter password...";

            linePw.BackColor = System.Drawing.Color.FromArgb(60, UITheme.Accent);
            linePw.Size      = new Size(380, 2);
            linePw.Location  = new Point(50, 338);

            // Focus events: highlight active field line
            txtID.Enter       += (s, e) => { lineId.BackColor = UITheme.Accent; linePw.BackColor = System.Drawing.Color.FromArgb(60, UITheme.Accent); };
            txtPassword.Enter += (s, e) => { linePw.BackColor = UITheme.Accent; lineId.BackColor = System.Drawing.Color.FromArgb(60, UITheme.Accent); };

            // ── Error label ───────────────────────────────────────────────────
            lblError.AutoSize  = false;
            lblError.Size      = new Size(380, 22);
            lblError.Location  = new Point(50, 348);
            lblError.Font      = UITheme.FontSmall;
            lblError.ForeColor = UITheme.Danger;
            lblError.BackColor = System.Drawing.Color.Transparent;
            lblError.Visible   = false;

            // ── LOGIN button ──────────────────────────────────────────────────
            btnLogin.Size     = new Size(380, 50);
            btnLogin.Location = new Point(50, 380);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = System.Drawing.Color.Transparent;
            btnLogin.Cursor   = Cursors.Hand;
            btnLogin.Text     = "";
            btnLogin.Paint    += btnLogin_Paint;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            btnLogin.Click    += btnLogin_Click;

            // ── Bottom row: EXIT | Sign Up ────────────────────────────────────
            btnExit.Text      = "EXIT";
            btnExit.Size      = new Size(80, 30);
            btnExit.Location  = new Point(50, 448);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(20, UITheme.Danger);
            btnExit.BackColor = System.Drawing.Color.Transparent;
            btnExit.ForeColor = UITheme.TextSecondary;
            btnExit.Font      = UITheme.FontSmall;
            btnExit.Cursor    = Cursors.Hand;
            btnExit.Click    += btnExit_Click;

            btnSignUp.Text    = "New here?  Sign Up →";
            btnSignUp.AutoSize = true;
            btnSignUp.Location = new Point(150, 450);
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnSignUp.BackColor = System.Drawing.Color.Transparent;
            btnSignUp.ForeColor = UITheme.Accent;
            btnSignUp.Font      = UITheme.FontBold;
            btnSignUp.Cursor   = Cursors.Hand;
            btnSignUp.Click   += btnSignUp_Click;

            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ── Left panel branding paint ─────────────────────────────────────────
        private void PanelLeft_Paint(object? sender, System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int W = panelLeft.Width, H = panelLeft.Height;

            // Gradient background
            using var bg = new LinearGradientBrush(new Rectangle(0, 0, W, H),
                UITheme.HeaderGrad2, System.Drawing.Color.FromArgb(8, 22, 60),
                LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(bg, 0, 0, W, H);

            // Decorative circles
            DrawCircle(g, -40, -40, 200, 20);
            DrawCircle(g, W - 60, H - 80, 240, 15);
            DrawCircle(g, W / 2 - 30, H / 2 + 60, 120, 12);

            // Thin right border glow
            using var glow = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(W - 3, 0, 3, H),
                System.Drawing.Color.FromArgb(0, UITheme.Accent),
                UITheme.Accent,
                LinearGradientMode.Vertical);
            g.FillRectangle(glow, W - 3, 0, 3, H);

            // Logo icon area
            using var iconFont  = new Font("Segoe UI Emoji", 42F);
            g.DrawString("💼", iconFont, new SolidBrush(System.Drawing.Color.White), 30, H / 2 - 170);

            // EMS PRO title
            using var titleFont = new Font("Segoe UI", 28F, FontStyle.Bold);
            g.DrawString("EMS PRO", titleFont, new SolidBrush(System.Drawing.Color.White), 30, H / 2 - 100);

            // Accent underline
            using var accentPen = new Pen(UITheme.Accent, 3);
            g.DrawLine(accentPen, 30, H / 2 - 52, 160, H / 2 - 52);

            // Tagline
            using var tagFont = new Font("Segoe UI", 11F);
            g.DrawString("Employee Management System", tagFont,
                new SolidBrush(System.Drawing.Color.FromArgb(180, 255, 255, 255)), 30, H / 2 - 38);

            // Info pills
            DrawInfoPill(g, 30, H / 2 + 20, "✦  Role-based Access");
            DrawInfoPill(g, 30, H / 2 + 58, "✦  Real-time Analytics");
            DrawInfoPill(g, 30, H / 2 + 96, "✦  Smart Notifications");

            // Version
            using var verFont = new Font("Segoe UI", 8F);
            g.DrawString("v2.0  ·  EMS Pro", verFont, new SolidBrush(System.Drawing.Color.FromArgb(80, 255, 255, 255)), 30, H - 28);
        }

        private static void DrawCircle(Graphics g, int x, int y, int d, int alpha)
        {
            using var br = new SolidBrush(System.Drawing.Color.FromArgb(alpha, 255, 255, 255));
            using var pen = new Pen(System.Drawing.Color.FromArgb(alpha + 10, 255, 255, 255), 1.5f);
            g.DrawEllipse(pen, x, y, d, d);
        }

        private static void DrawInfoPill(Graphics g, int x, int y, string text)
        {
            using var font = new Font("Segoe UI", 9F);
            using var br   = new SolidBrush(System.Drawing.Color.FromArgb(160, 255, 255, 255));
            g.DrawString(text, font, br, x, y);
        }

        // P/Invoke for borderless form drag
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(nint hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private Panel  panelLeft, panelRight;
        private Panel  lineId, linePw;
        private Label  lblWelcome, lblSubRight, lblClock, lblIdHint, lblPwHint, lblError;
        private TextBox txtID, txtPassword;
        private Button btnLogin, btnExit, btnSignUp;
    }
}
