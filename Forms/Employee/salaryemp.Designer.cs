namespace Employeemanagment
{
    partial class salaryemp
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            panel4 = new Panel();
            button6 = new Button();
            label5 = new Label();
            panel5 = new Panel();
            button4 = new Button();
            button5 = new Button();
            label6 = new Label();
            IDTb = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            IDTb1 = new Label();
            nameTb1 = new Label();
            salaryTb1 = new Label();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.CausesValidation = false;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Bisque;
            label2.Location = new Point(203, 18);
            label2.Name = "label2";
            label2.Size = new Size(0, 28);
            label2.TabIndex = 1;
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.CausesValidation = false;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Bisque;
            label1.Location = new Point(203, 8);
            label1.Name = "label1";
            label1.Size = new Size(276, 31);
            label1.TabIndex = 0;
            label1.Text = "Employee Managment System";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.CausesValidation = false;
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
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.CausesValidation = false;
            panel2.Location = new Point(-4, 350);
            panel2.Name = "panel2";
            panel2.Size = new Size(670, 41);
            panel2.TabIndex = 37;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Brown;
            panel3.CausesValidation = false;
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
            button3.CausesValidation = false;
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
            button2.CausesValidation = false;
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
            button1.CausesValidation = false;
            button1.Location = new Point(26, 77);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "Home Page";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.CausesValidation = false;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 66);
            panel1.TabIndex = 36;
            panel1.Paint += panel1_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Brown;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.CausesValidation = false;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Bisque;
            label4.Location = new Point(182, 70);
            label4.Name = "label4";
            label4.Size = new Size(142, 21);
            label4.TabIndex = 193;
            label4.Text = "Salary of Employees";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CausesValidation = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(118, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(261, 236);
            dataGridView1.TabIndex = 198;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Brown;
            panel4.Controls.Add(button6);
            panel4.Location = new Point(118, 95);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(536, 10);
            panel4.TabIndex = 208;
            // 
            // button6
            // 
            button6.Location = new Point(609, 8);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(82, 22);
            button6.TabIndex = 6;
            button6.Text = "Save";
            button6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Brown;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.CausesValidation = false;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.Bisque;
            label5.Location = new Point(459, 70);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 209;
            label5.Text = "Salary of Employee";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Brown;
            panel5.Controls.Add(button4);
            panel5.Location = new Point(385, 109);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 235);
            panel5.TabIndex = 210;
            // 
            // button4
            // 
            button4.Location = new Point(609, 8);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 6;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(480, 160);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(99, 24);
            button5.TabIndex = 213;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(418, 136);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 212;
            label6.Text = "ID";
            // 
            // IDTb
            // 
            IDTb.Location = new Point(444, 133);
            IDTb.Margin = new Padding(3, 2, 3, 2);
            IDTb.Name = "IDTb";
            IDTb.Size = new Size(182, 23);
            IDTb.TabIndex = 211;
            IDTb.TextChanged += IDTb_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(449, 219);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 214;
            label7.Text = "Name :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(469, 256);
            label8.Name = "label8";
            label8.Size = new Size(26, 15);
            label8.TabIndex = 215;
            label8.Text = "ID :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(449, 294);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 216;
            label9.Text = "Salary :";
            // 
            // IDTb1
            // 
            IDTb1.AutoSize = true;
            IDTb1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IDTb1.Location = new Point(501, 256);
            IDTb1.Name = "IDTb1";
            IDTb1.Size = new Size(57, 15);
            IDTb1.TabIndex = 218;
            IDTb1.Text = "__________";
            // 
            // nameTb1
            // 
            nameTb1.AutoSize = true;
            nameTb1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            nameTb1.Location = new Point(501, 219);
            nameTb1.Name = "nameTb1";
            nameTb1.Size = new Size(57, 15);
            nameTb1.TabIndex = 220;
            nameTb1.Text = "__________";
            // 
            // salaryTb1
            // 
            salaryTb1.AutoSize = true;
            salaryTb1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            salaryTb1.Location = new Point(501, 294);
            salaryTb1.Name = "salaryTb1";
            salaryTb1.Size = new Size(57, 15);
            salaryTb1.TabIndex = 221;
            salaryTb1.Text = "__________";
            // 
            // salaryemp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 392);
            Controls.Add(salaryTb1);
            Controls.Add(nameTb1);
            Controls.Add(IDTb1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(IDTb);
            Controls.Add(panel5);
            Controls.Add(label5);
            Controls.Add(panel4);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "salaryemp";
            Text = "salaryemp";
            NewMethod();
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

            void NewMethod()
            {
                panel3.ResumeLayout(false);
            }
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel1;
        private Label label4;
        private DataGridView dataGridView1;
        private Panel panel4;
        private Button button6;
        private Label label5;
        private Panel panel5;
        private Button button4;
        private Button button5;
        private Label label6;
        private TextBox IDTb;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label IDTb1;
        private Label nameTb1;
        private Label salaryTb1;
    }
}