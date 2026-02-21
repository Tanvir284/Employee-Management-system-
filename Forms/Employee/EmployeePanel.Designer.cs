using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class EmployeePanel
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader     = new Panel();
            lblWelcome      = new Label();
            btnLogout       = new Button();
            tabMain         = new TabControl();
            tabProfile      = new TabPage();
            tabAttendance   = new TabPage();
            tabLeave        = new TabPage();
            tabPayslip      = new TabPage();
            tabPerformance  = new TabPage();

            // Profile labels
            lblName = new Label(); lblAge = new Label(); lblEmail = new Label();
            lblSalary = new Label(); lblPhone = new Label(); lblShift = new Label();
            lblGender = new Label(); lblJoin = new Label();

            // Attendance tab
            btnMarkAttendance = new Button(); dgvAttendance = new DataGridView();

            // Leave tab
            cmbLeaveType = new ComboBox(); dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker(); btnSubmitLeave = new Button();
            dgvLeaves = new DataGridView();

            // Payslip + Performance tabs
            dgvPayslips = new DataGridView(); dgvPerformance = new DataGridView();

            panelHeader.SuspendLayout();
            tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayslips).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerformance).BeginInit();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1050, 680);
            MinimumSize = new System.Drawing.Size(820, 550);
            Text = "EMS Pro — Employee Panel";
            BackColor = UITheme.BackDark;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.Add(tabMain); Controls.Add(panelHeader);
            Load += EmployeePanel_Load;

            // ── Header bar ────────────────────────────────────────────────────
            panelHeader.Dock = DockStyle.Top; panelHeader.Height = 58;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Controls.Add(lblWelcome); panelHeader.Controls.Add(btnLogout);

            lblWelcome.Text = "👤  Employee Panel"; lblWelcome.Font = new Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.White; lblWelcome.AutoSize = true; lblWelcome.Location = new System.Drawing.Point(14, 16);

            btnLogout.Text = "⬅ Logout"; btnLogout.Size = new System.Drawing.Size(100, 30);
            btnLogout.Location = new System.Drawing.Point(930, 14); btnLogout.Font = UITheme.FontBold;
            btnLogout.FlatStyle = FlatStyle.Flat; btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnLogout.BackColor = System.Drawing.Color.Transparent; btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right; btnLogout.Click += btnLogout_Click;

            // ── TabControl ────────────────────────────────────────────────────
            tabMain.Dock = DockStyle.Fill;
            tabMain.BackColor = UITheme.BackDark;
            tabMain.Font = UITheme.FontBold;
            tabMain.TabPages.Add(tabProfile); tabMain.TabPages.Add(tabAttendance);
            tabMain.TabPages.Add(tabLeave); tabMain.TabPages.Add(tabPayslip);
            tabMain.TabPages.Add(tabPerformance);

            // ── Tab: My Profile ───────────────────────────────────────────────
            tabProfile.Text = "👤 My Profile"; tabProfile.BackColor = UITheme.BackDark; tabProfile.Padding = new System.Windows.Forms.Padding(20);
            void ProfileLabel(Label l, int y) { l.Font = UITheme.FontBold; l.ForeColor = System.Drawing.Color.White; l.AutoSize = true; l.Location = new System.Drawing.Point(30, y); tabProfile.Controls.Add(l); }
            ProfileLabel(lblName,    30);  ProfileLabel(lblAge,    75);
            ProfileLabel(lblEmail,  120);  ProfileLabel(lblSalary, 165);
            ProfileLabel(lblPhone,  210);  ProfileLabel(lblShift,  255);
            ProfileLabel(lblGender, 300);  ProfileLabel(lblJoin,   345);
            lblName.Text="Loading...";

            // ── Tab: Attendance ───────────────────────────────────────────────
            tabAttendance.Text = "📅 Attendance"; tabAttendance.BackColor = UITheme.BackDark;
            btnMarkAttendance.Text = "✔ Mark Present Today"; btnMarkAttendance.Size = new System.Drawing.Size(200, 38);
            btnMarkAttendance.Location = new System.Drawing.Point(15, 15);
            btnMarkAttendance.Font = UITheme.FontBold; btnMarkAttendance.FlatStyle = FlatStyle.Flat;
            btnMarkAttendance.FlatAppearance.BorderColor = UITheme.Success;
            btnMarkAttendance.BackColor = System.Drawing.Color.FromArgb(15, UITheme.Success);
            btnMarkAttendance.ForeColor = UITheme.Success; btnMarkAttendance.Cursor = Cursors.Hand;
            btnMarkAttendance.Click += btnMarkAttendance_Click;
            dgvAttendance.Location = new System.Drawing.Point(0, 65);
            dgvAttendance.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            dgvAttendance.Size = new System.Drawing.Size(1000, 520);
            tabAttendance.Controls.Add(btnMarkAttendance); tabAttendance.Controls.Add(dgvAttendance);

            // ── Tab: Leave ────────────────────────────────────────────────────
            tabLeave.Text = "🏖 Leave"; tabLeave.BackColor = UITheme.BackDark;
            var panLeaveInput = new Panel { Location=new System.Drawing.Point(0,0), Size=new System.Drawing.Size(1000,80), BackColor=UITheme.Card };
            void LeaveLabel(Label l2, string t, int x) { l2.Text=t; l2.Font=UITheme.FontSmall; l2.ForeColor=UITheme.TextSecondary; l2.AutoSize=true; l2.Location=new System.Drawing.Point(x,8); panLeaveInput.Controls.Add(l2); }
            var ll1=new Label(); LeaveLabel(ll1,"Leave Type",15);
            cmbLeaveType.Location = new System.Drawing.Point(15, 28); cmbLeaveType.Size = new System.Drawing.Size(130,28);
            cmbLeaveType.DropDownStyle = ComboBoxStyle.DropDownList; cmbLeaveType.Font = UITheme.FontBody;
            cmbLeaveType.Items.AddRange(new[]{"Annual","Medical","Maternity","Emergency","Unpaid"});
            var ll2=new Label(); LeaveLabel(ll2,"Start Date",165);
            dtpStart.Location=new System.Drawing.Point(165,28); dtpStart.Size=new System.Drawing.Size(130,28); dtpStart.Font=UITheme.FontBody;
            var ll3=new Label(); LeaveLabel(ll3,"End Date",310);
            dtpEnd.Location=new System.Drawing.Point(310,28); dtpEnd.Size=new System.Drawing.Size(130,28); dtpEnd.Font=UITheme.FontBody;
            btnSubmitLeave.Text="➜ Submit Request"; btnSubmitLeave.Size=new System.Drawing.Size(160,36);
            btnSubmitLeave.Location=new System.Drawing.Point(460,22); btnSubmitLeave.Font=UITheme.FontBold; btnSubmitLeave.FlatStyle=FlatStyle.Flat;
            btnSubmitLeave.FlatAppearance.BorderColor=UITheme.Warning; btnSubmitLeave.BackColor=System.Drawing.Color.FromArgb(15,UITheme.Warning);
            btnSubmitLeave.ForeColor=UITheme.Warning; btnSubmitLeave.Cursor=Cursors.Hand; btnSubmitLeave.Click+=btnSubmitLeave_Click;
            panLeaveInput.Controls.Add(cmbLeaveType); panLeaveInput.Controls.Add(dtpStart); panLeaveInput.Controls.Add(dtpEnd); panLeaveInput.Controls.Add(btnSubmitLeave);
            dgvLeaves.Location=new System.Drawing.Point(0,82); dgvLeaves.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom; dgvLeaves.Size=new System.Drawing.Size(1000,480);
            tabLeave.Controls.Add(panLeaveInput); tabLeave.Controls.Add(dgvLeaves);

            // ── Tab: Payslip ─────────────────────────────────────────────────
            tabPayslip.Text = "💼 Payslips"; tabPayslip.BackColor = UITheme.BackDark;
            dgvPayslips.Dock = DockStyle.Fill;
            tabPayslip.Controls.Add(dgvPayslips);

            // ── Tab: Performance ──────────────────────────────────────────────
            tabPerformance.Text = "⭐ Performance"; tabPerformance.BackColor = UITheme.BackDark;
            dgvPerformance.Dock = DockStyle.Fill;
            tabPerformance.Controls.Add(dgvPerformance);

            // Style all grids
            UITheme.StyleDataGrid(dgvAttendance);
            UITheme.StyleDataGrid(dgvLeaves);
            UITheme.StyleDataGrid(dgvPayslips);
            UITheme.StyleDataGrid(dgvPerformance);

            panelHeader.ResumeLayout(false);
            tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLeaves).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayslips).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerformance).EndInit();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblWelcome, lblName, lblAge, lblEmail, lblSalary, lblPhone, lblShift, lblGender, lblJoin;
        private Button btnLogout, btnMarkAttendance, btnSubmitLeave;
        private TabControl tabMain;
        private TabPage tabProfile, tabAttendance, tabLeave, tabPayslip, tabPerformance;
        private DataGridView dgvAttendance, dgvLeaves, dgvPayslips, dgvPerformance;
        private ComboBox cmbLeaveType;
        private DateTimePicker dtpStart, dtpEnd;
    }
}
