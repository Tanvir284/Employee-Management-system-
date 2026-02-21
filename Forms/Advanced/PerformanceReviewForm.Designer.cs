namespace Employeemanagment
{
    partial class PerformanceReviewForm
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
            lblReviewDate = new System.Windows.Forms.Label();
            dtpReview = new System.Windows.Forms.DateTimePicker();
            lblRating = new System.Windows.Forms.Label();
            nudRating = new System.Windows.Forms.NumericUpDown();
            lblSuggestion = new System.Windows.Forms.Label();
            lblIncrementLabel = new System.Windows.Forms.Label();
            lblIncrementVal = new System.Windows.Forms.Label();
            lblComments = new System.Windows.Forms.Label();
            txtComments = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();

            panelFilter = new System.Windows.Forms.Panel();
            lblFilter = new System.Windows.Forms.Label();
            txtFilter = new System.Windows.Forms.TextBox();
            btnLoad = new System.Windows.Forms.Button();

            dgvReviews = new System.Windows.Forms.DataGridView();

            panelHeader.SuspendLayout();
            panelInput.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();

            // Header
            panelHeader.BackColor = System.Drawing.Color.Brown;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack); panelHeader.Controls.Add(btnExit);
            panelHeader.Location = new System.Drawing.Point(0, 0); panelHeader.Size = new System.Drawing.Size(760, 55);

            lblTitle.AutoSize = true; lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.Bisque; lblTitle.Location = new System.Drawing.Point(210, 12);
            lblTitle.Text = "⭐ Performance Reviews & Increments";

            btnBack.BackColor = System.Drawing.Color.SaddleBrown; btnBack.ForeColor = System.Drawing.Color.Bisque;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBack.Location = new System.Drawing.Point(10, 14); btnBack.Size = new System.Drawing.Size(90, 28);
            btnBack.Text = "◀ Back"; btnBack.Click += btnBack_Click;

            btnExit.BackColor = System.Drawing.Color.SaddleBrown; btnExit.ForeColor = System.Drawing.Color.Bisque;
            btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnExit.Location = new System.Drawing.Point(650, 14); btnExit.Size = new System.Drawing.Size(90, 28);
            btnExit.Text = "Exit"; btnExit.Click += btnExit_Click;

            // Input Panel
            panelInput.BackColor = System.Drawing.Color.FromArgb(245, 235, 220);
            panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelInput.Controls.Add(lblEmpID); panelInput.Controls.Add(txtEmpID);
            panelInput.Controls.Add(lblReviewDate); panelInput.Controls.Add(dtpReview);
            panelInput.Controls.Add(lblRating); panelInput.Controls.Add(nudRating);
            panelInput.Controls.Add(lblSuggestion);
            panelInput.Controls.Add(lblIncrementLabel); panelInput.Controls.Add(lblIncrementVal);
            panelInput.Controls.Add(lblComments); panelInput.Controls.Add(txtComments);
            panelInput.Controls.Add(btnSave);
            panelInput.Location = new System.Drawing.Point(10, 65); panelInput.Size = new System.Drawing.Size(735, 250);

            SetLbl(lblEmpID, "Employee ID:", 15, 18); SetTb(txtEmpID, 150, 15, 180);
            SetLbl(lblReviewDate, "Review Date:", 15, 58);
            dtpReview.Location = new System.Drawing.Point(150, 55); dtpReview.Size = new System.Drawing.Size(180, 25); dtpReview.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            SetLbl(lblRating, "Rating (1–5):", 15, 98);
            nudRating.Location = new System.Drawing.Point(150, 95); nudRating.Size = new System.Drawing.Size(80, 28);
            nudRating.Minimum = 1; nudRating.Maximum = 5; nudRating.Value = 3; nudRating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            nudRating.ValueChanged += nudRating_ValueChanged;

            lblSuggestion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSuggestion.ForeColor = System.Drawing.Color.DarkOrange;
            lblSuggestion.Location = new System.Drawing.Point(250, 97); lblSuggestion.Size = new System.Drawing.Size(460, 26);
            lblSuggestion.Text = "💡 Recommendation:";

            SetLbl(lblIncrementLabel, "Increment:", 15, 140); lblIncrementLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblIncrementVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblIncrementVal.ForeColor = System.Drawing.Color.Brown;
            lblIncrementVal.Location = new System.Drawing.Point(150, 133); lblIncrementVal.Size = new System.Drawing.Size(80, 30); lblIncrementVal.Text = "10%";

            SetLbl(lblComments, "Comments:", 15, 177);
            txtComments.Location = new System.Drawing.Point(150, 174); txtComments.Size = new System.Drawing.Size(460, 55); txtComments.Multiline = true;

            btnSave.BackColor = System.Drawing.Color.Brown; btnSave.ForeColor = System.Drawing.Color.Bisque;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSave.Location = new System.Drawing.Point(620, 165); btnSave.Size = new System.Drawing.Size(100, 60);
            btnSave.Text = "💾 Save"; btnSave.Click += btnSave_Click;

            // Filter Panel
            panelFilter.BackColor = System.Drawing.Color.FromArgb(235, 220, 200);
            panelFilter.Controls.Add(lblFilter); panelFilter.Controls.Add(txtFilter); panelFilter.Controls.Add(btnLoad);
            panelFilter.Location = new System.Drawing.Point(10, 325); panelFilter.Size = new System.Drawing.Size(735, 45);

            SetLbl(lblFilter, "Filter by Emp ID:", 10, 12);
            SetTb(txtFilter, 150, 9, 160);
            btnLoad.BackColor = System.Drawing.Color.Brown; btnLoad.ForeColor = System.Drawing.Color.Bisque;
            btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnLoad.Location = new System.Drawing.Point(325, 8); btnLoad.Size = new System.Drawing.Size(90, 28); btnLoad.Text = "🔍 Filter"; btnLoad.Click += btnLoad_Click;

            // DataGrid
            dgvReviews.Location = new System.Drawing.Point(10, 380); dgvReviews.Size = new System.Drawing.Size(735, 215);
            dgvReviews.ReadOnly = true; dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvReviews.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Brown;
            dgvReviews.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Bisque;
            dgvReviews.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvReviews.EnableHeadersVisualStyles = false; dgvReviews.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 610);
            Text = "Performance Reviews";
            BackColor = System.Drawing.Color.WhiteSmoke;
            Controls.Add(panelHeader); Controls.Add(panelInput); Controls.Add(panelFilter); Controls.Add(dgvReviews);
            Load += PerformanceReviewForm_Load;

            panelHeader.ResumeLayout(false); panelInput.ResumeLayout(false); panelFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
        }

        void SetLbl(System.Windows.Forms.Label l, string t, int x, int y) { l.Text = t; l.Location = new System.Drawing.Point(x, y); l.Size = new System.Drawing.Size(130, 22); l.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); l.ForeColor = System.Drawing.Color.Brown; }
        void SetTb(System.Windows.Forms.TextBox tb, int x, int y, int w) { tb.Location = new System.Drawing.Point(x, y); tb.Size = new System.Drawing.Size(w, 25); }

        private System.Windows.Forms.Panel panelHeader, panelInput, panelFilter;
        private System.Windows.Forms.Label lblTitle, lblEmpID, lblReviewDate, lblRating, lblSuggestion, lblIncrementLabel, lblIncrementVal, lblComments, lblFilter;
        private System.Windows.Forms.TextBox txtEmpID, txtComments, txtFilter;
        private System.Windows.Forms.DateTimePicker dtpReview;
        private System.Windows.Forms.NumericUpDown nudRating;
        private System.Windows.Forms.Button btnSave, btnBack, btnExit, btnLoad;
        private System.Windows.Forms.DataGridView dgvReviews;
    }
}
