using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class uuppddaattee : Form
    {
        public uuppddaattee()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        private async void populate()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Where(db.Employees, e => e.Id == IDTb.Text.Trim()));
                allemployeeDGV.DataSource = emp;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTb.Text) || string.IsNullOrWhiteSpace(ageTb.Text) || string.IsNullOrWhiteSpace(salaryTb.Text) || string.IsNullOrWhiteSpace(emailTb.Text) || string.IsNullOrWhiteSpace(numTb.Text) || string.IsNullOrWhiteSpace(DOBTb.Text) || string.IsNullOrWhiteSpace(joindateTb.Text) || string.IsNullOrWhiteSpace(addressTb.Text) || string.IsNullOrWhiteSpace(shiftTb.Text) || string.IsNullOrWhiteSpace(genderTb.Text))
            {
                MessageBox.Show("Missing Information!!");
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await db.Employees.FindAsync(IDTb.Text.Trim());
                if (emp != null)
                {
                    emp.Name = nameTb.Text.Trim();
                    emp.Age = ageTb.Text.Trim();
                    emp.Salary = salaryTb.Text.Trim();
                    emp.Email = emailTb.Text.Trim();
                    emp.Num = numTb.Text.Trim();
                    emp.Dob = DOBTb.Text.Trim();
                    emp.JoinDate = joindateTb.Text.Trim();
                    emp.Address = addressTb.Text.Trim();
                    emp.Shift = shiftTb.Text.Trim();
                    emp.Gender = genderTb.Text.Trim();
                    await db.SaveChangesAsync();
                    MessageBox.Show("Employee Update Successfully.");
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin add = new admin();
            add.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainDashboard f1 = new MainDashboard();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
