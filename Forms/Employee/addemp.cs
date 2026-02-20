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
                    Con.Open();
                    string query = "INSERT INTO employee(name, ID, age, salary, email, num, DOB, joindate, address, shift, gender) VALUES (@name, @ID, @age, @salary, @email, @num, @DOB, @joindate, @address, @shift, @gender)";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@name", nameTb.Text);
                    cmd.Parameters.AddWithValue("@ID", IDTb.Text);
                    cmd.Parameters.AddWithValue("@age", ageTb.Text);
                    cmd.Parameters.AddWithValue("@salary", salaryTb.Text);
                    cmd.Parameters.AddWithValue("@email", emailTb.Text);
                    cmd.Parameters.AddWithValue("@num", numTb.Text);
                    cmd.Parameters.AddWithValue("@DOB", DOBTb.Text);
                    cmd.Parameters.AddWithValue("@joindate", joindateTb.Text);
                    cmd.Parameters.AddWithValue("@address", addressTb.Text);
                    cmd.Parameters.AddWithValue("@shift", shiftTb.Text);
                    cmd.Parameters.AddWithValue("@gender", genderTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added.");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
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
