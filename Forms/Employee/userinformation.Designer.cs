namespace Employeemanagment
{
    partial class userinformation
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button6 = new Button();
            panel4 = new Panel();
            button4 = new Button();
            button2 = new Button();
            label4 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            button3 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Gainsboro;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(117, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(537, 236);
            dataGridView1.TabIndex = 210;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Bisque;
            label1.Location = new Point(203, 15);
            label1.Name = "label1";
            label1.Size = new Size(276, 31);
            label1.TabIndex = 0;
            label1.Text = "Employee Managment System";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseCompatibleTextRendering = true;
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
            // panel4
            // 
            panel4.BackColor = Color.Brown;
            panel4.Controls.Add(button6);
            panel4.Location = new Point(116, 93);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(539, 10);
            panel4.TabIndex = 207;
            // 
            // button4
            // 
            button4.Location = new Point(559, 7);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(99, 32);
            button4.TabIndex = 132;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Brown;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Bisque;
            label4.Location = new Point(342, 70);
            label4.Name = "label4";
            label4.Size = new Size(88, 21);
            label4.TabIndex = 205;
            label4.Text = "Information";
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
            panel3.TabIndex = 202;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.World);
            label3.ForeColor = Color.Bisque;
            label3.Location = new Point(46, 39);
            label3.Name = "label3";
            label3.Size = new Size(40, 24);
            label3.TabIndex = 2;
            label3.Text = "USER";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.UseCompatibleTextRendering = true;
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
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 66);
            panel1.TabIndex = 203;
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
            panel2.TabIndex = 204;
            // 
            // userinformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 392);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "userinformation";
            Text = "userinformation";
            Load += userinformation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button6;
        private Panel panel4;
        private Button button4;
        private Button button2;
        private Label label4;
        private Panel panel3;
        private Label label3;
        private Button button3;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
    }
}