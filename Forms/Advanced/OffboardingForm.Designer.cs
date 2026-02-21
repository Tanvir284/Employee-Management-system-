namespace Employeemanagment
{
    partial class OffboardingForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();

            panelSearch = new System.Windows.Forms.Panel();
            lblEmpIDLbl = new System.Windows.Forms.Label();
            txtEmpID = new System.Windows.Forms.TextBox();
            btnFetch = new System.Windows.Forms.Button();

            panelEmpInfo = new System.Windows.Forms.Panel();
            lblInfoTitle = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            lblAge = new System.Windows.Forms.Label();
            lblEmail = new System.Windows.Forms.Label();
            lblJoinDate = new System.Windows.Forms.Label();
            lblDept = new System.Windows.Forms.Label();

            panelReason = new System.Windows.Forms.Panel();
            lblReason = new System.Windows.Forms.Label();
            txtReason = new System.Windows.Forms.TextBox();
            lblExitNotes = new System.Windows.Forms.Label();
            txtExitNotes = new System.Windows.Forms.TextBox();
            btnConfirm = new System.Windows.Forms.Button();

            lblArchiveTitle = new System.Windows.Forms.Label();
            dgvArchive = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            panelEmpInfo.SuspendLayout();
            panelReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArchive).BeginInit();
            SuspendLayout();

            // Header
            panelHeader.BackColor = System.Drawing.Color.Brown;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack); panelHeader.Controls.Add(btnExit);
            panelHeader.Location = new System.Drawing.Point(0, 0); panelHeader.Size = new System.Drawing.Size(760, 55);
            lblTitle.AutoSize = true; lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.Bisque; lblTitle.Location = new System.Drawing.Point(210, 12); lblTitle.Text = "🚪 Employee Offboarding Archive";
            btnBack.BackColor = System.Drawing.Color.SaddleBrown; btnBack.ForeColor = System.Drawing.Color.Bisque; btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnBack.Location = new System.Drawing.Point(10, 14); btnBack.Size = new System.Drawing.Size(90, 28); btnBack.Text = "◀ Back"; btnBack.Click += btnBack_Click;
            btnExit.BackColor = System.Drawing.Color.SaddleBrown; btnExit.ForeColor = System.Drawing.Color.Bisque; btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnExit.Location = new System.Drawing.Point(650, 14); btnExit.Size = new System.Drawing.Size(90, 28); btnExit.Text = "Exit"; btnExit.Click += btnExit_Click;

            // Search
            panelSearch.BackColor = System.Drawing.Color.FromArgb(245, 235, 220); panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSearch.Controls.Add(lblEmpIDLbl); panelSearch.Controls.Add(txtEmpID); panelSearch.Controls.Add(btnFetch);
            panelSearch.Location = new System.Drawing.Point(10, 65); panelSearch.Size = new System.Drawing.Size(735, 55);
            L(lblEmpIDLbl, "Employee ID:", 15, 14); T(txtEmpID, 150, 11, 200);
            btnFetch.BackColor = System.Drawing.Color.Brown; btnFetch.ForeColor = System.Drawing.Color.Bisque; btnFetch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnFetch.Location = new System.Drawing.Point(365, 9); btnFetch.Size = new System.Drawing.Size(120, 30); btnFetch.Text = "🔍 Fetch Employee"; btnFetch.Click += btnFetch_Click;

            // EmpInfo panel
            panelEmpInfo.BackColor = System.Drawing.Color.FromArgb(255, 248, 220); panelEmpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelEmpInfo.Controls.Add(lblInfoTitle); panelEmpInfo.Controls.Add(lblName); panelEmpInfo.Controls.Add(lblAge); panelEmpInfo.Controls.Add(lblEmail); panelEmpInfo.Controls.Add(lblJoinDate); panelEmpInfo.Controls.Add(lblDept);
            panelEmpInfo.Location = new System.Drawing.Point(10, 130); panelEmpInfo.Size = new System.Drawing.Size(350, 160); panelEmpInfo.Visible = false;
            lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); lblInfoTitle.ForeColor = System.Drawing.Color.Brown; lblInfoTitle.Location = new System.Drawing.Point(10, 8); lblInfoTitle.Size = new System.Drawing.Size(330, 22); lblInfoTitle.Text = "👤 Employee Details";
            IL(lblName, "Name: --", 10, 35); IL(lblAge, "Age: --", 10, 60); IL(lblEmail, "Email: --", 10, 85); IL(lblJoinDate, "Join Date: --", 10, 110); IL(lblDept, "Shift: --", 10, 135);

            // Reason panel
            panelReason.BackColor = System.Drawing.Color.FromArgb(245, 235, 220); panelReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelReason.Controls.Add(lblReason); panelReason.Controls.Add(txtReason); panelReason.Controls.Add(lblExitNotes); panelReason.Controls.Add(txtExitNotes); panelReason.Controls.Add(btnConfirm);
            panelReason.Location = new System.Drawing.Point(375, 130); panelReason.Size = new System.Drawing.Size(370, 160);
            L(lblReason, "Offboard Reason:", 10, 12); txtReason.Location = new System.Drawing.Point(10, 35); txtReason.Size = new System.Drawing.Size(345, 40); txtReason.Multiline = true;
            L(lblExitNotes, "Exit Interview Notes:", 10, 82); txtExitNotes.Location = new System.Drawing.Point(10, 105); txtExitNotes.Size = new System.Drawing.Size(250, 35); txtExitNotes.Multiline = true;
            btnConfirm.BackColor = System.Drawing.Color.DarkRed; btnConfirm.ForeColor = System.Drawing.Color.White; btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnConfirm.Location = new System.Drawing.Point(270, 105); btnConfirm.Size = new System.Drawing.Size(90, 35); btnConfirm.Text = "✔ Confirm"; btnConfirm.Click += btnConfirm_Click; btnConfirm.Enabled = false;

            // Archive
            lblArchiveTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); lblArchiveTitle.ForeColor = System.Drawing.Color.Brown; lblArchiveTitle.Location = new System.Drawing.Point(10, 300); lblArchiveTitle.Size = new System.Drawing.Size(400, 22); lblArchiveTitle.Text = "🗂️ Offboarded Employees Archive";
            dgvArchive.Location = new System.Drawing.Point(10, 326); dgvArchive.Size = new System.Drawing.Size(735, 230);
            dgvArchive.ReadOnly = true; dgvArchive.AllowUserToAddRows = false; dgvArchive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchive.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Brown; dgvArchive.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Bisque;
            dgvArchive.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); dgvArchive.EnableHeadersVisualStyles = false; dgvArchive.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvArchive.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 230, 230);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 570);
            Text = "Offboarding Archive";
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(panelHeader); Controls.Add(panelSearch); Controls.Add(panelEmpInfo); Controls.Add(panelReason); Controls.Add(lblArchiveTitle); Controls.Add(dgvArchive);
            Load += OffboardingForm_Load;

            panelHeader.ResumeLayout(false); panelSearch.ResumeLayout(false); panelEmpInfo.ResumeLayout(false); panelReason.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArchive).EndInit();
            ResumeLayout(false);
        }

        void L(System.Windows.Forms.Label l, string t, int x, int y) { l.Text = t; l.Location = new System.Drawing.Point(x, y); l.Size = new System.Drawing.Size(150, 22); l.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); l.ForeColor = System.Drawing.Color.Brown; }
        void T(System.Windows.Forms.TextBox tb, int x, int y, int w) { tb.Location = new System.Drawing.Point(x, y); tb.Size = new System.Drawing.Size(w, 25); }
        void IL(System.Windows.Forms.Label l, string t, int x, int y) { l.Text = t; l.Location = new System.Drawing.Point(x, y); l.Size = new System.Drawing.Size(330, 22); l.Font = new System.Drawing.Font("Segoe UI", 9F); l.ForeColor = System.Drawing.Color.DarkSlateGray; }

        private System.Windows.Forms.Panel panelHeader, panelSearch, panelEmpInfo, panelReason;
        private System.Windows.Forms.Label lblTitle, lblEmpIDLbl, lblInfoTitle, lblName, lblAge, lblEmail, lblJoinDate, lblDept;
        private System.Windows.Forms.Label lblReason, lblExitNotes, lblArchiveTitle;
        private System.Windows.Forms.TextBox txtEmpID, txtReason, txtExitNotes;
        private System.Windows.Forms.Button btnFetch, btnConfirm, btnBack, btnExit;
        private System.Windows.Forms.DataGridView dgvArchive;
    }
}
