namespace NotesApplication
{
    partial class NewNoteForm
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
            cancelBTN = new Button();
            contentTB = new TextBox();
            okBTN = new Button();
            titleTB = new TextBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // cancelBTN
            // 
            cancelBTN.BackColor = Color.Black;
            cancelBTN.FlatAppearance.BorderSize = 0;
            cancelBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            cancelBTN.FlatStyle = FlatStyle.Flat;
            cancelBTN.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelBTN.ForeColor = Color.Lime;
            cancelBTN.Location = new Point(130, 339);
            cancelBTN.Name = "cancelBTN";
            cancelBTN.Size = new Size(94, 30);
            cancelBTN.TabIndex = 9;
            cancelBTN.Text = "Cancel";
            cancelBTN.UseVisualStyleBackColor = false;
            cancelBTN.Click += cancelBTN_Click;
            // 
            // contentTB
            // 
            contentTB.BackColor = Color.Black;
            contentTB.BorderStyle = BorderStyle.None;
            contentTB.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contentTB.ForeColor = Color.Lime;
            contentTB.Location = new Point(30, 67);
            contentTB.Multiline = true;
            contentTB.Name = "contentTB";
            contentTB.Size = new Size(540, 265);
            contentTB.TabIndex = 8;
            contentTB.Text = "Text";
            contentTB.Enter += contentTB_Enter;
            contentTB.Leave += contentTB_Leave;
            // 
            // okBTN
            // 
            okBTN.BackColor = Color.Black;
            okBTN.FlatAppearance.BorderSize = 0;
            okBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            okBTN.ForeColor = Color.Lime;
            okBTN.Location = new Point(30, 339);
            okBTN.Name = "okBTN";
            okBTN.Size = new Size(94, 30);
            okBTN.TabIndex = 7;
            okBTN.Text = "OK";
            okBTN.UseVisualStyleBackColor = false;
            okBTN.Click += okBTN_Click;
            // 
            // titleTB
            // 
            titleTB.BackColor = Color.Black;
            titleTB.BorderStyle = BorderStyle.None;
            titleTB.Font = new Font("OCR A Extended", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleTB.ForeColor = Color.Lime;
            titleTB.Location = new Point(30, 32);
            titleTB.Multiline = true;
            titleTB.Name = "titleTB";
            titleTB.Size = new Size(540, 30);
            titleTB.TabIndex = 6;
            titleTB.Text = "Title";
            titleTB.Enter += titleTB_Enter;
            titleTB.Leave += titleTB_Leave;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Black;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.ForeColor = Color.Lime;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(230, 339);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(340, 31);
            comboBox1.TabIndex = 10;
            // 
            // NewNoteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(600, 400);
            Controls.Add(comboBox1);
            Controls.Add(cancelBTN);
            Controls.Add(contentTB);
            Controls.Add(okBTN);
            Controls.Add(titleTB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewNoteForm";
            Text = "NewNoteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelBTN;
        private TextBox contentTB;
        private Button okBTN;
        private TextBox titleTB;
        private ComboBox comboBox1;
    }
}