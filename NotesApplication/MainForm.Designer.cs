namespace NotesApplication
{
    partial class MainForm
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
            panel = new Panel();
            deleteBTN = new Button();
            addCategoryBTN = new Button();
            addNoteBTN = new Button();
            treeView1 = new TreeView();
            logoutBTN = new Button();
            editBTN = new Button();
            exitBTN = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(deleteBTN);
            panel.Controls.Add(addCategoryBTN);
            panel.Controls.Add(addNoteBTN);
            panel.Controls.Add(treeView1);
            panel.Controls.Add(logoutBTN);
            panel.Controls.Add(editBTN);
            panel.Controls.Add(exitBTN);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(800, 600);
            panel.TabIndex = 0;
            panel.MouseDown += panel_MouseDown;
            panel.MouseMove += panel_MouseMove;
            // 
            // deleteBTN
            // 
            deleteBTN.BackColor = Color.Black;
            deleteBTN.FlatAppearance.BorderSize = 0;
            deleteBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            deleteBTN.FlatStyle = FlatStyle.Flat;
            deleteBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteBTN.ForeColor = Color.Lime;
            deleteBTN.Location = new Point(418, 114);
            deleteBTN.Name = "deleteBTN";
            deleteBTN.Size = new Size(370, 55);
            deleteBTN.TabIndex = 10;
            deleteBTN.Text = "Delete";
            deleteBTN.UseVisualStyleBackColor = false;
            deleteBTN.Click += deleteBTN_Click;
            // 
            // addCategoryBTN
            // 
            addCategoryBTN.BackColor = Color.Black;
            addCategoryBTN.FlatAppearance.BorderSize = 0;
            addCategoryBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            addCategoryBTN.FlatStyle = FlatStyle.Flat;
            addCategoryBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addCategoryBTN.ForeColor = Color.Lime;
            addCategoryBTN.Location = new Point(418, 175);
            addCategoryBTN.Name = "addCategoryBTN";
            addCategoryBTN.Size = new Size(179, 55);
            addCategoryBTN.TabIndex = 7;
            addCategoryBTN.Text = "Add Category";
            addCategoryBTN.UseVisualStyleBackColor = false;
            addCategoryBTN.Click += addCategoryBTN_Click;
            // 
            // addNoteBTN
            // 
            addNoteBTN.BackColor = Color.Black;
            addNoteBTN.FlatAppearance.BorderSize = 0;
            addNoteBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            addNoteBTN.FlatStyle = FlatStyle.Flat;
            addNoteBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addNoteBTN.ForeColor = Color.Lime;
            addNoteBTN.Location = new Point(609, 175);
            addNoteBTN.Name = "addNoteBTN";
            addNoteBTN.Size = new Size(179, 55);
            addNoteBTN.TabIndex = 6;
            addNoteBTN.Text = "Add Note";
            addNoteBTN.UseVisualStyleBackColor = false;
            addNoteBTN.Click += addNoteBTN_Click;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.Black;
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            treeView1.ForeColor = Color.Lime;
            treeView1.LineColor = Color.Lime;
            treeView1.Location = new Point(12, 53);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(400, 535);
            treeView1.TabIndex = 5;
            // 
            // logoutBTN
            // 
            logoutBTN.BackColor = Color.Black;
            logoutBTN.FlatAppearance.BorderSize = 0;
            logoutBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            logoutBTN.FlatStyle = FlatStyle.Flat;
            logoutBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutBTN.ForeColor = Color.Lime;
            logoutBTN.Location = new Point(12, 12);
            logoutBTN.Name = "logoutBTN";
            logoutBTN.Size = new Size(116, 30);
            logoutBTN.TabIndex = 4;
            logoutBTN.Text = "Log out";
            logoutBTN.UseVisualStyleBackColor = false;
            logoutBTN.Click += logoutBTN_Click;
            // 
            // editBTN
            // 
            editBTN.BackColor = Color.Black;
            editBTN.FlatAppearance.BorderSize = 0;
            editBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            editBTN.FlatStyle = FlatStyle.Flat;
            editBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editBTN.ForeColor = Color.Lime;
            editBTN.Location = new Point(418, 53);
            editBTN.Name = "editBTN";
            editBTN.Size = new Size(370, 55);
            editBTN.TabIndex = 3;
            editBTN.Text = "Edit / View";
            editBTN.UseVisualStyleBackColor = false;
            editBTN.Click += editBTN_Click;
            // 
            // exitBTN
            // 
            exitBTN.BackColor = Color.Black;
            exitBTN.FlatAppearance.BorderSize = 0;
            exitBTN.FlatStyle = FlatStyle.Flat;
            exitBTN.Font = new Font("OCR A Extended", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBTN.ForeColor = Color.Lime;
            exitBTN.Location = new Point(758, 12);
            exitBTN.Name = "exitBTN";
            exitBTN.Size = new Size(30, 30);
            exitBTN.TabIndex = 1;
            exitBTN.Text = "x";
            exitBTN.UseVisualStyleBackColor = false;
            exitBTN.Click += exitBTN_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 600);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notes";
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button exitBTN;
        private Button editBTN;
        private Button logoutBTN;
        private TreeView treeView1;
        private Button addNoteBTN;
        private Button addCategoryBTN;
        private Button deleteBTN;
    }
}