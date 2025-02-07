namespace Employeemanagment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(715, 66);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Bisque;
            label1.Location = new Point(187, 12);
            label1.Name = "label1";
            label1.Size = new Size(316, 35);
            label1.TabIndex = 0;
            label1.Text = "Employee Managment System";
            label1.TextAlign = ContentAlignment.BottomLeft;
            label1.UseCompatibleTextRendering = true;
            label1.Click += label1_Click_1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Location = new Point(-5, 363);
            panel2.Name = "panel2";
            panel2.Size = new Size(715, 30);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // button2
            // 
            button2.BackColor = Color.Brown;
            button2.ForeColor = Color.Cornsilk;
            button2.Location = new Point(555, 224);
            button2.Name = "button2";
            button2.Size = new Size(83, 34);
            button2.TabIndex = 3;
            button2.Text = "Employee";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Brown;
            button1.ForeColor = Color.BlanchedAlmond;
            button1.Location = new Point(446, 224);
            button1.Name = "button1";
            button1.Size = new Size(80, 34);
            button1.TabIndex = 1;
            button1.Text = "Admin";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-11, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(444, 292);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Brown;
            button3.ForeColor = Color.BlanchedAlmond;
            button3.Location = new Point(494, 276);
            button3.Name = "button3";
            button3.Size = new Size(92, 34);
            button3.TabIndex = 5;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(446, 137);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 81);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(558, 137);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(80, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(439, 114);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 8;
            label2.Text = "Admin Panel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(555, 114);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 9;
            label3.Text = "User Panel";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(469, 80);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(19, 21);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(494, 80);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 11;
            label4.Text = "LOGIN PAGE";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(659, 392);
            Controls.Add(label4);
            Controls.Add(pictureBox4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button3);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox4;
        private Label label4;
    }
}