using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Employeemanagment
{
    public partial class SignUpForm : Form
    {
        SqlConnection Con = new SqlConnection(ConfigHelper.GetConnectionString());

        public SignUpForm()
        {
            InitializeComponent();
            // Centre the card whenever the form resizes
            Resize += (s, e) => CentreCard();
            CentreCard();
        }

        private void CentreCard()
        {
            panelCard.Location = new Point(
                (ClientSize.Width  - panelCard.Width)  / 2,
                (ClientSize.Height - panelCard.Height) / 2);
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.AddRange(new[] { "Admin", "Employee" });
            cmbRole.SelectedIndex = 1;
            // Gradient background
            this.Paint += (s, pe) =>
            {
                using var bg = new LinearGradientBrush(ClientRectangle,
                    Color.FromArgb(10, 18, 35), Color.FromArgb(8, 28, 55),
                    LinearGradientMode.ForwardDiagonal);
                pe.Graphics.FillRectangle(bg, ClientRectangle);
            };
            txtFullName.Focus();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullname = txtFullName.Text.Trim();
            string id       = txtId.Text.Trim();
            string pass     = txtPassword.Text;
            string confirm  = txtConfirm.Text;
            string email    = txtEmail.Text.Trim();
            string role     = cmbRole.SelectedItem?.ToString() ?? "Employee";

            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pass))
            { ShowMsg("Please fill all required fields.", true); return; }
            if (pass != confirm)
            { ShowMsg("Passwords do not match.", true); return; }
            if (pass.Length < 4)
            { ShowMsg("Password must be at least 4 characters.", true); return; }

            try
            {
                using var db = new Employeemanagment.Data.EmployeeDbContext();

                if (System.Linq.Enumerable.Any(db.Logins, l => l.Id == id))
                { ShowMsg("That Employee ID already exists. Choose another.", true); return; }

                string hashedPw = BCrypt.Net.BCrypt.HashPassword(pass);

                var newLogin = new Employeemanagment.Data.Models.Login
                {
                    Id = id,
                    Password = hashedPw,
                    Role = role,
                    FullName = fullname,
                    Email = email
                };

                db.Logins.Add(newLogin);
                db.SaveChanges();

                MessageBox.Show($"✅ Account created!\n\nID: {id}  |  Role: {role}\n\nYou can now login.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new ModernLogin().Show();
                this.Hide();
            }
            catch (Exception ex) { ShowMsg(ex.Message, true); }
        }

        private void ShowMsg(string msg, bool isError)
        {
            MessageBox.Show(msg, isError ? "Error" : "Info",
                MessageBoxButtons.OK, isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new ModernLogin().Show();
            this.Hide();
        }
    }
}
