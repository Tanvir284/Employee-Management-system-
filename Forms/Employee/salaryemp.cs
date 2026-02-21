using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class salaryemp : Form
    {
        public salaryemp()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

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

        private void IDTb_TextChanged(object sender, EventArgs e)
        {

        }

        private async void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emps = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(db.Employees, emp => new { emp.Name, emp.Id, emp.Salary }));
                dataGridView1.DataSource = emps;
            }
            catch { }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDTb.Text))
            {
                MessageBox.Show("Enter the Employee ID!!");
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await db.Employees.FindAsync(IDTb.Text.Trim());
                if (emp != null)
                {
                    nameTb1.Text = emp.Name;
                    IDTb1.Text = emp.Id;
                    salaryTb1.Text = emp.Salary;
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
    }
}
