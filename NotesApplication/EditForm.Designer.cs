namespace NotesApplication
{
    partial class EditForm
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
            titleTB = new TextBox();
            okBTN = new Button();
            button2 = new Button();
            contentTB = new TextBox();
            cancelBTN = new Button();
            SuspendLayout();
            // 
            // titleTB
            // 
            titleTB.BackColor = Color.Black;
            titleTB.BorderStyle = BorderStyle.None;
            titleTB.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleTB.ForeColor = Color.Lime;
            titleTB.Location = new Point(30, 30);
            titleTB.Multiline = true;
            titleTB.Name = "titleTB";
            titleTB.Size = new Size(540, 30);
            titleTB.TabIndex = 0;
            titleTB.Text = "Title";
            titleTB.Enter += titleTB_Enter;
            titleTB.Leave += titleTB_Leave;
            // 
            // okBTN
            // 
            okBTN.BackColor = Color.Black;
            okBTN.FlatAppearance.BorderSize = 0;
            okBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            okBTN.ForeColor = Color.Lime;
            okBTN.Location = new Point(30, 337);
            okBTN.Name = "okBTN";
            okBTN.Size = new Size(94, 30);
            okBTN.TabIndex = 2;
            okBTN.Text = "OK";
            okBTN.UseVisualStyleBackColor = false;
            okBTN.Click += okBTN_Click;
            // 
            // button2
            // 
            button2.Location = new Point(253, 185);
            button2.Name = "button2";
            button2.Size = new Size(0, 0);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // contentTB
            // 
            contentTB.BackColor = Color.Black;
            contentTB.BorderStyle = BorderStyle.None;
            contentTB.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contentTB.ForeColor = Color.Lime;
            contentTB.Location = new Point(30, 65);
            contentTB.Multiline = true;
            contentTB.Name = "contentTB";
            contentTB.Size = new Size(540, 265);
            contentTB.TabIndex = 4;
            contentTB.Text = "Text";
            contentTB.Enter += contentTB_Enter;
            contentTB.Leave += contentTB_Leave;
            // 
            // cancelBTN
            // 
            cancelBTN.BackColor = Color.Black;
            cancelBTN.FlatAppearance.BorderSize = 0;
            cancelBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            cancelBTN.FlatStyle = FlatStyle.Flat;
            cancelBTN.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelBTN.ForeColor = Color.Lime;
            cancelBTN.Location = new Point(130, 337);
            cancelBTN.Name = "cancelBTN";
            cancelBTN.Size = new Size(94, 30);
            cancelBTN.TabIndex = 5;
            cancelBTN.Text = "Cancel";
            cancelBTN.UseVisualStyleBackColor = false;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(600, 400);
            Controls.Add(cancelBTN);
            Controls.Add(contentTB);
            Controls.Add(button2);
            Controls.Add(okBTN);
            Controls.Add(titleTB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditForm";
            Text = "EditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTB;
        private TextBox textTB;
        private Button okBTN;
        private Button button2;
        private TextBox contentTB;
        private Button cancelBTN;
    }
}