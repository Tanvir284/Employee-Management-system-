using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class NotificationsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader      = new Panel();
            lblTitle         = new Label();
            lblCount         = new Label();
            btnClose         = new Button();
            dgvNotifications = new DataGridView();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(820, 520);
            Text = "Notifications";
            BackColor = UITheme.BackDark;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Controls.Add(panelHeader); Controls.Add(lblCount); Controls.Add(dgvNotifications);
            Load += NotificationsForm_Load;

            panelHeader.Dock = DockStyle.Top; panelHeader.Height = 55; panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnClose);
            lblTitle.Text = "🔔  Notification Center"; lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.White; lblTitle.AutoSize = true; lblTitle.Location = new System.Drawing.Point(120, 14);
            btnClose.Text = "✖ Close"; btnClose.Location = new System.Drawing.Point(700, 13); btnClose.Size = new System.Drawing.Size(100, 30);
            btnClose.FlatStyle = FlatStyle.Flat; btnClose.FlatAppearance.BorderColor = UITheme.Danger;
            btnClose.ForeColor = UITheme.Danger; btnClose.BackColor = System.Drawing.Color.Transparent; btnClose.Font = UITheme.FontBold; btnClose.Click += btnClose_Click;

            lblCount.Text = "Loading..."; lblCount.Font = UITheme.FontBold; lblCount.ForeColor = UITheme.TextSecondary;
            lblCount.AutoSize = false; lblCount.Size = new System.Drawing.Size(820, 28);
            lblCount.Location = new System.Drawing.Point(0, 60); lblCount.Padding = new Padding(12, 0, 0, 0);
            lblCount.BackColor = UITheme.Card;

            dgvNotifications.Location = new System.Drawing.Point(0, 88); dgvNotifications.Size = new System.Drawing.Size(820, 432);
            dgvNotifications.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            UITheme.StyleDataGrid(dgvNotifications);
            dgvNotifications.RowTemplate.Height = 38;
            dgvNotifications.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle, lblCount;
        private Button btnClose;
        private DataGridView dgvNotifications;
    }
}
