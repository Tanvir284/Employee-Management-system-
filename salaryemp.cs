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
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Documents\employeeDb.mdf;Integrated Security=True;Connect Timeout=30");

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

        private void IDTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Con.Open();
            string query = "select name, ID, salary from employee";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (IDTb.Text == "")
            {
                MessageBox.Show("Enter the Shift who are work now!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "select name, ID, salary from employee where ID='" + IDTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        nameTb1.Text = dr["name"].ToString();
                        IDTb1.Text = dr["ID"].ToString();
                        salaryTb1.Text = dr["salary"].ToString();

                    }
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
