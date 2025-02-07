using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addemp ae = new addemp();
            ae.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchemp se = new searchemp();
            se.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateemp ue = new updateemp();
            ue.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            salaryemp salary = new salaryemp();
            salary.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            deleteemp de = new deleteemp();
            de.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shiftemp shift = new shiftemp();
            shift.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            uuppddaattee up = new uuppddaattee();
            up.Show();
            this.Hide();
        }
    }
}
