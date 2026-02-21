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
    public partial class deleteemp : Form
    {
        public deleteemp()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void populate()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Where(db.Employees, e => e.Id == IDTb.Text.Trim()));
                dataGridView1.DataSource = emp;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
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
            if (string.IsNullOrWhiteSpace(IDTb.Text))
            {
                MessageBox.Show("Enter the Employee ID who are leave!!");
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emp = await db.Employees.FindAsync(IDTb.Text.Trim());
                if (emp != null)
                {
                    db.Employees.Remove(emp);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Employee Delete Successfully.");
                    IDTb.Clear();
                    dataGridView1.DataSource = null;
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
