using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class OffboardingForm : Form
    {
        private Employeemanagment.Data.Models.Employee _emp = null!;

        public OffboardingForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void OffboardingForm_Load(object sender, EventArgs e)
        {
            LoadArchive();
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text)) { MessageBox.Show("Enter Employee ID."); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                _emp = await db.Employees.FindAsync(txtEmpID.Text.Trim());
                if (_emp == null) { MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                lblName.Text = $"Name: {_emp.Name}";
                lblAge.Text = $"Age: {_emp.Age}";
                lblEmail.Text = $"Email: {_emp.Email}";
                lblJoinDate.Text = $"Join Date: {_emp.JoinDate}";
                lblDept.Text = $"Shift: {_emp.Shift}";
                panelEmpInfo.Visible = true;
                btnConfirm.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_emp == null) { MessageBox.Show("Fetch an employee first."); return; }
            if (string.IsNullOrWhiteSpace(txtReason.Text)) { MessageBox.Show("Please enter offboard reason."); return; }

            var result = MessageBox.Show(
                $"Are you sure you want to offboard employee ID: {_emp.Id}?\nThis will remove them from active employees.",
                "Confirm Offboarding", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var empToDelete = await db.Employees.FindAsync(_emp.Id);
                if (empToDelete == null) return;

                var offboarded = new Employeemanagment.Data.Models.OffboardedEmployee
                {
                    Name = empToDelete.Name,
                    OriginalId = empToDelete.Id,
                    Age = empToDelete.Age,
                    Salary = empToDelete.Salary,
                    Email = empToDelete.Email,
                    Num = empToDelete.Num,
                    Dob = empToDelete.Dob,
                    JoinDate = empToDelete.JoinDate,
                    Address = empToDelete.Address,
                    Shift = empToDelete.Shift,
                    Gender = empToDelete.Gender,
                    OffboardDate = DateTime.Today.ToString("yyyy-MM-dd"),
                    OffboardReason = txtReason.Text.Trim(),
                    ExitNotes = txtExitNotes.Text.Trim()
                };

                db.OffboardedEmployees.Add(offboarded);
                db.Employees.Remove(empToDelete);
                await db.SaveChangesAsync();

                MessageBox.Show($"Employee {empToDelete.Name} has been offboarded and archived.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmpID.Clear(); txtReason.Clear(); txtExitNotes.Clear();
                panelEmpInfo.Visible = false; btnConfirm.Enabled = false;
                _emp = null!;
                LoadArchive();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void LoadArchive()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var archive = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.OrderByDescending(db.OffboardedEmployees, o => o.OffboardId));
                dgvArchive.DataSource = archive;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}

