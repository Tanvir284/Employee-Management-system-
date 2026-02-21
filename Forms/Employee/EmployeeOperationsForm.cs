using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Employeemanagment.Data;
using Employeemanagment.Data.Models;

namespace Employeemanagment
{
    public partial class EmployeeOperationsForm : Form
    {
        private string CurrentMode = "ADD";
        private string EditId = "";

        public EmployeeOperationsForm(string startMode = "ADD")
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
            SwitchTab(startMode);
        }

        private void EmployeeOperationsForm_Load(object sender, EventArgs e)
        {
            dtpDOB.Value = DateTime.Today.AddYears(-25);
            dtpJoinDate.Value = DateTime.Today;
            cmbGender.SelectedIndex = 0;
            cmbShift.SelectedIndex = 0;
            LoadEmployees();
        }

        private void SwitchTab(string mode)
        {
            if (mode == "ADD")
            {
                CurrentMode = "ADD";
                pnlInputContainer.Visible = true;
                pnlManage.Visible = false;
                UITheme.ActivateNav(btnTabAdd, this);
                btnSave.Text = "✔ Add Employee";
                ClearInputs();
                txtID.ReadOnly = false;
            }
            else if (mode == "MANAGE")
            {
                pnlInputContainer.Visible = false;
                pnlManage.Visible = true;
                UITheme.ActivateNav(btnTabManage, this);
                LoadEmployees();
            }
            else if (mode == "EDIT")
            {
                CurrentMode = "EDIT";
                pnlInputContainer.Visible = true;
                pnlManage.Visible = false;
                UITheme.ActivateNav(btnTabManage, this); // Keep Manage active to show we came from there
                btnSave.Text = "✔ Update Employee";
                txtID.ReadOnly = true; // Cannot edit ID
            }
        }

        private async void LoadEmployees(string search = "")
        {
            try
            {
                using var db = new EmployeeDbContext();
                var query = db.Employees.AsQueryable();
                
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(e => e.Id.ToLower().Contains(search) || e.Name.ToLower().Contains(search));
                }

                var list = await query.Select(e => new {
                    e.Id, e.Name, e.Age, e.Gender, e.Email, e.Num,
                    DOB = e.Dob, Join = e.JoinDate, e.Shift, e.Salary
                }).ToListAsync();

                dgvEmployees.DataSource = list;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadEmployees(txtSearch.Text);

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Employee ID and Name are required.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new EmployeeDbContext();
                if (CurrentMode == "ADD")
                {
                    if (await db.Employees.AnyAsync(e => e.Id == txtID.Text.Trim()))
                    {
                        MessageBox.Show("An employee with this ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var emp = new Employee
                    {
                        Id = txtID.Text.Trim(),
                        Name = txtName.Text.Trim(),
                        Age = txtAge.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Gender = cmbGender.SelectedItem?.ToString(),
                        Shift = cmbShift.SelectedItem?.ToString(),
                        Dob = dtpDOB.Value.ToString("yyyy-MM-dd"),
                        JoinDate = dtpJoinDate.Value.ToString("yyyy-MM-dd"),
                        Email = txtEmail.Text.Trim(),
                        Num = txtPhone.Text.Trim(),
                        Salary = txtSalary.Text.Trim()
                    };
                    db.Employees.Add(emp);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Employee Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                }
                else if (CurrentMode == "EDIT")
                {
                    var emp = await db.Employees.FindAsync(EditId);
                    if (emp != null)
                    {
                        emp.Name = txtName.Text.Trim();
                        emp.Age = txtAge.Text.Trim();
                        emp.Address = txtAddress.Text.Trim();
                        emp.Gender = cmbGender.SelectedItem?.ToString();
                        emp.Shift = cmbShift.SelectedItem?.ToString();
                        emp.Dob = dtpDOB.Value.ToString("yyyy-MM-dd");
                        emp.JoinDate = dtpJoinDate.Value.ToString("yyyy-MM-dd");
                        emp.Email = txtEmail.Text.Trim();
                        emp.Num = txtPhone.Text.Trim();
                        emp.Salary = txtSalary.Text.Trim();
                        await db.SaveChangesAsync();
                        MessageBox.Show("Employee Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SwitchTab("MANAGE");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error saving: " + ex.Message, "Error"); }
        }

        private async void btnUpdateSelected_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) { MessageBox.Show("Please select an employee."); return; }
            string id = dgvEmployees.CurrentRow.Cells["Id"].Value?.ToString() ?? "";
            
            try
            {
                using var db = new EmployeeDbContext();
                var emp = await db.Employees.FindAsync(id);
                if (emp != null)
                {
                    EditId = emp.Id;
                    txtID.Text = emp.Id;
                    txtName.Text = emp.Name;
                    txtAge.Text = emp.Age;
                    txtAddress.Text = emp.Address;
                    cmbGender.SelectedItem = emp.Gender;
                    cmbShift.SelectedItem = emp.Shift;
                    txtEmail.Text = emp.Email;
                    txtPhone.Text = emp.Num;
                    txtSalary.Text = emp.Salary;
                    
                    if (DateTime.TryParse(emp.Dob, out DateTime dDob)) dtpDOB.Value = dDob;
                    if (DateTime.TryParse(emp.JoinDate, out DateTime dJoin)) dtpJoinDate.Value = dJoin;
                    
                    SwitchTab("EDIT");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) { MessageBox.Show("Please select an employee."); return; }
            string id = dgvEmployees.CurrentRow.Cells["Id"].Value?.ToString() ?? "";
            string name = dgvEmployees.CurrentRow.Cells["Name"].Value?.ToString() ?? "";

            if (MessageBox.Show($"Are you sure you want to completely delete {name} ({id})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using var db = new EmployeeDbContext();
                    var emp = await db.Employees.FindAsync(id);
                    if (emp != null)
                    {
                        db.Employees.Remove(emp);
                        await db.SaveChangesAsync();
                        LoadEmployees();
                        MessageBox.Show("Employee Deleted.");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (CurrentMode == "ADD") ClearInputs();
        }

        private void ClearInputs()
        {
            txtID.Clear(); txtName.Clear(); txtAge.Clear(); txtAddress.Clear(); 
            txtEmail.Clear(); txtPhone.Clear(); txtSalary.Clear();
            cmbGender.SelectedIndex = 0; cmbShift.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today.AddYears(-25);
            dtpJoinDate.Value = DateTime.Today;
        }

        private void btnBack_Click(object sender, EventArgs e) { new admin().Show(); this.Hide(); }
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
