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
    public partial class updateemp : Form
    {
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());
        public updateemp()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        private void updateemp_Load(object sender, EventArgs e)
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
        private async void populate()
        {
            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();
                var emps = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(db.Employees);
                allemployeeDGV.DataSource = emps;
            }
            catch { }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}