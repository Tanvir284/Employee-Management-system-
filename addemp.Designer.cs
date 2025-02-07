namespace Employeemanagment
{
    partial class addemp
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
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            button4 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            shiftTb = new ComboBox();
            joindateTb = new DateTimePicker();
            DOBTb = new DateTimePicker();
            genderTb = new ComboBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            IDTb = new TextBox();
            ageTb = new TextBox();
            salaryTb = new TextBox();
            emailTb = new TextBox();
            numTb = new TextBox();
            addressTb = new TextBox();
            nameTb = new TextBox();
            label4 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.World);
            label3.ForeColor = Color.Bisque;
            label3.Location = new Point(37, 37);
            label3.Name = "label3";
            label3.Size = new Size(55, 24);
            label3.TabIndex = 2;
            label3.Text = "ADMIN";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Bisque;
            label2.Location = new Point(203, 18);
            label2.Name = "label2";
            label2.Size = new Size(0, 28);
            label2.TabIndex = 1;
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Controls.Add(button4);
            panel2.Location = new Point(-4, 350);
            panel2.Name = "panel2";
            panel2.Size = new Size(670, 41);
            panel2.TabIndex = 37;
            // 
            // button4
            // 
            button4.Location = new Point(552, 7);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(99, 24);
            button4.TabIndex = 133;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 66);
            panel1.TabIndex = 36;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Bisque;
            label1.Location = new Point(224, 15);
            label1.Name = "label1";
            label1.Size = new Size(276, 31);
            label1.TabIndex = 0;
            label1.Text = "Employee Managment System";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Brown;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(-8, 72);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(120, 273);
            panel3.TabIndex = 35;
            // 
            // button3
            // 
            button3.Location = new Point(26, 162);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 2;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(26, 120);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 1;
            button2.Text = "logout";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(26, 77);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "Home Page";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // shiftTb
            // 
            shiftTb.FormattingEnabled = true;
            shiftTb.Items.AddRange(new object[] { "Morning", "Day", "Evening" });
            shiftTb.Location = new Point(477, 287);
            shiftTb.Margin = new Padding(3, 2, 3, 2);
            shiftTb.Name = "shiftTb";
            shiftTb.Size = new Size(57, 23);
            shiftTb.TabIndex = 68;
            // 
            // joindateTb
            // 
            joindateTb.Location = new Point(477, 206);
            joindateTb.Margin = new Padding(3, 2, 3, 2);
            joindateTb.Name = "joindateTb";
            joindateTb.Size = new Size(158, 23);
            joindateTb.TabIndex = 67;
            joindateTb.ValueChanged += joindateTb_ValueChanged;
            // 
            // DOBTb
            // 
            DOBTb.Location = new Point(477, 163);
            DOBTb.Margin = new Padding(3, 2, 3, 2);
            DOBTb.Name = "DOBTb";
            DOBTb.Size = new Size(158, 23);
            DOBTb.TabIndex = 66;
            // 
            // genderTb
            // 
            genderTb.FormattingEnabled = true;
            genderTb.Items.AddRange(new object[] { "Male", "Female", "Others" });
            genderTb.Location = new Point(298, 203);
            genderTb.Margin = new Padding(3, 2, 3, 2);
            genderTb.Name = "genderTb";
            genderTb.Size = new Size(57, 23);
            genderTb.TabIndex = 65;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(249, 206);
            label15.Name = "label15";
            label15.Size = new Size(49, 15);
            label15.TabIndex = 64;
            label15.Text = "Gender";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(431, 292);
            label14.Name = "label14";
            label14.Size = new Size(34, 15);
            label14.TabIndex = 63;
            label14.Text = "Shift";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(128, 291);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 62;
            label13.Text = "Email";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(389, 206);
            label12.Name = "label12";
            label12.Size = new Size(76, 15);
            label12.TabIndex = 61;
            label12.Text = "Joining Date";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(385, 163);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 60;
            label11.Text = "Date of Birth";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(137, 206);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 59;
            label10.Text = "Age";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(414, 248);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 58;
            label9.Text = "Address";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(133, 253);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 57;
            label8.Text = "Salary";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(378, 125);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 56;
            label7.Text = "Phone Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(147, 163);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 55;
            label6.Text = "ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(125, 128);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 54;
            label5.Text = "Name";
            // 
            // IDTb
            // 
            IDTb.Location = new Point(174, 161);
            IDTb.Margin = new Padding(3, 2, 3, 2);
            IDTb.Name = "IDTb";
            IDTb.Size = new Size(182, 23);
            IDTb.TabIndex = 53;
            // 
            // ageTb
            // 
            ageTb.Location = new Point(174, 204);
            ageTb.Margin = new Padding(3, 2, 3, 2);
            ageTb.Name = "ageTb";
            ageTb.Size = new Size(53, 23);
            ageTb.TabIndex = 52;
            // 
            // salaryTb
            // 
            salaryTb.Location = new Point(174, 247);
            salaryTb.Margin = new Padding(3, 2, 3, 2);
            salaryTb.Name = "salaryTb";
            salaryTb.Size = new Size(182, 23);
            salaryTb.TabIndex = 51;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(174, 289);
            emailTb.Margin = new Padding(3, 2, 3, 2);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(182, 23);
            emailTb.TabIndex = 50;
            // 
            // numTb
            // 
            numTb.Location = new Point(477, 122);
            numTb.Margin = new Padding(3, 2, 3, 2);
            numTb.Name = "numTb";
            numTb.Size = new Size(158, 23);
            numTb.TabIndex = 49;
            // 
            // addressTb
            // 
            addressTb.Location = new Point(477, 245);
            addressTb.Margin = new Padding(3, 2, 3, 2);
            addressTb.Name = "addressTb";
            addressTb.Size = new Size(158, 23);
            addressTb.TabIndex = 48;
            addressTb.TextChanged += addressTb_TextChanged;
            // 
            // nameTb
            // 
            nameTb.Location = new Point(174, 123);
            nameTb.Margin = new Padding(3, 2, 3, 2);
            nameTb.Multiline = true;
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(182, 23);
            nameTb.TabIndex = 47;
            nameTb.TextChanged += nameTb_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Brown;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Bisque;
            label4.Location = new Point(315, 81);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 46;
            label4.Text = "Add Employee";
            // 
            // addemp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 392);
            Controls.Add(shiftTb);
            Controls.Add(joindateTb);
            Controls.Add(DOBTb);
            Controls.Add(genderTb);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(IDTb);
            Controls.Add(ageTb);
            Controls.Add(salaryTb);
            Controls.Add(emailTb);
            Controls.Add(numTb);
            Controls.Add(addressTb);
            Controls.Add(nameTb);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "addemp";
            Text = "addemp";
            Load += addemp_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Panel panel2;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private ComboBox shiftTb;
        private DateTimePicker joindateTb;
        private DateTimePicker DOBTb;
        private ComboBox genderTb;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox IDTb;
        private TextBox ageTb;
        private TextBox salaryTb;
        private TextBox emailTb;
        private TextBox numTb;
        private TextBox addressTb;
        private TextBox nameTb;
        private Label label4;
        private Button button4;
    }
}