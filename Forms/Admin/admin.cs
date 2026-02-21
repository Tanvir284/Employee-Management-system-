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
            UITheme.ApplyThemeToForm(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            MainDashboard f1 = new MainDashboard();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainDashboard f1 = new MainDashboard();
            f1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("ADD");
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void admin_Load(object sender, EventArgs e) { }

        private void button10_Click(object sender, EventArgs e)
        {
            var f = new EmployeeOperationsForm("MANAGE");
            f.Show();
            this.Hide();
        }

        // ── Advanced Feature Buttons ──────────────────────────────────────────
        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceForm af = new AttendanceForm();
            af.Show();
            this.Hide();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            LeaveManagementForm lm = new LeaveManagementForm();
            lm.Show();
            this.Hide();
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            PerformanceReviewForm pr = new PerformanceReviewForm();
            pr.Show();
            this.Hide();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            PayrollForecastForm pf = new PayrollForecastForm();
            pf.Show();
            this.Hide();
        }

        private void btnOffboarding_Click(object sender, EventArgs e)
        {
            OffboardingForm of = new OffboardingForm();
            of.Show();
            this.Hide();
        }

        private void btnHRInsights_Click(object sender, EventArgs e)
        {
            HRInsightsForm hr = new HRInsightsForm();
            hr.Show();
            this.Hide();
        }
    }
}

