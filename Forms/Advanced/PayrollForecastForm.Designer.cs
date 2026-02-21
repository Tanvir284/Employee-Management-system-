namespace Employeemanagment
{
    partial class PayrollForecastForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();

            panelInput = new System.Windows.Forms.Panel();
            lblEmpID = new System.Windows.Forms.Label();
            txtEmpID = new System.Windows.Forms.TextBox();
            btnLoadEmp = new System.Windows.Forms.Button();
            lblEmpName = new System.Windows.Forms.Label();
            txtEmpName = new System.Windows.Forms.TextBox();
            lblBaseSalary = new System.Windows.Forms.Label();
            txtBaseSalary = new System.Windows.Forms.TextBox();
            lblBonusPct = new System.Windows.Forms.Label();
            txtBonusPct = new System.Windows.Forms.TextBox();
            lblDeductions = new System.Windows.Forms.Label();
            txtDeductions = new System.Windows.Forms.TextBox();
            lblMonth = new System.Windows.Forms.Label();
            cmbMonth = new System.Windows.Forms.ComboBox();
            lblYear = new System.Windows.Forms.Label();
            nudYear = new System.Windows.Forms.NumericUpDown();
            btnCalculate = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            lblNet = new System.Windows.Forms.Label();
            lblBreakdown = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();

            dgvForecasts = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvForecasts).BeginInit();
            SuspendLayout();

            // Header
            panelHeader.BackColor = System.Drawing.Color.Brown;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack); panelHeader.Controls.Add(btnExit);
            panelHeader.Location = new System.Drawing.Point(0, 0); panelHeader.Size = new System.Drawing.Size(760, 55);
            lblTitle.AutoSize = true; lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Bisque; lblTitle.Location = new System.Drawing.Point(220, 12); lblTitle.Text = "💼 Payroll Forecasting";
            btnBack.BackColor = System.Drawing.Color.SaddleBrown; btnBack.ForeColor = System.Drawing.Color.Bisque; btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnBack.Location = new System.Drawing.Point(10, 14); btnBack.Size = new System.Drawing.Size(90, 28); btnBack.Text = "◀ Back"; btnBack.Click += btnBack_Click;
            btnExit.BackColor = System.Drawing.Color.SaddleBrown; btnExit.ForeColor = System.Drawing.Color.Bisque; btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnExit.Location = new System.Drawing.Point(650, 14); btnExit.Size = new System.Drawing.Size(90, 28); btnExit.Text = "Exit"; btnExit.Click += btnExit_Click;

            // Input panel
            panelInput.BackColor = System.Drawing.Color.FromArgb(245, 235, 220);
            panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelInput.Controls.Add(lblEmpID); panelInput.Controls.Add(txtEmpID); panelInput.Controls.Add(btnLoadEmp);
            panelInput.Controls.Add(lblEmpName); panelInput.Controls.Add(txtEmpName);
            panelInput.Controls.Add(lblBaseSalary); panelInput.Controls.Add(txtBaseSalary);
            panelInput.Controls.Add(lblBonusPct); panelInput.Controls.Add(txtBonusPct);
            panelInput.Controls.Add(lblDeductions); panelInput.Controls.Add(txtDeductions);
            panelInput.Controls.Add(lblMonth); panelInput.Controls.Add(cmbMonth);
            panelInput.Controls.Add(lblYear); panelInput.Controls.Add(nudYear);
            panelInput.Controls.Add(btnCalculate); panelInput.Controls.Add(btnSave);
            panelInput.Controls.Add(lblNet); panelInput.Controls.Add(lblBreakdown);
            panelInput.Location = new System.Drawing.Point(10, 65); panelInput.Size = new System.Drawing.Size(735, 280);

            // Row 1
            L(lblEmpID, "Employee ID:", 15, 18); T(txtEmpID, 150, 15, 150);
            btnLoadEmp.BackColor = System.Drawing.Color.Brown; btnLoadEmp.ForeColor = System.Drawing.Color.Bisque; btnLoadEmp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnLoadEmp.Location = new System.Drawing.Point(315, 13); btnLoadEmp.Size = new System.Drawing.Size(100, 28); btnLoadEmp.Text = "📂 Load"; btnLoadEmp.Click += btnLoadEmp_Click;
            L(lblEmpName, "Name:", 15, 55); T(txtEmpName, 150, 52, 250); txtEmpName.ReadOnly = true; txtEmpName.BackColor = System.Drawing.Color.White;
            L(lblBaseSalary, "Base Salary:", 15, 92); T(txtBaseSalary, 150, 89, 150); txtBaseSalary.ReadOnly = true; txtBaseSalary.BackColor = System.Drawing.Color.White;
            L(lblBonusPct, "Bonus %:", 15, 130); T(txtBonusPct, 150, 127, 100); txtBonusPct.Text = "0";
            L(lblDeductions, "Deductions:", 15, 168); T(txtDeductions, 150, 165, 100); txtDeductions.Text = "0";
            L(lblMonth, "Month:", 430, 18); cmbMonth.Location = new System.Drawing.Point(510, 15); cmbMonth.Size = new System.Drawing.Size(120, 25); cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMonth.Items.AddRange(new string[] { "January","February","March","April","May","June","July","August","September","October","November","December" });
            L(lblYear, "Year:", 430, 55); nudYear.Location = new System.Drawing.Point(510, 52); nudYear.Size = new System.Drawing.Size(90, 25); nudYear.Minimum = 2020; nudYear.Maximum = 2040; nudYear.Value = 2026;
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();

            btnCalculate.BackColor = System.Drawing.Color.DarkOrange; btnCalculate.ForeColor = System.Drawing.Color.White; btnCalculate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); btnCalculate.Location = new System.Drawing.Point(430, 100); btnCalculate.Size = new System.Drawing.Size(140, 38); btnCalculate.Text = "🔢 Calculate"; btnCalculate.Click += btnCalculate_Click;
            btnSave.BackColor = System.Drawing.Color.Brown; btnSave.ForeColor = System.Drawing.Color.Bisque; btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); btnSave.Location = new System.Drawing.Point(585, 100); btnSave.Size = new System.Drawing.Size(130, 38); btnSave.Text = "💾 Save"; btnSave.Click += btnSave_Click; btnSave.Enabled = false;

            lblNet.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); lblNet.ForeColor = System.Drawing.Color.DarkGreen; lblNet.Location = new System.Drawing.Point(430, 155); lblNet.Size = new System.Drawing.Size(285, 35); lblNet.Text = "💰 Net Salary: --";
            lblBreakdown.Font = new System.Drawing.Font("Segoe UI", 8F); lblBreakdown.ForeColor = System.Drawing.Color.DimGray; lblBreakdown.Location = new System.Drawing.Point(430, 195); lblBreakdown.Size = new System.Drawing.Size(285, 22); lblBreakdown.Text = "";

            // Totals label
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); lblTotal.ForeColor = System.Drawing.Color.Brown;
            lblTotal.Location = new System.Drawing.Point(10, 355); lblTotal.Size = new System.Drawing.Size(735, 24); lblTotal.Text = "📊 Total Payroll: --";

            // DataGrid
            dgvForecasts.Location = new System.Drawing.Point(10, 385); dgvForecasts.Size = new System.Drawing.Size(735, 220);
            dgvForecasts.ReadOnly = true; dgvForecasts.AllowUserToAddRows = false; dgvForecasts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvForecasts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Brown; dgvForecasts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Bisque;
            dgvForecasts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); dgvForecasts.EnableHeadersVisualStyles = false; dgvForecasts.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 620);
            Text = "Payroll Forecasting";
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(panelHeader); Controls.Add(panelInput); Controls.Add(lblTotal); Controls.Add(dgvForecasts);
            Load += PayrollForecastForm_Load;

            panelHeader.ResumeLayout(false); panelInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvForecasts).EndInit();
            ResumeLayout(false);
        }

        void L(System.Windows.Forms.Label l, string t, int x, int y) { l.Text = t; l.Location = new System.Drawing.Point(x, y); l.Size = new System.Drawing.Size(130, 22); l.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); l.ForeColor = System.Drawing.Color.Brown; }
        void T(System.Windows.Forms.TextBox tb, int x, int y, int w) { tb.Location = new System.Drawing.Point(x, y); tb.Size = new System.Drawing.Size(w, 25); }

        private System.Windows.Forms.Panel panelHeader, panelInput;
        private System.Windows.Forms.Label lblTitle, lblEmpID, lblEmpName, lblBaseSalary, lblBonusPct, lblDeductions, lblMonth, lblYear, lblNet, lblBreakdown, lblTotal;
        private System.Windows.Forms.TextBox txtEmpID, txtEmpName, txtBaseSalary, txtBonusPct, txtDeductions;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Button btnLoadEmp, btnCalculate, btnSave, btnBack, btnExit;
        private System.Windows.Forms.DataGridView dgvForecasts;
    }
}
