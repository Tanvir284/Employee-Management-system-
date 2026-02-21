namespace Employeemanagment
{
    partial class LeaveManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            
            // Tab Buttons
            btnTabRequest = new System.Windows.Forms.Button();
            btnTabApproval = new System.Windows.Forms.Button();

            // Request Panel
            pnlRequest = new System.Windows.Forms.Panel();
            lblReqEmpID = new System.Windows.Forms.Label();
            txtReqEmpID = new System.Windows.Forms.TextBox();
            lblLeaveType = new System.Windows.Forms.Label();
            cmbLeaveType = new System.Windows.Forms.ComboBox();
            lblStart = new System.Windows.Forms.Label();
            dtpStart = new System.Windows.Forms.DateTimePicker();
            lblEnd = new System.Windows.Forms.Label();
            dtpEnd = new System.Windows.Forms.DateTimePicker();
            lblReason = new System.Windows.Forms.Label();
            txtReason = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();

            // Approval Panel
            pnlApproval = new System.Windows.Forms.Panel();
            lblPending = new System.Windows.Forms.Label();
            dgvPending = new System.Windows.Forms.DataGridView();
            btnApprove = new System.Windows.Forms.Button();
            btnReject = new System.Windows.Forms.Button();
            lblAllLeaves = new System.Windows.Forms.Label();
            dgvAll = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            pnlRequest.SuspendLayout();
            pnlApproval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAll).BeginInit();
            SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(850, 680);
            Text = "Leave Management";
            BackColor = UITheme.BackDark;
            Load += LeaveManagementForm_Load;

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
            lblTitle.Location = new System.Drawing.Point(300, 18);
            lblTitle.Text = "🏖️ LEAVE MANAGEMENT";

            btnBack.Location = new System.Drawing.Point(20, 20);
            btnBack.Size = new System.Drawing.Size(90, 32);
            btnBack.Text = "◀ Back";
            btnBack.Click += btnBack_Click;

            btnExit.Location = new System.Drawing.Point(740, 20);
            btnExit.Size = new System.Drawing.Size(90, 32);
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;

            // ── Custom Tabs ───────────────────────────────────────────────────
            btnTabRequest.Location = new System.Drawing.Point(30, 90);
            btnTabRequest.Size = new System.Drawing.Size(220, 45);
            btnTabRequest.Text = "📝 Submit Leave Request";
            btnTabRequest.Click += (s, e) => { pnlRequest.Visible = true; pnlApproval.Visible = false; UITheme.ActivateNav(btnTabRequest, this); };

            btnTabApproval.Location = new System.Drawing.Point(270, 90);
            btnTabApproval.Size = new System.Drawing.Size(220, 45);
            btnTabApproval.Text = "✅ Approve / Reject";
            btnTabApproval.Click += (s, e) => { pnlRequest.Visible = false; pnlApproval.Visible = true; UITheme.ActivateNav(btnTabApproval, this); };

            Controls.Add(btnTabRequest);
            Controls.Add(btnTabApproval);
            Controls.Add(panelHeader);

            // ── Request Panel ─────────────────────────────────────────────────
            pnlRequest.Location = new System.Drawing.Point(30, 150);
            pnlRequest.Size = new System.Drawing.Size(790, 500);
            pnlRequest.BackColor = UITheme.Card;
            pnlRequest.Visible = true;

            int leftCol = 40, ySpace = 75, currentY = 30;

            // Employee ID
            lblReqEmpID.Text = "Employee ID";
            lblReqEmpID.Location = new System.Drawing.Point(leftCol, currentY);
            lblReqEmpID.Font = UITheme.FontBold;
            lblReqEmpID.ForeColor = UITheme.TextSecondary;
            lblReqEmpID.AutoSize = true;

            txtReqEmpID.Location = new System.Drawing.Point(leftCol, currentY + 25);
            txtReqEmpID.Size = new System.Drawing.Size(300, 30);
            txtReqEmpID.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtReqEmpID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            var lineEmpId = new System.Windows.Forms.Panel { BackColor = UITheme.Accent, Location = new System.Drawing.Point(leftCol, currentY + 55), Size = new System.Drawing.Size(300, 2) };
            
            // Leave Type
            currentY += ySpace;
            lblLeaveType.Text = "Leave Type";
            lblLeaveType.Location = new System.Drawing.Point(leftCol, currentY);
            lblLeaveType.Font = UITheme.FontBold;
            lblLeaveType.ForeColor = UITheme.TextSecondary;
            lblLeaveType.AutoSize = true;

            cmbLeaveType.Location = new System.Drawing.Point(leftCol, currentY + 25);
            cmbLeaveType.Size = new System.Drawing.Size(300, 30);
            cmbLeaveType.Font = new System.Drawing.Font("Segoe UI", 12F);
            cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var lineType = new System.Windows.Forms.Panel { BackColor = UITheme.Accent, Location = new System.Drawing.Point(leftCol, currentY + 55), Size = new System.Drawing.Size(300, 2) };

            // Dates
            currentY += ySpace;
            lblStart.Text = "Start Date";
            lblStart.Location = new System.Drawing.Point(leftCol, currentY);
            lblStart.Font = UITheme.FontBold;
            lblStart.ForeColor = UITheme.TextSecondary;
            lblStart.AutoSize = true;

            dtpStart.Location = new System.Drawing.Point(leftCol, currentY + 25);
            dtpStart.Size = new System.Drawing.Size(200, 30);
            dtpStart.Font = new System.Drawing.Font("Segoe UI", 12F);
            dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            lblEnd.Text = "End Date";
            lblEnd.Location = new System.Drawing.Point(leftCol + 230, currentY);
            lblEnd.Font = UITheme.FontBold;
            lblEnd.ForeColor = UITheme.TextSecondary;
            lblEnd.AutoSize = true;

            dtpEnd.Location = new System.Drawing.Point(leftCol + 230, currentY + 25);
            dtpEnd.Size = new System.Drawing.Size(200, 30);
            dtpEnd.Font = new System.Drawing.Font("Segoe UI", 12F);
            dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Reason
            currentY += ySpace;
            lblReason.Text = "Reason";
            lblReason.Location = new System.Drawing.Point(leftCol, currentY);
            lblReason.Font = UITheme.FontBold;
            lblReason.ForeColor = UITheme.TextSecondary;
            lblReason.AutoSize = true;

            txtReason.Location = new System.Drawing.Point(leftCol, currentY + 25);
            txtReason.Size = new System.Drawing.Size(600, 100);
            txtReason.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtReason.Multiline = true;
            var lineReason = new System.Windows.Forms.Panel { BackColor = UITheme.Accent, Location = new System.Drawing.Point(leftCol, currentY + 125), Size = new System.Drawing.Size(600, 2) };

            btnSubmit.Location = new System.Drawing.Point(leftCol, currentY + 150);
            btnSubmit.Size = new System.Drawing.Size(200, 45);
            btnSubmit.Text = "✔ Submit Request";
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSubmit.Click += btnSubmit_Click;

            pnlRequest.Controls.AddRange(new System.Windows.Forms.Control[] { 
                lblReqEmpID, txtReqEmpID, lineEmpId,
                lblLeaveType, cmbLeaveType, lineType,
                lblStart, dtpStart, lblEnd, dtpEnd,
                lblReason, txtReason, lineReason, btnSubmit 
            });
            Controls.Add(pnlRequest);

            // ── Approval Panel ────────────────────────────────────────────────
            pnlApproval.Location = new System.Drawing.Point(30, 150);
            pnlApproval.Size = new System.Drawing.Size(790, 500);
            pnlApproval.BackColor = UITheme.Card;
            pnlApproval.Visible = false;
            pnlApproval.Padding = new System.Windows.Forms.Padding(20);

            lblPending.Text = "⏳ Pending Leave Requests:";
            lblPending.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPending.ForeColor = UITheme.TextPrimary;
            lblPending.Location = new System.Drawing.Point(20, 20);
            lblPending.AutoSize = true;

            dgvPending.Location = new System.Drawing.Point(20, 50);
            dgvPending.Size = new System.Drawing.Size(750, 160);

            btnApprove.Location = new System.Drawing.Point(20, 225);
            btnApprove.Size = new System.Drawing.Size(150, 40);
            btnApprove.Text = "✔ Approve selected";
            btnApprove.BackColor = UITheme.Success;
            btnApprove.Click += BtnApprove_Click;

            btnReject.Location = new System.Drawing.Point(185, 225);
            btnReject.Size = new System.Drawing.Size(150, 40);
            btnReject.Text = "✖ Reject selected";
            btnReject.BackColor = UITheme.Danger;
            btnReject.Click += BtnReject_Click;

            lblAllLeaves.Text = "📋 All Leave History:";
            lblAllLeaves.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblAllLeaves.ForeColor = UITheme.TextPrimary;
            lblAllLeaves.Location = new System.Drawing.Point(20, 280);
            lblAllLeaves.AutoSize = true;

            dgvAll.Location = new System.Drawing.Point(20, 310);
            dgvAll.Size = new System.Drawing.Size(750, 160);

            pnlApproval.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblPending, dgvPending, btnApprove, btnReject, lblAllLeaves, dgvAll
            });
            Controls.Add(pnlApproval);

            panelHeader.ResumeLayout(false);
            pnlRequest.ResumeLayout(false);
            pnlApproval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAll).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel pnlRequest;
        private System.Windows.Forms.Panel pnlApproval;
        private System.Windows.Forms.Label lblTitle, lblReqEmpID, lblLeaveType, lblStart, lblEnd, lblReason, lblPending, lblAllLeaves;
        private System.Windows.Forms.TextBox txtReqEmpID, txtReason;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.DateTimePicker dtpStart, dtpEnd;
        private System.Windows.Forms.Button btnSubmit, btnApprove, btnReject, btnBack, btnExit;
        private System.Windows.Forms.Button btnTabRequest, btnTabApproval;
        private System.Windows.Forms.DataGridView dgvPending, dgvAll;
    }
}
