namespace Employeemanagment
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();

            panelInput = new System.Windows.Forms.Panel();
            lblEmpID = new System.Windows.Forms.Label();
            txtEmpID = new System.Windows.Forms.TextBox();
            lblDate = new System.Windows.Forms.Label();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            lblCheckIn = new System.Windows.Forms.Label();
            dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            lblCheckOut = new System.Windows.Forms.Label();
            dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            lblStatus = new System.Windows.Forms.Label();
            cmbStatus = new System.Windows.Forms.ComboBox();
            btnMark = new System.Windows.Forms.Button();

            panelAnalytics = new System.Windows.Forms.Panel();
            lblAnalyticsTitle = new System.Windows.Forms.Label();
            lblPresent = new System.Windows.Forms.Label();
            lblAbsent = new System.Windows.Forms.Label();
            lblLate = new System.Windows.Forms.Label();
            lblRate = new System.Windows.Forms.Label();

            panelFilter = new System.Windows.Forms.Panel();
            lblFilterID = new System.Windows.Forms.Label();
            txtFilterID = new System.Windows.Forms.TextBox();
            btnLoad = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            dgvAttendance = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            panelInput.SuspendLayout();
            panelAnalytics.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = System.Drawing.Color.Brown;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(btnExit);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Size = new System.Drawing.Size(760, 55);

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Bisque;
            lblTitle.Location = new System.Drawing.Point(250, 12);
            lblTitle.Text = "📅 Attendance Tracking";

            btnBack.BackColor = System.Drawing.Color.SaddleBrown;
            btnBack.ForeColor = System.Drawing.Color.Bisque;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBack.Location = new System.Drawing.Point(10, 14);
            btnBack.Size = new System.Drawing.Size(90, 28);
            btnBack.Text = "◀ Back";
            btnBack.Click += btnBack_Click;

            btnExit.BackColor = System.Drawing.Color.SaddleBrown;
            btnExit.ForeColor = System.Drawing.Color.Bisque;
            btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnExit.Location = new System.Drawing.Point(650, 14);
            btnExit.Size = new System.Drawing.Size(90, 28);
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;

            // panelInput
            panelInput.BackColor = System.Drawing.Color.FromArgb(245, 235, 220);
            panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelInput.Controls.Add(lblEmpID); panelInput.Controls.Add(txtEmpID);
            panelInput.Controls.Add(lblDate); panelInput.Controls.Add(dtpDate);
            panelInput.Controls.Add(lblCheckIn); panelInput.Controls.Add(dtpCheckIn);
            panelInput.Controls.Add(lblCheckOut); panelInput.Controls.Add(dtpCheckOut);
            panelInput.Controls.Add(lblStatus); panelInput.Controls.Add(cmbStatus);
            panelInput.Controls.Add(btnMark);
            panelInput.Location = new System.Drawing.Point(10, 65);
            panelInput.Size = new System.Drawing.Size(480, 160);

            SetLabel(lblEmpID, "Employee ID:", 10, 15);
            SetTextBox(txtEmpID, 130, 12, 120);
            SetLabel(lblDate, "Date:", 10, 48);
            dtpDate.Location = new System.Drawing.Point(130, 45); dtpDate.Size = new System.Drawing.Size(150, 25); dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            SetLabel(lblCheckIn, "Check In:", 10, 82);
            dtpCheckIn.Location = new System.Drawing.Point(130, 79); dtpCheckIn.Size = new System.Drawing.Size(150, 25); dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Time; dtpCheckIn.ShowUpDown = true;
            SetLabel(lblCheckOut, "Check Out:", 10, 116);
            dtpCheckOut.Location = new System.Drawing.Point(130, 113); dtpCheckOut.Size = new System.Drawing.Size(150, 25); dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Time; dtpCheckOut.ShowUpDown = true;
            SetLabel(lblStatus, "Status:", 300, 15);
            cmbStatus.Location = new System.Drawing.Point(360, 12); cmbStatus.Size = new System.Drawing.Size(100, 25); cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnMark.BackColor = System.Drawing.Color.Brown; btnMark.ForeColor = System.Drawing.Color.Bisque;
            btnMark.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnMark.Location = new System.Drawing.Point(300, 110); btnMark.Size = new System.Drawing.Size(160, 35);
            btnMark.Text = "✔ Mark Attendance"; btnMark.Click += btnMark_Click;

            // panelAnalytics
            panelAnalytics.BackColor = System.Drawing.Color.FromArgb(245, 235, 220);
            panelAnalytics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelAnalytics.Controls.Add(lblAnalyticsTitle);
            panelAnalytics.Controls.Add(lblPresent); panelAnalytics.Controls.Add(lblAbsent);
            panelAnalytics.Controls.Add(lblLate); panelAnalytics.Controls.Add(lblRate);
            panelAnalytics.Location = new System.Drawing.Point(500, 65);
            panelAnalytics.Size = new System.Drawing.Size(240, 160);

            lblAnalyticsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblAnalyticsTitle.ForeColor = System.Drawing.Color.Brown;
            lblAnalyticsTitle.Location = new System.Drawing.Point(10, 10); lblAnalyticsTitle.Size = new System.Drawing.Size(220, 20);
            lblAnalyticsTitle.Text = "📊 This Month Analytics";

            lblPresent.Font = new System.Drawing.Font("Segoe UI", 9F); lblPresent.ForeColor = System.Drawing.Color.DarkGreen;
            lblPresent.Location = new System.Drawing.Point(10, 38); lblPresent.Size = new System.Drawing.Size(220, 22); lblPresent.Text = "✅ Present: 0";
            lblAbsent.Font = new System.Drawing.Font("Segoe UI", 9F); lblAbsent.ForeColor = System.Drawing.Color.DarkRed;
            lblAbsent.Location = new System.Drawing.Point(10, 65); lblAbsent.Size = new System.Drawing.Size(220, 22); lblAbsent.Text = "❌ Absent: 0";
            lblLate.Font = new System.Drawing.Font("Segoe UI", 9F); lblLate.ForeColor = System.Drawing.Color.DarkOrange;
            lblLate.Location = new System.Drawing.Point(10, 92); lblLate.Size = new System.Drawing.Size(220, 22); lblLate.Text = "⚠️ Late: 0";
            lblRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); lblRate.ForeColor = System.Drawing.Color.Brown;
            lblRate.Location = new System.Drawing.Point(10, 125); lblRate.Size = new System.Drawing.Size(220, 22); lblRate.Text = "📊 Attendance Rate: N/A";

            // panelFilter
            panelFilter.BackColor = System.Drawing.Color.FromArgb(235, 220, 200);
            panelFilter.Controls.Add(lblFilterID); panelFilter.Controls.Add(txtFilterID);
            panelFilter.Controls.Add(btnLoad); panelFilter.Controls.Add(btnClear);
            panelFilter.Location = new System.Drawing.Point(10, 235);
            panelFilter.Size = new System.Drawing.Size(730, 45);

            SetLabel(lblFilterID, "Filter by Employee ID:", 10, 12);
            SetTextBox(txtFilterID, 175, 9, 160);
            btnLoad.BackColor = System.Drawing.Color.Brown; btnLoad.ForeColor = System.Drawing.Color.Bisque;
            btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnLoad.Location = new System.Drawing.Point(355, 8); btnLoad.Size = new System.Drawing.Size(90, 28); btnLoad.Text = "🔍 Filter"; btnLoad.Click += btnLoad_Click;
            btnClear.BackColor = System.Drawing.Color.SaddleBrown; btnClear.ForeColor = System.Drawing.Color.Bisque;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnClear.Location = new System.Drawing.Point(455, 8); btnClear.Size = new System.Drawing.Size(90, 28); btnClear.Text = "Clear"; btnClear.Click += btnClear_Click;

            // DataGridView
            dgvAttendance.Location = new System.Drawing.Point(10, 290);
            dgvAttendance.Size = new System.Drawing.Size(730, 240);
            dgvAttendance.ReadOnly = true;
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Brown;
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Bisque;
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 545);
            Text = "Attendance Tracking";
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(panelHeader);
            Controls.Add(panelInput);
            Controls.Add(panelAnalytics);
            Controls.Add(panelFilter);
            Controls.Add(dgvAttendance);
            Load += AttendanceForm_Load;

            panelHeader.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelAnalytics.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            ResumeLayout(false);
        }

        private void SetLabel(System.Windows.Forms.Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y);
            lbl.Size = new System.Drawing.Size(120, 22); lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Brown;
        }
        private void SetTextBox(System.Windows.Forms.TextBox tb, int x, int y, int w)
        {
            tb.Location = new System.Drawing.Point(x, y); tb.Size = new System.Drawing.Size(w, 25);
        }

        private System.Windows.Forms.Panel panelHeader, panelInput, panelAnalytics, panelFilter;
        private System.Windows.Forms.Label lblTitle, lblEmpID, lblDate, lblCheckIn, lblCheckOut, lblStatus;
        private System.Windows.Forms.Label lblAnalyticsTitle, lblPresent, lblAbsent, lblLate, lblRate, lblFilterID;
        private System.Windows.Forms.TextBox txtEmpID, txtFilterID;
        private System.Windows.Forms.DateTimePicker dtpDate, dtpCheckIn, dtpCheckOut;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnMark, btnBack, btnExit, btnLoad, btnClear;
        private System.Windows.Forms.DataGridView dgvAttendance;
    }
}
