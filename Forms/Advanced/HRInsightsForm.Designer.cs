namespace Employeemanagment
{
    partial class HRInsightsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnBack = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();

            panelTop = new System.Windows.Forms.Panel();
            btnAnalyze = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            lblDesc = new System.Windows.Forms.Label();

            panelLegend = new System.Windows.Forms.Panel();
            lblLegendTitle = new System.Windows.Forms.Label();
            lblLegendHigh = new System.Windows.Forms.Label();
            lblLegendMed = new System.Windows.Forms.Label();
            lblLegendLow = new System.Windows.Forms.Label();

            dgvInsights = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            panelTop.SuspendLayout();
            panelLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInsights).BeginInit();
            SuspendLayout();

            // Header
            panelHeader.BackColor = System.Drawing.Color.Brown;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack); panelHeader.Controls.Add(btnExit);
            panelHeader.Location = new System.Drawing.Point(0, 0); panelHeader.Size = new System.Drawing.Size(860, 55);
            lblTitle.AutoSize = true; lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold); lblTitle.ForeColor = System.Drawing.Color.Bisque; lblTitle.Location = new System.Drawing.Point(220, 12); lblTitle.Text = "🤖 AI-Based HR Insights & Analytics";
            btnBack.BackColor = System.Drawing.Color.SaddleBrown; btnBack.ForeColor = System.Drawing.Color.Bisque; btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnBack.Location = new System.Drawing.Point(10, 14); btnBack.Size = new System.Drawing.Size(90, 28); btnBack.Text = "◀ Back"; btnBack.Click += btnBack_Click;
            btnExit.BackColor = System.Drawing.Color.SaddleBrown; btnExit.ForeColor = System.Drawing.Color.Bisque; btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); btnExit.Location = new System.Drawing.Point(750, 14); btnExit.Size = new System.Drawing.Size(90, 28); btnExit.Text = "Exit"; btnExit.Click += btnExit_Click;

            // Top panel
            panelTop.BackColor = System.Drawing.Color.FromArgb(245, 235, 220); panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTop.Controls.Add(btnAnalyze); panelTop.Controls.Add(lblStatus); panelTop.Controls.Add(lblDesc);
            panelTop.Location = new System.Drawing.Point(10, 65); panelTop.Size = new System.Drawing.Size(840, 80);

            btnAnalyze.BackColor = System.Drawing.Color.Brown; btnAnalyze.ForeColor = System.Drawing.Color.Bisque;
            btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnAnalyze.Location = new System.Drawing.Point(15, 18); btnAnalyze.Size = new System.Drawing.Size(200, 45);
            btnAnalyze.Text = "🤖 Run AI Analysis"; btnAnalyze.Click += btnAnalyze_Click;

            lblDesc.Font = new System.Drawing.Font("Segoe UI", 9F); lblDesc.ForeColor = System.Drawing.Color.DimGray;
            lblDesc.Location = new System.Drawing.Point(230, 10); lblDesc.Size = new System.Drawing.Size(600, 30);
            lblDesc.Text = "Analyzes attendance, leaves, performance reviews, payroll, and offboarding data to generate smart HR insights.";

            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); lblStatus.ForeColor = System.Drawing.Color.Brown;
            lblStatus.Location = new System.Drawing.Point(230, 45); lblStatus.Size = new System.Drawing.Size(600, 24);
            lblStatus.Text = "Click 'Run AI Analysis' to start...";

            // Legend
            panelLegend.BackColor = System.Drawing.Color.FromArgb(240, 240, 235); panelLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelLegend.Controls.Add(lblLegendTitle); panelLegend.Controls.Add(lblLegendHigh); panelLegend.Controls.Add(lblLegendMed); panelLegend.Controls.Add(lblLegendLow);
            panelLegend.Location = new System.Drawing.Point(10, 155); panelLegend.Size = new System.Drawing.Size(840, 35);

            lblLegendTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); lblLegendTitle.ForeColor = System.Drawing.Color.Brown; lblLegendTitle.Location = new System.Drawing.Point(8, 8); lblLegendTitle.Size = new System.Drawing.Size(60, 20); lblLegendTitle.Text = "Legend:";
            lblLegendHigh.BackColor = System.Drawing.Color.FromArgb(255, 199, 206); lblLegendHigh.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); lblLegendHigh.Location = new System.Drawing.Point(80, 6); lblLegendHigh.Size = new System.Drawing.Size(130, 22); lblLegendHigh.Text = "  🔴 HIGH — Urgent"; lblLegendHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblLegendMed.BackColor = System.Drawing.Color.FromArgb(255, 235, 156); lblLegendMed.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); lblLegendMed.Location = new System.Drawing.Point(225, 6); lblLegendMed.Size = new System.Drawing.Size(150, 22); lblLegendMed.Text = "  🟡 MEDIUM — Watch"; lblLegendMed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblLegendLow.BackColor = System.Drawing.Color.FromArgb(198, 239, 206); lblLegendLow.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); lblLegendLow.Location = new System.Drawing.Point(390, 6); lblLegendLow.Size = new System.Drawing.Size(160, 22); lblLegendLow.Text = "  🟢 LOW — Positive"; lblLegendLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Grid
            dgvInsights.Location = new System.Drawing.Point(10, 198); dgvInsights.Size = new System.Drawing.Size(840, 390);
            dgvInsights.ReadOnly = true; dgvInsights.AllowUserToAddRows = false;
            dgvInsights.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Brown;
            dgvInsights.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Bisque;
            dgvInsights.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvInsights.EnableHeadersVisualStyles = false; dgvInsights.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvInsights.RowTemplate.Height = 32;
            dgvInsights.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(860, 600);
            Text = "AI HR Insights";
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(panelHeader); Controls.Add(panelTop); Controls.Add(panelLegend); Controls.Add(dgvInsights);
            Load += HRInsightsForm_Load;

            panelHeader.ResumeLayout(false); panelTop.ResumeLayout(false); panelLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInsights).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader, panelTop, panelLegend;
        private System.Windows.Forms.Label lblTitle, lblStatus, lblDesc, lblLegendTitle, lblLegendHigh, lblLegendMed, lblLegendLow;
        private System.Windows.Forms.Button btnAnalyze, btnBack, btnExit;
        private System.Windows.Forms.DataGridView dgvInsights;
    }
}
