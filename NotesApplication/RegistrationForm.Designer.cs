namespace NotesApplication
{
    partial class RegistrationForm
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
            usernameTB = new TextBox();
            passwordTB = new TextBox();
            RegBTN = new Button();
            exitBTN = new Button();
            regLableStatus = new Label();
            backBTN = new Button();
            SuspendLayout();
            // 
            // usernameTB
            // 
            usernameTB.BackColor = Color.Black;
            usernameTB.BorderStyle = BorderStyle.None;
            usernameTB.Font = new Font("OCR A Extended", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTB.ForeColor = Color.Lime;
            usernameTB.Location = new Point(42, 65);
            usernameTB.Multiline = true;
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(319, 70);
            usernameTB.TabIndex = 0;
            usernameTB.Text = "Username";
            usernameTB.TextAlign = HorizontalAlignment.Center;
            usernameTB.Enter += usernameTB_Enter;
            usernameTB.Leave += usernameTB_Leave;
            // 
            // passwordTB
            // 
            passwordTB.BackColor = Color.Black;
            passwordTB.BorderStyle = BorderStyle.None;
            passwordTB.Font = new Font("OCR A Extended", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTB.ForeColor = Color.Lime;
            passwordTB.Location = new Point(42, 141);
            passwordTB.Multiline = true;
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(319, 70);
            passwordTB.TabIndex = 1;
            passwordTB.Text = "Password";
            passwordTB.TextAlign = HorizontalAlignment.Center;
            passwordTB.TextChanged += passwordTB_TextChanged;
            passwordTB.Enter += passwordTB_Enter;
            passwordTB.Leave += passwordTB_Leave;
            // 
            // RegBTN
            // 
            RegBTN.BackColor = Color.Black;
            RegBTN.FlatAppearance.BorderSize = 0;
            RegBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            RegBTN.FlatStyle = FlatStyle.Flat;
            RegBTN.Font = new Font("OCR A Extended", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegBTN.ForeColor = Color.Lime;
            RegBTN.Location = new Point(42, 217);
            RegBTN.Name = "RegBTN";
            RegBTN.Size = new Size(319, 70);
            RegBTN.TabIndex = 3;
            RegBTN.Text = "Registration";
            RegBTN.UseVisualStyleBackColor = false;
            RegBTN.Click += RegBTN_Click;
            // 
            // exitBTN
            // 
            exitBTN.BackColor = Color.Black;
            exitBTN.FlatAppearance.BorderSize = 0;
            exitBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            exitBTN.FlatStyle = FlatStyle.Flat;
            exitBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBTN.ForeColor = Color.Lime;
            exitBTN.Location = new Point(358, 12);
            exitBTN.Name = "exitBTN";
            exitBTN.Size = new Size(30, 30);
            exitBTN.TabIndex = 4;
            exitBTN.Text = "x";
            exitBTN.UseVisualStyleBackColor = false;
            exitBTN.Click += exitBTN_Click;
            // 
            // regLableStatus
            // 
            regLableStatus.AutoSize = true;
            regLableStatus.FlatStyle = FlatStyle.Flat;
            regLableStatus.Font = new Font("OCR A Extended", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            regLableStatus.ForeColor = Color.Lime;
            regLableStatus.Location = new Point(12, 371);
            regLableStatus.Name = "regLableStatus";
            regLableStatus.Size = new Size(0, 18);
            regLableStatus.TabIndex = 5;
            regLableStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backBTN
            // 
            backBTN.BackColor = Color.Black;
            backBTN.FlatAppearance.BorderSize = 0;
            backBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            backBTN.FlatStyle = FlatStyle.Flat;
            backBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBTN.ForeColor = Color.Lime;
            backBTN.Location = new Point(12, 12);
            backBTN.Name = "backBTN";
            backBTN.Size = new Size(30, 30);
            backBTN.TabIndex = 6;
            backBTN.Text = "<";
            backBTN.UseVisualStyleBackColor = false;
            backBTN.Click += backBTN_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(400, 400);
            Controls.Add(backBTN);
            Controls.Add(regLableStatus);
            Controls.Add(exitBTN);
            Controls.Add(RegBTN);
            Controls.Add(passwordTB);
            Controls.Add(usernameTB);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(400, 400);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(400, 400);
            Name = "RegistrationForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authorisation";
            MouseDown += RegistrationForm_MouseDown;
            MouseMove += RegistrationForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTB;
        private TextBox passwordTB;
        private Button RegBTN;
        private Button exitBTN;
        private Label regLableStatus;
        private Button backBTN;
    }
}