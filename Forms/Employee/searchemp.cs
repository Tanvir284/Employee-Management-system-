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
    public partial class searchemp : Form
    {
        public searchemp()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}
