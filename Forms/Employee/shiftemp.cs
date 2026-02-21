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
    public partial class shiftemp : Form
    {
        public shiftemp()
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void shiftTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(shiftTb.Text))
            {
                MessageBox.Show("Enter the Shift!!");
                return;
            }
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emps = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Select(
                        System.Linq.Queryable.Where(db.Employees, emp => emp.Shift == shiftTb.Text.Trim()),
                        emp => new { emp.Name, emp.Id, emp.Shift }));
                dataGridView1.DataSource = emps;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
