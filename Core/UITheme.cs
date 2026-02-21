using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    /// <summary>
    /// Central UI theme engine for the premium dark design system.
    /// Call UITheme.ApplyThemeToForm(this) from any Form's Load to fully restyle it.
    /// </summary>
    public static class UITheme
    {
        // ── Color Palette ─────────────────────────────────────────────────────
        public static readonly Color BackDark       = Color.FromArgb(15, 25, 35);
        public static readonly Color Sidebar        = Color.FromArgb(10, 22, 40);
        public static readonly Color Card           = Color.FromArgb(22, 32, 48);
        public static readonly Color CardHover      = Color.FromArgb(28, 42, 62);
        public static readonly Color HeaderGrad1    = Color.FromArgb(21, 101, 192);
        public static readonly Color HeaderGrad2    = Color.FromArgb(13, 71, 161);
        public static readonly Color Accent         = Color.FromArgb(0, 212, 255);
        public static readonly Color AccentDark     = Color.FromArgb(0, 150, 200);
        public static readonly Color Gold           = Color.FromArgb(255, 215, 0);
        public static readonly Color Success        = Color.FromArgb(76, 175, 80);
        public static readonly Color Danger         = Color.FromArgb(244, 67, 54);
        public static readonly Color Warning        = Color.FromArgb(255, 152, 0);
        public static readonly Color Purple         = Color.FromArgb(156, 39, 176);
        public static readonly Color Teal           = Color.FromArgb(0, 188, 212);
        public static readonly Color TextPrimary    = Color.White;
        public static readonly Color TextSecondary  = Color.FromArgb(144, 164, 174);
        public static readonly Color Border         = Color.FromArgb(30, 50, 70);
        public static readonly Color InputBg        = Color.FromArgb(50, 65, 85);
        public static readonly Color NavActive      = Color.FromArgb(0, 40, 70);
        public static readonly Color NavHover       = Color.FromArgb(20, 36, 56);

        // ── Fonts ─────────────────────────────────────────────────────────────
        public static readonly Font FontTitle    = new Font("Segoe UI", 22F, FontStyle.Bold);
        public static readonly Font FontHeading  = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontBody     = new Font("Segoe UI", 10F);
        public static readonly Font FontBold     = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font FontKPI      = new Font("Segoe UI", 26F, FontStyle.Bold);
        public static readonly Font FontSmall    = new Font("Segoe UI", 8F);
        public static readonly Font FontNav      = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontMono     = new Font("Consolas", 10F);

        // ── DataGrid Dark Style ───────────────────────────────────────────────
        public static void StyleDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Card;
            dgv.GridColor = Border;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.DefaultCellStyle.BackColor = Card;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = FontBody;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 100, 140);
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(18, 28, 44);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Sidebar;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Accent;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 32;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ── Gradient Header Paint ─────────────────────────────────────────────
        public static void PaintGradientHeader(PaintEventArgs e, Rectangle r)
        {
            using var brush = new LinearGradientBrush(r, HeaderGrad1, HeaderGrad2, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, r);
        }

        // ── Rounded Rectangle Path ────────────────────────────────────────────
        public static GraphicsPath RoundedPath(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ── KPI Card Paint ────────────────────────────────────────────────────
        public static void PaintKPICard(PaintEventArgs e, Rectangle r, string icon, string number, string label, Color accent)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // Card bg
            using var bgPath = RoundedPath(r, 12);
            using var bgBrush = new SolidBrush(Card);
            g.FillPath(bgBrush, bgPath);
            // Top accent bar
            var topBar = new Rectangle(r.X, r.Y, r.Width, 4);
            using var topPath = new GraphicsPath();
            topPath.AddArc(r.X, r.Y, 24, 24, 180, 90);
            topPath.AddArc(r.Right - 24, r.Y, 24, 24, 270, 90);
            topPath.AddLine(r.Right, r.Y + 4, r.X, r.Y + 4);
            topPath.CloseFigure();
            using var topBrush = new SolidBrush(accent);
            g.FillPath(topBrush, topPath);
            // Icon
            using var iconFont = new Font("Segoe UI Emoji", 22F);
            g.DrawString(icon, iconFont, new SolidBrush(accent), r.X + 14, r.Y + 18);
            // Number
            using var numFont = new Font("Segoe UI", 22F, FontStyle.Bold);
            g.DrawString(number, numFont, new SolidBrush(Gold), r.X + 14, r.Y + 50);
            // Label
            using var lblFont = new Font("Segoe UI", 8F);
            g.DrawString(label, lblFont, new SolidBrush(TextSecondary), r.X + 14, r.Y + 85);
        }

        // ── Flat Dark Button ──────────────────────────────────────────────────
        public static void StyleFlatButton(Button btn, Color? accent = null)
        {
            var c = accent ?? Accent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = c;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, c.R, c.G, c.B);
            btn.BackColor = Color.FromArgb(10, c.R, c.G, c.B);
            btn.ForeColor = c;
            btn.Font = FontBold;
            btn.Cursor = Cursors.Hand;
        }

        // ─────────────────────────────────────────────────────────────────────
        // ── ApplyThemeToForm + MakeResponsive ────────────────────────────────
        // Call UITheme.ApplyThemeToForm(this) from any form constructor.
        // ─────────────────────────────────────────────────────────────────────
        public static void ApplyThemeToForm(Form form)
        {
            form.BackColor = BackDark;
            form.ForeColor = TextPrimary;
            Employeemanagment.Core.SessionManager.ApplyRBAC(form); // Apply RBAC globally
            RecursiveStyle(form.Controls);
            MakeResponsive(form);           // ← always apply layout too
        }

        // ── Responsive Layout Engine ──────────────────────────────────────────
        public static void MakeResponsive(Form form)
        {
            form.MinimumSize   = new Size(720, 500);
            form.FormBorderStyle = FormBorderStyle.Sizable;
            ApplyResponsiveLayout(form.Controls, form.Width, form.Height);
        }

        private static void ApplyResponsiveLayout(Control.ControlCollection controls,
                                                   int parentW, int parentH)
        {
            foreach (Control ctrl in controls)
            {
                // Skip controls that are already properly docked
                if (ctrl.Dock == DockStyle.Fill  ||
                    ctrl.Dock == DockStyle.Bottom ||
                    ctrl.Dock == DockStyle.Left   ||
                    ctrl.Dock == DockStyle.Right)
                    continue;

                // Compute fractions relative to parent
                double wFrac = parentW > 0 ? (double)ctrl.Width  / parentW : 0;
                double hFrac = parentH > 0 ? (double)ctrl.Height / parentH : 0;
                bool   isWide = wFrac > 0.55;
                bool   isTall = hFrac > 0.30;

                switch (ctrl)
                {
                    // DataGridViews: always stretch to fill remaining space
                    case DataGridView dgv:
                        dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                   | AnchorStyles.Right | AnchorStyles.Bottom;
                        break;

                    // TabControls: fill available space below the header
                    case TabControl tc:
                        tc.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                  | AnchorStyles.Right | AnchorStyles.Bottom;
                        foreach (TabPage tp in tc.TabPages)
                            ApplyResponsiveLayout(tp.Controls, tp.Width, tp.Height);
                        break;

                    // Panels with DockStyle.Top stay as-is
                    case Panel p when p.Dock == DockStyle.Top:
                        break;

                    // Wide + tall panels (main content area) → all four
                    case Panel p when isWide && isTall:
                        p.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                 | AnchorStyles.Right | AnchorStyles.Bottom;
                        ApplyResponsiveLayout(p.Controls, p.Width, p.Height);
                        break;

                    // Wide-only panels (input bars) → stretch width
                    case Panel p when isWide:
                        p.Anchor = AnchorStyles.Top | AnchorStyles.Left
                                 | AnchorStyles.Right;
                        ApplyResponsiveLayout(p.Controls, p.Width, p.Height);
                        break;

                    // TextBoxes (multi-line) → stretch width
                    case TextBox tb when tb.Multiline:
                        tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        break;

                    // Labels that span full width → anchor left+right
                    case Label lbl when isWide:
                        lbl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        break;

                    default:
                        // Recurse into any other containers
                        if (ctrl.HasChildren)
                            ApplyResponsiveLayout(ctrl.Controls, ctrl.Width, ctrl.Height);
                        break;
                }
            }
        }

        private static bool IsHeaderPanel(Panel p)
            => p.BackColor == Color.Brown
            || p.BackColor == Color.SaddleBrown
            || p.BackColor == Color.FromArgb(128, 0, 0); // maroon

        private static void RecursiveStyle(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                switch (ctrl)
                {
                    // ── Panels ────────────────────────────────────────────────
                    case Panel pnl when IsHeaderPanel(pnl):
                        // ▸ Convert brown header → blue gradient header
                        pnl.BackColor = HeaderGrad1;
                        pnl.Paint -= OnHeaderPaint;
                        pnl.Paint += OnHeaderPaint;
                        // Style children inline (buttons → white ghost, labels → white)
                        foreach (Control hc in pnl.Controls)
                        {
                            if (hc is Label hl) { hl.ForeColor = Color.White; hl.BackColor = Color.Transparent; }
                            if (hc is Button hb)
                            {
                                hb.FlatStyle = FlatStyle.Flat;
                                hb.FlatAppearance.BorderColor = Color.FromArgb(120, 255, 255, 255);
                                hb.FlatAppearance.BorderSize = 1;
                                hb.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
                                hb.BackColor = Color.Transparent;
                                hb.ForeColor = Color.White;
                                hb.Font = FontBold;
                                hb.Cursor = Cursors.Hand;
                            }
                        }
                        // Don't recurse — we handled children above
                        break;

                    case Panel pnl:
                        // ▸ Card panel
                        pnl.BackColor = Card;
                        pnl.BorderStyle = BorderStyle.None;
                        RecursiveStyle(pnl.Controls);
                        break;

                    // ── TabControl ────────────────────────────────────────────
                    case TabControl tc:
                        tc.Appearance = TabAppearance.Normal;
                        foreach (TabPage tp in tc.TabPages)
                        {
                            tp.BackColor = Card;
                            tp.ForeColor = TextPrimary;
                            RecursiveStyle(tp.Controls);
                        }
                        break;

                    // ── DataGridView ──────────────────────────────────────────
                    case DataGridView dgv:
                        StyleDataGrid(dgv);
                        break;

                    // ── Labels ────────────────────────────────────────────────
                    case Label lbl:
                        lbl.BackColor = Color.Transparent;
                        bool isDarkLabel = lbl.ForeColor == Color.Brown
                                        || lbl.ForeColor == Color.SaddleBrown
                                        || lbl.ForeColor == Color.DarkSlateGray
                                        || lbl.ForeColor == Color.Black;
                        lbl.ForeColor = isDarkLabel ? TextSecondary : lbl.ForeColor;
                        break;

                    // ── Buttons ────────────────────────────────────────────────
                    case Button btn:
                        Color accent;
                        var bg = btn.BackColor;
                        if (bg == Color.DarkRed || bg == Color.Red || bg == Color.Crimson)
                            accent = Danger;
                        else if (bg == Color.DarkGreen || bg == Color.Green || bg == Color.ForestGreen)
                            accent = Success;
                        else if (bg == Color.DarkOrange || bg == Color.Orange)
                            accent = Warning;
                        else
                            accent = Accent;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = accent;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, accent.R, accent.G, accent.B);
                        btn.BackColor = Color.FromArgb(12, accent.R, accent.G, accent.B);
                        btn.ForeColor = accent;
                        btn.Font = FontBold;
                        btn.Cursor = Cursors.Hand;
                        break;

                    // ── TextBox ───────────────────────────────────────────────
                    case TextBox tb:
                        tb.BackColor = InputBg;
                        tb.ForeColor = TextPrimary;
                        tb.BorderStyle = BorderStyle.FixedSingle;
                        tb.Font = FontBody;
                        break;

                    // ── RichTextBox ───────────────────────────────────────────
                    case RichTextBox rtb:
                        rtb.BackColor = InputBg;
                        rtb.ForeColor = TextPrimary;
                        rtb.BorderStyle = BorderStyle.FixedSingle;
                        rtb.Font = FontBody;
                        break;

                    // ── ComboBox ──────────────────────────────────────────────
                    case ComboBox cmb:
                        cmb.BackColor = InputBg;
                        cmb.ForeColor = TextPrimary;
                        cmb.FlatStyle = FlatStyle.Popup; // Fixes white dropdown button artifact in dark mode
                        cmb.Font = FontBody;
                        break;

                    // ── NumericUpDown ─────────────────────────────────────────
                    case NumericUpDown nud:
                        nud.BackColor = InputBg;
                        nud.ForeColor = TextPrimary;
                        nud.BorderStyle = BorderStyle.FixedSingle;
                        nud.Font = FontBody;
                        break;

                    // ── DateTimePicker ────────────────────────────────────────
                    case DateTimePicker dtp:
                        dtp.CalendarMonthBackground = BackDark;
                        dtp.CalendarForeColor    = TextPrimary;
                        dtp.CalendarTitleBackColor  = HeaderGrad1;
                        dtp.CalendarTitleForeColor  = Color.White;
                        dtp.CalendarTrailingForeColor = TextSecondary;
                        dtp.Font = FontBody;
                        break;

                    // ── GroupBox ──────────────────────────────────────────────
                    case GroupBox gb:
                        gb.ForeColor = TextSecondary;
                        gb.BackColor = Card;
                        RecursiveStyle(gb.Controls);
                        break;
                }

                // General recursion for other container types
                if (ctrl is not Panel && ctrl is not TabControl
                    && ctrl is not GroupBox && ctrl.HasChildren)
                    RecursiveStyle(ctrl.Controls);
            }
        }

        // ── Header gradient paint handler (used by ApplyThemeToForm) ─────────
        private static void OnHeaderPaint(object? sender, PaintEventArgs e)
        {
            if (sender is Control c && c.Width > 0 && c.Height > 0)
            {
                var r = new Rectangle(0, 0, c.Width, c.Height);
                using var brush = new LinearGradientBrush(r, HeaderGrad1, HeaderGrad2, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, r);
                using var pen = new Pen(Color.FromArgb(30, Accent), 1);
                e.Graphics.DrawLine(pen, 0, c.Height - 1, c.Width, c.Height - 1);
            }
        }

        // ── Section Header Label ──────────────────────────────────────────────
        public static Label CreateSectionLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = TextSecondary,
                AutoSize = false, Height = 28, Dock = DockStyle.Top,
                TextAlign = ContentAlignment.BottomLeft,
                Padding = new Padding(14, 0, 0, 4)
            };
        }

        // ── Sidebar Nav Button ────────────────────────────────────────────────
        public static Button CreateNavButton(string icon, string title)
        {
            var btn = new Button
            {
                Text = $"  {icon}  {title}",
                Dock = DockStyle.Top, Height = 46,
                FlatStyle = FlatStyle.Flat, BackColor = Sidebar, ForeColor = TextSecondary,
                Font = FontNav, TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand, Padding = new Padding(10, 0, 0, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = NavHover;
            btn.MouseEnter += (s, e) => btn.ForeColor = TextPrimary;
            btn.MouseLeave += (s, e) => { if (btn.Tag?.ToString() != "active") btn.ForeColor = TextSecondary; };
            return btn;
        }

        // ── Activate Nav Button ───────────────────────────────────────────────
        public static void ActivateNav(Button btn, Control sidebar)
        {
            foreach (Control c in sidebar.Controls)
                if (c is Button b) { b.BackColor = Sidebar; b.ForeColor = TextSecondary; b.Tag = null; }
            btn.BackColor = NavActive; btn.ForeColor = Accent; btn.Tag = "active";
        }
    }
}
