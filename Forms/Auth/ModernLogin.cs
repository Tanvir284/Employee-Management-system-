using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class ModernLogin : Form
    {
        private bool _hovering = false;
        private System.Windows.Forms.Timer _clockTimer = new();
        private System.Windows.Forms.Timer _fadeTimer  = new();
        private int _opacity = 0;

        public ModernLogin()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void ModernLogin_Load(object sender, EventArgs e)
        {
            // Fade-in
            _fadeTimer.Interval = 15;
            _fadeTimer.Tick += (s, _) => {
                _opacity = Math.Min(100, _opacity + 5);
                Opacity  = _opacity / 100.0;
                if (_opacity >= 100) _fadeTimer.Stop();
            };
            _fadeTimer.Start();

            // Live clock
            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, _) => lblClock.Text = DateTime.Now.ToString("HH:mm:ss   dddd, MMM dd yyyy");
            _clockTimer.Start();
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss   dddd, MMM dd yyyy");

            txtID.Focus();
        }

        // ── Custom paint: LOGIN button (gradient pill) ────────────────────────
        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(0, 0, btnLogin.Width - 1, btnLogin.Height - 1);
            using var path  = UITheme.RoundedPath(r, 10);
            Color c1 = _hovering ? UITheme.Accent     : UITheme.HeaderGrad1;
            Color c2 = _hovering ? UITheme.AccentDark : UITheme.HeaderGrad2;
            using var brush = new LinearGradientBrush(r, c1, c2, LinearGradientMode.Horizontal);
            g.FillPath(brush, path);
            // Subtle inner glow on hover
            if (_hovering)
            {
                using var glow = new Pen(Color.FromArgb(60, UITheme.Accent), 2);
                g.DrawPath(glow, path);
            }
            using var font = new Font("Segoe UI", 13F, FontStyle.Bold);
            var text = "LOGIN";
            var sz   = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.White,
                (btnLogin.Width - sz.Width) / 2,
                (btnLogin.Height - sz.Height) / 2);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e) { _hovering = true;  btnLogin.Invalidate(); }
        private void btnLogin_MouseLeave(object sender, EventArgs e) { _hovering = false; btnLogin.Invalidate(); }
        private void btnLogin_Click(object sender, EventArgs e) => TryLogin();

        private void TryLogin()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            { ShowError("Please enter both ID and Password."); return; }

            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var user = System.Linq.Enumerable.FirstOrDefault(db.Logins, l => l.Id == txtID.Text.Trim());

                if (user != null && BCrypt.Net.BCrypt.Verify(txtPassword.Text.Trim(), user.Password))
                {
                    lblError.Visible = false;
                    string role     = user.Role ?? "Admin";
                    string fullname = user.FullName ?? "User";
                    string empId    = user.Id;

                    string name = string.IsNullOrEmpty(fullname) ? empId : fullname;
                    Employeemanagment.Core.SessionManager.InitializeSession(empId, role, name);

                    if (role.Equals("Employee", StringComparison.OrdinalIgnoreCase))
                    {
                        new EmployeePanel(empId, name).Show();
                    }
                    else
                    {
                        new MainDashboard().Show();
                    }
                    this.Hide();
                }
                else
                {
                    ShowError("Invalid ID or Password.");
                    txtPassword.Clear();
                    txtID.Focus();
                }
            }
            catch (Exception ex) { ShowError($"Connection error: {ex.Message}"); }
        }

        private void ShowError(string msg)
        {
            lblError.Text    = "⚠  " + msg;
            lblError.Visible = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) { TryLogin(); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Close button (X) on form border — since borderless, use Escape too
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
            base.OnKeyDown(e);
        }

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            new SignUpForm().Show();
            this.Hide();
        }
    }
}
