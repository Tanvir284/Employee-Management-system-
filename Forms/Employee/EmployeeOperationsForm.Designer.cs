namespace Employeemanagment
{
    partial class EmployeeOperationsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();

            // Tabs
            btnTabAdd = new System.Windows.Forms.Button();
            btnTabManage = new System.Windows.Forms.Button();

            // Input Panel (Shared for Add/Update)
            pnlInputContainer = new System.Windows.Forms.Panel();
            pnlInput = new System.Windows.Forms.Panel();
            lblID = new System.Windows.Forms.Label();
            txtID = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblAge = new System.Windows.Forms.Label();
            txtAge = new System.Windows.Forms.TextBox();
            lblGender = new System.Windows.Forms.Label();
            cmbGender = new System.Windows.Forms.ComboBox();
            lblAddress = new System.Windows.Forms.Label();
            txtAddress = new System.Windows.Forms.TextBox();
            lblPhone = new System.Windows.Forms.Label();
            txtPhone = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblDOB = new System.Windows.Forms.Label();
            dtpDOB = new System.Windows.Forms.DateTimePicker();
            lblJoinDate = new System.Windows.Forms.Label();
            dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            lblShift = new System.Windows.Forms.Label();
            cmbShift = new System.Windows.Forms.ComboBox();
            lblSalary = new System.Windows.Forms.Label();
            txtSalary = new System.Windows.Forms.TextBox();

            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            // Manage Panel (Search/Update/Delete list)
            pnlManage = new System.Windows.Forms.Panel();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            dgvEmployees = new System.Windows.Forms.DataGridView();
            btnUpdateSelected = new System.Windows.Forms.Button();
            btnDeleteSelected = new System.Windows.Forms.Button();

            panelHeader.SuspendLayout();
            pnlInputContainer.SuspendLayout();
            pnlInput.SuspendLayout();
            pnlManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 750);
            Text = "Employee Operations";
            BackColor = UITheme.BackDark;
            Load += EmployeeOperationsForm_Load;

            // ── Header ────────────────────────────────────────────────────────
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Height = 70;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(btnExit);

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(360, 18);
            lblTitle.Text = "👥 EMPLOYEE OPERATIONS";

            btnBack.Location = new System.Drawing.Point(20, 20);
            btnBack.Size = new System.Drawing.Size(90, 32);
            btnBack.Text = "◀ Back";
            btnBack.Click += btnBack_Click;

            btnExit.Location = new System.Drawing.Point(880, 20);
            btnExit.Size = new System.Drawing.Size(90, 32);
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;

            // ── Custom Tabs ───────────────────────────────────────────────────
            btnTabAdd.Location = new System.Drawing.Point(30, 90);
            btnTabAdd.Size = new System.Drawing.Size(220, 45);
            btnTabAdd.Text = "➕ Add New Employee";
            btnTabAdd.Click += (s, e) => { SwitchTab("ADD"); };

            btnTabManage.Location = new System.Drawing.Point(270, 90);
            btnTabManage.Size = new System.Drawing.Size(220, 45);
            btnTabManage.Text = "⚙️ Manage Employees";
            btnTabManage.Click += (s, e) => { SwitchTab("MANAGE"); };

            Controls.Add(btnTabAdd);
            Controls.Add(btnTabManage);
            Controls.Add(panelHeader);

            // ── Input Panel Container ─────────────────────────────────────────
            pnlInputContainer.Location = new System.Drawing.Point(30, 150);
            pnlInputContainer.Size = new System.Drawing.Size(940, 560);
            pnlInputContainer.BackColor = UITheme.Card;
            pnlInputContainer.Controls.Add(pnlInput);
            pnlInputContainer.Visible = false;

            pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlInput.Padding = new System.Windows.Forms.Padding(30);

            int xL = 30, xR = 480, yInc = 75, yC = 30;

            // Row 1
            AddInput(lblID, txtID, pnlInput, "Employee ID", xL, yC, 300);
            AddInput(lblName, txtName, pnlInput, "Full Name", xR, yC, 400);

            // Row 2
            yC += yInc;
            AddInput(lblEmail, txtEmail, pnlInput, "Email Address", xL, yC, 400);
            AddInput(lblPhone, txtPhone, pnlInput, "Phone Number", xR, yC, 300);

            // Row 3
            yC += yInc;
            AddInput(lblAge, txtAge, pnlInput, "Age", xL, yC, 100);
            
            lblGender.Text = "Gender"; lblGender.Location = new System.Drawing.Point(xL + 150, yC); lblGender.Font = UITheme.FontBold; lblGender.ForeColor = UITheme.TextSecondary; lblGender.AutoSize = true; pnlInput.Controls.Add(lblGender);
            cmbGender.Location = new System.Drawing.Point(xL + 150, yC + 25); cmbGender.Size = new System.Drawing.Size(150, 30); cmbGender.Font = new System.Drawing.Font("Segoe UI", 12F); cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; pnlInput.Controls.Add(cmbGender);
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Others" });
            
            lblDOB.Text = "Date of Birth"; lblDOB.Location = new System.Drawing.Point(xR, yC); lblDOB.Font = UITheme.FontBold; lblDOB.ForeColor = UITheme.TextSecondary; lblDOB.AutoSize = true; pnlInput.Controls.Add(lblDOB);
            dtpDOB.Location = new System.Drawing.Point(xR, yC + 25); dtpDOB.Size = new System.Drawing.Size(200, 30); dtpDOB.Font = new System.Drawing.Font("Segoe UI", 12F); dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short; pnlInput.Controls.Add(dtpDOB);

            // Row 4
            yC += yInc;
            lblShift.Text = "Shift"; lblShift.Location = new System.Drawing.Point(xL, yC); lblShift.Font = UITheme.FontBold; lblShift.ForeColor = UITheme.TextSecondary; lblShift.AutoSize = true; pnlInput.Controls.Add(lblShift);
            cmbShift.Location = new System.Drawing.Point(xL, yC + 25); cmbShift.Size = new System.Drawing.Size(150, 30); cmbShift.Font = new System.Drawing.Font("Segoe UI", 12F); cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; pnlInput.Controls.Add(cmbShift);
            cmbShift.Items.AddRange(new string[] { "Morning", "Day", "Evening" });

            AddInput(lblSalary, txtSalary, pnlInput, "Base Salary", xL + 200, yC, 150);
            
            lblJoinDate.Text = "Join Date"; lblJoinDate.Location = new System.Drawing.Point(xR, yC); lblJoinDate.Font = UITheme.FontBold; lblJoinDate.ForeColor = UITheme.TextSecondary; lblJoinDate.AutoSize = true; pnlInput.Controls.Add(lblJoinDate);
            dtpJoinDate.Location = new System.Drawing.Point(xR, yC + 25); dtpJoinDate.Size = new System.Drawing.Size(200, 30); dtpJoinDate.Font = new System.Drawing.Font("Segoe UI", 12F); dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short; pnlInput.Controls.Add(dtpJoinDate);

            // Row 5
            yC += yInc;
            AddInput(lblAddress, txtAddress, pnlInput, "Home Address", xL, yC, 600);
            
            // Buttons
            btnSave.Location = new System.Drawing.Point(xL, yC + 100);
            btnSave.Size = new System.Drawing.Size(180, 45);
            btnSave.Text = "✔ Save Employee";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSave.Click += btnSave_Click;
            pnlInput.Controls.Add(btnSave);

            btnClear.Location = new System.Drawing.Point(xL + 200, yC + 100);
            btnClear.Size = new System.Drawing.Size(140, 45);
            btnClear.Text = "✖ Clear";
            btnClear.BackColor = UITheme.Danger;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnClear.Click += btnClear_Click;
            pnlInput.Controls.Add(btnClear);

            Controls.Add(pnlInputContainer);

            // ── Manage Panel ──────────────────────────────────────────────────
            pnlManage.Location = new System.Drawing.Point(30, 150);
            pnlManage.Size = new System.Drawing.Size(940, 560);
            pnlManage.BackColor = UITheme.Card;
            pnlManage.Visible = true;

            lblSearch.Text = "Search by ID or Name:";
            lblSearch.Location = new System.Drawing.Point(30, 30);
            lblSearch.Font = UITheme.FontBold;
            lblSearch.ForeColor = UITheme.TextSecondary;
            lblSearch.AutoSize = true;

            txtSearch.Location = new System.Drawing.Point(30, 55);
            txtSearch.Size = new System.Drawing.Size(400, 30);
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtSearch.TextChanged += txtSearch_TextChanged;

            var lineSearch = new System.Windows.Forms.Panel { BackColor = UITheme.Accent, Location = new System.Drawing.Point(30, 85), Size = new System.Drawing.Size(400, 2) };

            dgvEmployees.Location = new System.Drawing.Point(30, 110);
            dgvEmployees.Size = new System.Drawing.Size(880, 350);

            btnUpdateSelected.Location = new System.Drawing.Point(30, 485);
            btnUpdateSelected.Size = new System.Drawing.Size(200, 45);
            btnUpdateSelected.Text = "✏️ Edit Selected";
            btnUpdateSelected.BackColor = UITheme.Warning;
            btnUpdateSelected.Click += btnUpdateSelected_Click;

            btnDeleteSelected.Location = new System.Drawing.Point(250, 485);
            btnDeleteSelected.Size = new System.Drawing.Size(200, 45);
            btnDeleteSelected.Text = "🗑️ Delete Selected";
            btnDeleteSelected.BackColor = UITheme.Danger;
            btnDeleteSelected.Click += btnDeleteSelected_Click;

            pnlManage.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblSearch, txtSearch, lineSearch, dgvEmployees, btnUpdateSelected, btnDeleteSelected
            });
            Controls.Add(pnlManage);

            panelHeader.ResumeLayout(false);
            pnlInputContainer.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        private void AddInput(System.Windows.Forms.Label lbl, System.Windows.Forms.TextBox txt, System.Windows.Forms.Panel p, string labelText, int x, int y, int w)
        {
            lbl.Text = labelText;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.Font = UITheme.FontBold;
            lbl.ForeColor = UITheme.TextSecondary;
            lbl.AutoSize = true;
            
            txt.Location = new System.Drawing.Point(x, y + 25);
            txt.Size = new System.Drawing.Size(w, 30);
            txt.Font = new System.Drawing.Font("Segoe UI", 12F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
            var line = new System.Windows.Forms.Panel { BackColor = UITheme.Accent, Location = new System.Drawing.Point(x, y + 55), Size = new System.Drawing.Size(w, 2) };
            
            p.Controls.Add(lbl);
            p.Controls.Add(txt);
            p.Controls.Add(line);
        }

        private System.Windows.Forms.Panel panelHeader, pnlInputContainer, pnlInput, pnlManage;
        private System.Windows.Forms.Label lblTitle, lblID, lblName, lblAge, lblGender, lblAddress, lblPhone, lblEmail, lblDOB, lblJoinDate, lblShift, lblSalary, lblSearch;
        private System.Windows.Forms.TextBox txtID, txtName, txtAge, txtAddress, txtPhone, txtEmail, txtSalary, txtSearch;
        private System.Windows.Forms.ComboBox cmbGender, cmbShift;
        private System.Windows.Forms.DateTimePicker dtpDOB, dtpJoinDate;
        private System.Windows.Forms.Button btnSave, btnClear, btnBack, btnExit, btnTabAdd, btnTabManage, btnUpdateSelected, btnDeleteSelected;
        private System.Windows.Forms.DataGridView dgvEmployees;
    }
}
