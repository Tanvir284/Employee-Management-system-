using System.Drawing;
using System.Windows.Forms;

namespace Employeemanagment
{
    partial class DepartmentForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle    = new Label();
            btnBack     = new Button();
            panelInput  = new Panel();
            lblDeptIdH  = new Label(); txtDeptId   = new TextBox();
            lblNameH    = new Label(); txtName     = new TextBox();
            lblHeadH    = new Label(); txtHead     = new TextBox();
            lblDescH    = new Label(); txtDesc     = new TextBox();
            btnAdd      = new Button();
            btnUpdate   = new Button();
            btnDelete   = new Button();
            dgvDepts    = new DataGridView();

            panelHeader.SuspendLayout(); panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepts).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Text = "Department Management";
            BackColor = UITheme.BackDark;
            Controls.Add(panelHeader); Controls.Add(panelInput); Controls.Add(dgvDepts);
            Load += DepartmentForm_Load;

            // Header
            panelHeader.BackColor = UITheme.HeaderGrad1;
            panelHeader.Dock = DockStyle.Top; panelHeader.Height = 55;
            panelHeader.Controls.Add(lblTitle); panelHeader.Controls.Add(btnBack);

            lblTitle.Text = "🏢  Department Management";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true; lblTitle.Location = new System.Drawing.Point(120, 14);

            btnBack.Text = "◀ Dashboard"; btnBack.Location = new System.Drawing.Point(10, 13);
            btnBack.Size = new System.Drawing.Size(100, 30); btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnBack.ForeColor = System.Drawing.Color.White; btnBack.BackColor = System.Drawing.Color.Transparent;
            btnBack.Font = UITheme.FontBold; btnBack.Click += btnBack_Click;

            // Input panel
            panelInput.BackColor = UITheme.Card;
            panelInput.Location = new System.Drawing.Point(0, 55); panelInput.Size = new System.Drawing.Size(800, 130);
            panelInput.Controls.Add(lblDeptIdH); panelInput.Controls.Add(txtDeptId);
            panelInput.Controls.Add(lblNameH);   panelInput.Controls.Add(txtName);
            panelInput.Controls.Add(lblHeadH);   panelInput.Controls.Add(txtHead);
            panelInput.Controls.Add(lblDescH);   panelInput.Controls.Add(txtDesc);
            panelInput.Controls.Add(btnAdd); panelInput.Controls.Add(btnUpdate); panelInput.Controls.Add(btnDelete);

            void L(Label l, string t, int x, int y) { l.Text=t; l.Location=new System.Drawing.Point(x,y); l.Size=new System.Drawing.Size(80,22); l.Font=UITheme.FontSmall; l.ForeColor=UITheme.TextSecondary; }
            void T(TextBox tb, int x, int y, int w) { tb.Location=new System.Drawing.Point(x,y); tb.Size=new System.Drawing.Size(w,25); tb.BackColor=UITheme.Card; tb.ForeColor=UITheme.TextPrimary; tb.BorderStyle=BorderStyle.None; tb.Font=UITheme.FontBody; }

            L(lblDeptIdH,"Dept ID:", 15, 15);   T(txtDeptId, 90, 12, 80);  txtDeptId.ReadOnly = true; txtDeptId.BackColor = UITheme.BackDark;
            L(lblNameH,  "Name:",    190, 15);  T(txtName,   255, 12, 160);
            L(lblHeadH,  "Head ID:", 430, 15);  T(txtHead,   500, 12, 100);
            L(lblDescH,  "Desc:",    15, 60);   T(txtDesc,   90, 58, 510); txtDesc.Multiline = true; txtDesc.Height = 45;

            btnAdd.Text="✚ Add";       btnAdd.Location=new System.Drawing.Point(620, 15); btnAdd.Size=new System.Drawing.Size(80,30); btnAdd.FlatStyle=FlatStyle.Flat; btnAdd.FlatAppearance.BorderColor=UITheme.Accent; btnAdd.BackColor=UITheme.NavActive; btnAdd.ForeColor=UITheme.Accent; btnAdd.Font=UITheme.FontBold; btnAdd.Click+=btnAdd_Click;
            btnUpdate.Text="✎ Edit";   btnUpdate.Location=new System.Drawing.Point(620, 55); btnUpdate.Size=new System.Drawing.Size(80,30); btnUpdate.FlatStyle=FlatStyle.Flat; btnUpdate.FlatAppearance.BorderColor=UITheme.Warning; btnUpdate.BackColor=UITheme.NavActive; btnUpdate.ForeColor=UITheme.Warning; btnUpdate.Font=UITheme.FontBold; btnUpdate.Click+=btnUpdate_Click;
            btnDelete.Text="✖ Del";    btnDelete.Location=new System.Drawing.Point(710, 15); btnDelete.Size=new System.Drawing.Size(75,30); btnDelete.FlatStyle=FlatStyle.Flat; btnDelete.FlatAppearance.BorderColor=UITheme.Danger; btnDelete.BackColor=UITheme.NavActive; btnDelete.ForeColor=UITheme.Danger; btnDelete.Font=UITheme.FontBold; btnDelete.Click+=btnDelete_Click;

            // Grid
            dgvDepts.Location = new System.Drawing.Point(0, 185); dgvDepts.Size = new System.Drawing.Size(800, 415);
            dgvDepts.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            UITheme.StyleDataGrid(dgvDepts);
            dgvDepts.SelectionChanged += dgvDepts_SelectionChanged;

            panelHeader.ResumeLayout(false); panelInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDepts).EndInit();
            ResumeLayout(false);
        }

        private Panel panelHeader, panelInput;
        private Label lblTitle, lblDeptIdH, lblNameH, lblHeadH, lblDescH;
        private TextBox txtDeptId, txtName, txtHead, txtDesc;
        private Button btnAdd, btnUpdate, btnDelete, btnBack;
        private DataGridView dgvDepts;
    }
}
