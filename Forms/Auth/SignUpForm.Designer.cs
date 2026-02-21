using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            // Card panel (all controls live inside here)
            panelCard       = new Panel();
            lblTitle        = new Label();
            lblSub          = new Label();
            panelDivider    = new Panel();

            // Field labels
            lblFN   = new Label(); lblID   = new Label();
            lblEm   = new Label(); lblPw   = new Label();
            lblCf   = new Label(); lblRl   = new Label();

            // Input fields with underline panels
            txtFullName = MakeField(); txtId       = MakeField();
            txtEmail    = MakeField(); txtPassword = MakeField(); txtPassword.PasswordChar = '●';
            txtConfirm  = MakeField(); txtConfirm.PasswordChar  = '●';

            lineFN  = MakeLine(); lineID  = MakeLine();
            lineEm  = MakeLine(); linePw  = MakeLine();
            lineCf  = MakeLine();

            // Role combo
            cmbRole = new ComboBox();

            // Buttons
            btnSignUp = new Button();
            btnBack   = new Button();

            panelCard.SuspendLayout();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize  = new Size(900, 620);
            MinimumSize = new Size(760, 560);
            Text = "EMS Pro — Create Account";
            FormBorderStyle = FormBorderStyle.Sizable;
            BackColor  = UITheme.BackDark;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            Controls.Add(panelCard);
            Load += SignUpForm_Load;

            // ── Card panel (centered, painted rounded+border) ─────────────────
            panelCard.Size = new Size(540, 500);
            panelCard.Location = new Point((900 - 540) / 2, (620 - 500) / 2);
            panelCard.BackColor = UITheme.Card;
            panelCard.Anchor = AnchorStyles.None;
            panelCard.Paint += (s, e) =>
            {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                var r = new Rectangle(0, 0, panelCard.Width - 1, panelCard.Height - 1);
                using var path  = UITheme.RoundedPath(r, 16);
                using var bgBr  = new SolidBrush(UITheme.Card);
                using var bPen  = new Pen(System.Drawing.Color.FromArgb(70, UITheme.Accent), 1.5f);
                g.FillPath(bgBr, path);
                g.DrawPath(bPen, path);
                // Accent top bar
                var topBar = new Rectangle(0, 0, panelCard.Width, 4);
                using var topBr = new LinearGradientBrush(topBar, UITheme.Accent, UITheme.HeaderGrad1, LinearGradientMode.Horizontal);
                g.FillRectangle(topBr, topBar);
            };

            // ── Title & subtitle inside card ───────────────────────────────────
            lblTitle.Text      = "Create Account";
            lblTitle.Font      = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = UITheme.Accent;
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(36, 24);
            lblTitle.BackColor = System.Drawing.Color.Transparent;

            lblSub.Text      = "Fill in the details below to register your account";
            lblSub.Font      = UITheme.FontSmall;
            lblSub.ForeColor = UITheme.TextSecondary;
            lblSub.AutoSize  = true;
            lblSub.Location  = new Point(36, 65);
            lblSub.BackColor = System.Drawing.Color.Transparent;

            panelDivider.BackColor = System.Drawing.Color.FromArgb(40, UITheme.Accent);
            panelDivider.Size      = new Size(468, 1);
            panelDivider.Location  = new Point(36, 90);

            // ── Helper positions: 2-column layout ─────────────────────────────
            // Col A: x=36, Col B: x=288  Field width: 216
            int fW = 216, fH = 30;
            int xA = 36, xB = 288;
            int[] rowY = { 110, 200, 290 }; // row Y starts (label), field = rowY+22

            // Row 0: Full Name | Role
            Place(lblFN, "Full Name",      xA, rowY[0]);
            PlaceField(txtFullName, lineFN, xA, rowY[0] + 22, fW, fH);
            Place(lblRl, "Role",           xB, rowY[0]);
            cmbRole.Location = new Point(xB, rowY[0] + 22); cmbRole.Size = new Size(fW, fH);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList; cmbRole.Font = UITheme.FontBody;
            cmbRole.BackColor = UITheme.BackDark; cmbRole.ForeColor = UITheme.TextPrimary;
            cmbRole.FlatStyle = FlatStyle.Flat;

            // Row 1: Employee ID | Email
            Place(lblID, "Employee ID",    xA, rowY[1]);
            PlaceField(txtId,       lineID, xA, rowY[1] + 22, fW, fH);
            Place(lblEm, "Email",          xB, rowY[1]);
            PlaceField(txtEmail,    lineEm, xB, rowY[1] + 22, fW, fH);

            // Row 2: Password | Confirm Password
            Place(lblPw, "Password",       xA, rowY[2]);
            PlaceField(txtPassword, linePw, xA, rowY[2] + 22, fW, fH);
            Place(lblCf, "Confirm Password", xB, rowY[2]);
            PlaceField(txtConfirm,  lineCf, xB, rowY[2] + 22, fW, fH);

            // ── Buttons ────────────────────────────────────────────────────────
            StylePrimaryBtn(btnSignUp, "  Create Account  →", xA, 395, 220);
            btnSignUp.Click += btnSignUp_Click;

            btnBack.Text = "← Back to Login";
            btnBack.Location = new Point(300, 408); btnBack.AutoSize = true;
            btnBack.FlatStyle = FlatStyle.Flat; btnBack.FlatAppearance.BorderSize = 0;
            btnBack.BackColor = System.Drawing.Color.Transparent;
            btnBack.ForeColor = UITheme.TextSecondary;
            btnBack.Font = UITheme.FontSmall; btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnBack.Click += btnBack_Click;

            // Add all controls to card
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblSub);
            panelCard.Controls.Add(panelDivider);
            panelCard.Controls.Add(lblFN); panelCard.Controls.Add(txtFullName); panelCard.Controls.Add(lineFN);
            panelCard.Controls.Add(lblRl); panelCard.Controls.Add(cmbRole);
            panelCard.Controls.Add(lblID); panelCard.Controls.Add(txtId);       panelCard.Controls.Add(lineID);
            panelCard.Controls.Add(lblEm); panelCard.Controls.Add(txtEmail);    panelCard.Controls.Add(lineEm);
            panelCard.Controls.Add(lblPw); panelCard.Controls.Add(txtPassword); panelCard.Controls.Add(linePw);
            panelCard.Controls.Add(lblCf); panelCard.Controls.Add(txtConfirm);  panelCard.Controls.Add(lineCf);
            panelCard.Controls.Add(btnSignUp); panelCard.Controls.Add(btnBack);

            panelCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private static TextBox MakeField()
        {
            return new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor   = UITheme.Card,
                ForeColor   = UITheme.TextPrimary,
                Font        = UITheme.FontBody
            };
        }
        private static Panel MakeLine()
        {
            return new Panel { BackColor = System.Drawing.Color.FromArgb(80, UITheme.Accent), Height = 1 };
        }
        private static void PlaceField(TextBox tb, Panel line, int x, int y, int w, int h)
        {
            tb.Location = new Point(x, y); tb.Size = new Size(w, h);
            line.Location = new Point(x, y + h); line.Size = new Size(w, 1);
        }
        private static void Place(Label l, string text, int x, int y)
        {
            l.Text = text; l.Font = UITheme.FontSmall;
            l.ForeColor = UITheme.TextSecondary; l.BackColor = System.Drawing.Color.Transparent;
            l.AutoSize = true; l.Location = new Point(x, y);
        }
        private static void StylePrimaryBtn(Button b, string text, int x, int y, int w)
        {
            b.Text = text; b.Size = new Size(w, 42); b.Location = new Point(x, y);
            b.Font = UITheme.FontBold; b.Cursor = Cursors.Hand;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = UITheme.Accent;
            b.FlatAppearance.BorderSize  = 1;
            b.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(35, UITheme.Accent);
            b.BackColor = System.Drawing.Color.FromArgb(18, UITheme.Accent);
            b.ForeColor = UITheme.Accent;
        }

        private Panel panelCard, panelDivider;
        private Panel lineFN, lineID, lineEm, linePw, lineCf;
        private Label lblTitle, lblSub, lblFN, lblID, lblEm, lblPw, lblCf, lblRl;
        private TextBox txtFullName, txtId, txtEmail, txtPassword, txtConfirm;
        private ComboBox cmbRole;
        private Button btnSignUp, btnBack;
    }
}
