namespace Employeemanagment
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            name = new Label();
            pass = new Label();
            idTb = new TextBox();
            passTb = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label5 = new Label();
            button3 = new Button();
            button5 = new Button();
            button4 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.BackColor = SystemColors.ControlDark;
            name.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            name.Location = new Point(254, 131);
            name.Name = "name";
            name.Size = new Size(76, 19);
            name.TabIndex = 3;
            name.Text = "Username";
            name.Click += label2_Click;
            // 
            // pass
            // 
            pass.AutoSize = true;
            pass.BackColor = SystemColors.ControlDark;
            pass.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            pass.Location = new Point(259, 169);
            pass.Name = "pass";
            pass.Size = new Size(71, 19);
            pass.TabIndex = 4;
            pass.Text = "Password";
            pass.TextAlign = ContentAlignment.BottomRight;
            pass.Click += label3_Click;
            // 
            // idTb
            // 
            idTb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            idTb.Location = new Point(336, 126);
            idTb.Multiline = true;
            idTb.Name = "idTb";
            idTb.Size = new Size(202, 24);
            idTb.TabIndex = 5;
            idTb.TextChanged += textBox1_TextChanged;
            // 
            // passTb
            // 
            passTb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passTb.Location = new Point(336, 164);
            passTb.Multiline = true;
            passTb.Name = "passTb";
            passTb.PasswordChar = '*';
            passTb.Size = new Size(202, 27);
            passTb.TabIndex = 10;
            passTb.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Brown;
            button1.ForeColor = Color.Bisque;
            button1.Location = new Point(259, 218);
            button1.Name = "button1";
            button1.Size = new Size(128, 34);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Brown;
            button2.ForeColor = Color.Bisque;
            button2.Location = new Point(336, 258);
            button2.Name = "button2";
            button2.Size = new Size(128, 35);
            button2.TabIndex = 8;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(660, 66);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Bisque;
            label1.Location = new Point(199, 18);
            label1.Name = "label1";
            label1.Size = new Size(276, 31);
            label1.TabIndex = 0;
            label1.Text = "Employee Managment System";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Location = new Point(-2, 355);
            panel2.Name = "panel2";
            panel2.Size = new Size(660, 38);
            panel2.TabIndex = 10;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(311, 85);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(19, 21);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(336, 85);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 12;
            label4.Text = "LOGIN PAGE";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Brown;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button5);
            panel3.Location = new Point(1, 72);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(120, 278);
            panel3.TabIndex = 203;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.World);
            label6.ForeColor = Color.Bisque;
            label6.Location = new Point(29, 36);
            label6.Name = "label6";
            label6.Size = new Size(50, 24);
            label6.TabIndex = 3;
            label6.Text = "Admin";
            label6.TextAlign = ContentAlignment.TopCenter;
            label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.World);
            label5.ForeColor = Color.Bisque;
            label5.Location = new Point(13, 60);
            label5.Name = "label5";
            label5.Size = new Size(80, 24);
            label5.TabIndex = 2;
            label5.Text = "Login Page";
            label5.TextAlign = ContentAlignment.TopCenter;
            label5.UseCompatibleTextRendering = true;
            label5.Click += label5_Click;
            // 
            // button3
            // 
            button3.Location = new Point(13, 135);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 2;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(13, 97);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(82, 22);
            button5.TabIndex = 0;
            button5.Text = "Home Page";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Brown;
            button4.ForeColor = Color.Bisque;
            button4.Location = new Point(410, 218);
            button4.Name = "button4";
            button4.Size = new Size(128, 34);
            button4.TabIndex = 204;
            button4.Text = "Signup";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(659, 392);
            Controls.Add(button4);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(pictureBox4);
            Controls.Add(passTb);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(idTb);
            Controls.Add(pass);
            Controls.Add(name);
            Name = "login";
            Text = "login";
            Load += login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label name;
        private Label pass;
        private TextBox idTb;
        private TextBox passTb;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private PictureBox pictureBox4;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Button button3;
        private Button button5;
        private Label label6;
        private Button button4;
    }
}