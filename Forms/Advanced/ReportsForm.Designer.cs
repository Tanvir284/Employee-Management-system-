using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader      = new Panel();
            lblTitle         = new Label();
            btnBack          = new Button();
            panelButtons     = new Panel();
            btnEmployee      = new Button();
            btnAttendance    = new Button();
            btnPayroll       = new Button();
            btnLeave         = new Button();
            btnPerformance   = new Button();
            btnExport        = new Button();
            lblPreviewTitle  = new Label();
            dgvPreview       = new DataGridView();

            panelHeader.SuspendLayout(); panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(950, 640);
            Text = "Reports & Export";
            BackColor = UITheme.BackDark;
            Controls.Add(panelHeader); Controls.Add(panelButtons); Controls.Add(lblPreviewTitle); Controls.Add(dgvPreview);
            Load += ReportsForm_Load;

            // Header
            panelHeader.Dock = DockStyle.Top; panelHeader.Height = 55; panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack);
            lblTitle.Text = "📊  Reports & CSV Export"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White; lblTitle.AutoSize = true; lblTitle.Location = new System.Drawing.Point(120, 14);
            btnBack.Text = "◀ Dashboard"; btnBack.Location = new System.Drawing.Point(10, 13); btnBack.Size = new System.Drawing.Size(100, 30);
            btnBack.FlatStyle = FlatStyle.Flat; btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnBack.ForeColor = System.Drawing.Color.White; btnBack.BackColor = System.Drawing.Color.Transparent; btnBack.Font = UITheme.FontBold; btnBack.Click += btnBack_Click;

            // Button panel
            panelButtons.BackColor = UITheme.Card; panelButtons.Location = new System.Drawing.Point(0, 55);
            panelButtons.Size = new System.Drawing.Size(950, 80);
            panelButtons.Controls.Add(btnEmployee); panelButtons.Controls.Add(btnAttendance);
            panelButtons.Controls.Add(btnPayroll); panelButtons.Controls.Add(btnLeave);
            panelButtons.Controls.Add(btnPerformance); panelButtons.Controls.Add(btnExport);

            void Btn(Button b, string t, int x) { b.Text=t; b.Location=new System.Drawing.Point(x,18); b.Size=new System.Drawing.Size(135,42); }
            Btn(btnEmployee,   "👥 Employees",    15);
            Btn(btnAttendance, "📅 Attendance",  160);
            Btn(btnPayroll,    "💼 Payroll",       305);
            Btn(btnLeave,      "🏖️ Leaves",        450);
            Btn(btnPerformance,"⭐ Performance",   595);

            btnEmployee.Click   += btnEmployee_Click;
            btnAttendance.Click += btnAttendance_Click;
            btnPayroll.Click    += btnPayroll_Click;
            btnLeave.Click      += btnLeave_Click;
            btnPerformance.Click+= btnPerformance_Click;

            btnExport.Text = "⬇ Export CSV"; btnExport.Location = new System.Drawing.Point(800, 18); btnExport.Size = new System.Drawing.Size(135, 42);
            btnExport.FlatStyle = FlatStyle.Flat; btnExport.Font = UITheme.FontBold;
            btnExport.FlatAppearance.BorderColor = UITheme.Gold; btnExport.ForeColor = UITheme.Gold; btnExport.BackColor = UITheme.NavActive;
            btnExport.Enabled = false; btnExport.Click += btnExport_Click;

            lblPreviewTitle.Text = "Select a report above to preview data";
            lblPreviewTitle.Font = UITheme.FontBold; lblPreviewTitle.ForeColor = UITheme.TextSecondary;
            lblPreviewTitle.AutoSize = false; lblPreviewTitle.Size = new System.Drawing.Size(950, 26);
            lblPreviewTitle.Location = new System.Drawing.Point(0, 140); lblPreviewTitle.Padding = new Padding(10, 0, 0, 0);
            lblPreviewTitle.BackColor = UITheme.BackDark;

            dgvPreview.Location = new System.Drawing.Point(0, 168); dgvPreview.Size = new System.Drawing.Size(950, 472);
            dgvPreview.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            UITheme.StyleDataGrid(dgvPreview);

            panelHeader.ResumeLayout(false); panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
        }

        private Panel panelHeader, panelButtons;
        private Label lblTitle, lblPreviewTitle;
        private Button btnEmployee, btnAttendance, btnPayroll, btnLeave, btnPerformance, btnExport, btnBack;
        private DataGridView dgvPreview;
    }
}
