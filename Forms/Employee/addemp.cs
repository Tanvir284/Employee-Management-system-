using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Employeemanagment
{
    public partial class addemp : Form
    {

        public addemp()
        {
            InitializeComponent();
            UITheme.ApplyThemeToForm(this);
        }

        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        private void button4_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || IDTb.Text == "" || ageTb.Text == "" || salaryTb.Text == "" || emailTb.Text == "" || numTb.Text == "" || DOBTb.Text == "" || joindateTb.Text == "" || addressTb.Text == "" || shiftTb.Text == "" || genderTb.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    using var db = new Employeemanagment.Data.EmployeeDbContext();
                    var newEmp = new Employeemanagment.Data.Models.Employee
                    {
                        Id = IDTb.Text.Trim(),
                        Name = nameTb.Text.Trim(),
                        Age = ageTb.Text.Trim(),
                        Salary = salaryTb.Text.Trim(),
                        Email = emailTb.Text.Trim(),
                        Num = numTb.Text.Trim(),
                        Dob = DOBTb.Text.Trim(),
                        JoinDate = joindateTb.Text.Trim(),
                        Address = addressTb.Text.Trim(),
                        Shift = shiftTb.Text.Trim(),
                        Gender = genderTb.Text.Trim()
                    };
                    db.Employees.Add(newEmp);
                    db.SaveChanges();
                    MessageBox.Show("Employee Successfully Added.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainDashboard f1 = new MainDashboard();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin add = new admin();
            add.Show();
            this.Hide();
        }

        private void emailTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void addemp_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void joindateTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addressTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
