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
    public partial class uuppddaattee : Form
    {
        public uuppddaattee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        private void populate()
        {
            Con.Open();
            string query = "select * from employee where ID=@ID";
            using SqlCommand cmd = new SqlCommand(query, Con);
            cmd.Parameters.AddWithValue("@ID", IDTb.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            allemployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || ageTb.Text == "" || salaryTb.Text == "" || emailTb.Text == "" || numTb.Text == "" || DOBTb.Text == "" || joindateTb.Text == "" || addressTb.Text == "" || shiftTb.Text == "" || genderTb.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update employee set name=@name, ID=@ID, age=@age, salary=@salary, email=@email, num=@num, DOB=@DOB, joindate=@joindate, address=@address, shift=@shift, gender=@gender where ID=@ID";
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
                    MessageBox.Show("Employee Update Successfully.");
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
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
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
