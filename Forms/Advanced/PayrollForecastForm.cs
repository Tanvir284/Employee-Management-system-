using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class PayrollForecastForm : Form
    {

        public PayrollForecastForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void PayrollForecastForm_Load(object sender, EventArgs e)
        {
            cmbMonth.SelectedIndex = DateTime.Today.Month - 1;
            nudYear.Value = DateTime.Today.Year;
            LoadForecasts();
        }

        private async void btnLoadEmp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text)) { MessageBox.Show("Enter Employee ID."); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await db.Employees.FindAsync(txtEmpID.Text.Trim());
                if (emp != null)
                {
                    txtEmpName.Text = emp.Name;
                    txtBaseSalary.Text = emp.Salary;
                }
                else
                {
                    MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpName.Clear(); txtBaseSalary.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtBaseSalary.Text, out decimal baseSal)) { MessageBox.Show("Invalid base salary."); return; }
            if (!decimal.TryParse(txtBonusPct.Text, out decimal bonusPct)) bonusPct = 0;
            if (!decimal.TryParse(txtDeductions.Text, out decimal deductions)) deductions = 0;
            decimal bonus = baseSal * bonusPct / 100;
            decimal net = baseSal + bonus - deductions;
            lblNet.Text = $"?? Net Salary: {net:F2} BDT";
            lblNet.ForeColor = Color.DarkGreen;
            lblBreakdown.Text = $"Base: {baseSal:F2} + Bonus: {bonus:F2} - Deductions: {deductions:F2}";
            // Store to save on confirm
            _calculated = (baseSal, bonus, deductions, net);
            btnSave.Enabled = true;
        }

        private (decimal base_, decimal bonus, decimal ded, decimal net) _calculated;

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text)) { MessageBox.Show("Load an employee first."); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var forecast = new Employeemanagment.Data.Models.PayrollForecast
                {
                    EmployeeId = txtEmpID.Text.Trim(),
                    Month = (cmbMonth.SelectedIndex + 1).ToString(),
                    Year = (int)nudYear.Value,
                    BaseSalary = _calculated.base_,
                    Bonus = _calculated.bonus,
                    Deductions = _calculated.ded,
                    NetSalary = _calculated.net,
                    ForecastDate = DateTime.Today.ToString("yyyy-MM-dd")
                };
                db.PayrollForecasts.Add(forecast);
                await db.SaveChangesAsync();
                MessageBox.Show("Payroll forecast saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                LoadForecasts();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LoadForecasts()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var forecasts = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.OrderByDescending(db.PayrollForecasts, f => f.ForecastId));
                dgvForecasts.DataSource = forecasts;

                // Show totals
                decimal totalNet = 0;
                foreach (var f in forecasts) totalNet += f.NetSalary ?? 0;
                lblTotal.Text = $"?? Total Payroll (All Forecasts): {totalNet:F2} BDT";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}

