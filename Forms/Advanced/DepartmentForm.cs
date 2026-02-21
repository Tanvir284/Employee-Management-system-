using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class DepartmentForm : Form
    {

        public DepartmentForm()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadDepartments();
        }

        private void ApplyTheme()
        {
            this.BackColor = UITheme.BackDark;
            panelHeader.BackColor = UITheme.HeaderGrad1;
            UITheme.StyleDataGrid(dgvDepts);
            UITheme.StyleFlatButton(btnAdd, UITheme.Accent);
            UITheme.StyleFlatButton(btnDelete, UITheme.Danger);
            UITheme.StyleFlatButton(btnUpdate, UITheme.Warning);
            UITheme.StyleFlatButton(btnBack, UITheme.TextSecondary);
            foreach (Control c in panelInput.Controls)
            {
                if (c is Label lbl) { lbl.ForeColor = UITheme.TextSecondary; lbl.BackColor = Color.Transparent; }
                if (c is TextBox tb) { tb.BackColor = UITheme.Card; tb.ForeColor = UITheme.TextPrimary; tb.BorderStyle = BorderStyle.None; }
            }
            panelInput.BackColor = UITheme.Card;
        }

        private async void LoadDepartments()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var depts = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.OrderBy(db.Departments, d => d.DeptId));
                dgvDepts.DataSource = depts;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvDepts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepts.CurrentRow == null) return;
            var row = dgvDepts.CurrentRow;
            txtDeptId.Text   = row.Cells["DeptId"].Value?.ToString() ?? "";
            txtName.Text     = row.Cells["Name"].Value?.ToString() ?? "";
            txtHead.Text     = row.Cells["HeadEmployeeId"].Value?.ToString() ?? "";
            txtDesc.Text     = row.Cells["Description"].Value?.ToString() ?? "";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Enter department name."); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var newDept = new Employeemanagment.Data.Models.Department
                {
                    Name = txtName.Text.Trim(),
                    HeadEmployeeId = txtHead.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                    CreatedDate = DateTime.Today.ToString("yyyy-MM-dd")
                };
                db.Departments.Add(newDept);
                await db.SaveChangesAsync();
                MessageBox.Show("Department added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear(); txtHead.Clear(); txtDesc.Clear(); txtDeptId.Clear();
                LoadDepartments();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDeptId.Text, out int id)) { MessageBox.Show("Select a department first."); return; }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var dept = await db.Departments.FindAsync(id);
                if (dept != null)
                {
                    dept.Name = txtName.Text.Trim();
                    dept.HeadEmployeeId = txtHead.Text.Trim();
                    dept.Description = txtDesc.Text.Trim();
                    await db.SaveChangesAsync();
                    MessageBox.Show("Department updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartments();
                }
                else { MessageBox.Show("Department not found."); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDeptId.Text, out int id)) { MessageBox.Show("Select a department first."); return; }
            if (MessageBox.Show("Delete this department?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var dept = await db.Departments.FindAsync(id);
                if (dept != null)
                {
                    db.Departments.Remove(dept);
                    await db.SaveChangesAsync();
                    txtDeptId.Clear(); txtName.Clear(); txtHead.Clear(); txtDesc.Clear();
                    LoadDepartments();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e) { new MainDashboard().Show(); this.Hide(); }
    }
}
