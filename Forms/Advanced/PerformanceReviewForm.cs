using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class PerformanceReviewForm : Form
    {

        public PerformanceReviewForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void PerformanceReviewForm_Load(object sender, EventArgs e)
        {
            dtpReview.Value = DateTime.Today;
            nudRating.Value = 3;
            UpdateIncrementSuggestion();
            LoadReviews();
        }

        private void nudRating_ValueChanged(object sender, EventArgs e) => UpdateIncrementSuggestion();

        private void UpdateIncrementSuggestion()
        {
            int rating = (int)nudRating.Value;
            if (rating >= 4)
            {
                lblSuggestion.Text = "?? Recommendation: Increment ? 15%";
                lblSuggestion.ForeColor = Color.DarkGreen;
                lblIncrementVal.Text = "15%";
            }
            else if (rating == 3)
            {
                lblSuggestion.Text = "?? Recommendation: Increment ? 10%";
                lblSuggestion.ForeColor = Color.DarkOrange;
                lblIncrementVal.Text = "10%";
            }
            else
            {
                lblSuggestion.Text = "?? Recommendation: No Increment ?";
                lblSuggestion.ForeColor = Color.DarkRed;
                lblIncrementVal.Text = "0%";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text))
            {
                MessageBox.Show("Please enter Employee ID.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rating = (int)nudRating.Value;
            string recommended = rating >= 3 ? "Yes" : "No";
            decimal increment = rating >= 4 ? 15.0m : rating == 3 ? 10.0m : 0.0m;
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var review = new Employeemanagment.Data.Models.PerformanceReview
                {
                    EmployeeId = txtEmpID.Text.Trim(),
                    ReviewDate = dtpReview.Value.ToString("yyyy-MM-dd"),
                    Rating = rating,
                    Comments = txtComments.Text.Trim(),
                    IncrementRecommended = recommended,
                    IncrementPercent = increment
                };
                db.PerformanceReviews.Add(review);
                await db.SaveChangesAsync();
                MessageBox.Show($"Review saved! Increment Recommended: {recommended} ({increment}%)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpID.Clear(); txtComments.Clear(); nudRating.Value = 3;
                LoadReviews();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LoadReviews()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                string filter = txtFilter.Text.Trim();
                
                var query = db.PerformanceReviews.AsQueryable();
                if (!string.IsNullOrEmpty(filter))
                    query = System.Linq.Queryable.Where(query, r => r.EmployeeId == filter);
                    
                var reviews = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.OrderByDescending(query, r => r.ReviewId));
                    
                dgvReviews.DataSource = reviews;
                ColorReviewRows();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ColorReviewRows()
        {
            foreach (DataGridViewRow row in dgvReviews.Rows)
            {
                if (row.IsNewRow) continue;
                if (!int.TryParse(row.Cells["Rating"].Value?.ToString(), out int r)) continue;
                row.DefaultCellStyle.BackColor = r >= 4 ? Color.FromArgb(198, 239, 206) :
                                                  r == 3 ? Color.FromArgb(255, 235, 156) :
                                                            Color.FromArgb(255, 199, 206);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) => LoadReviews();
        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}

