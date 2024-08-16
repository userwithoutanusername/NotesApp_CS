using Microsoft.VisualBasic.ApplicationServices;
using NotesLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApplication
{
    public partial class MainForm : Form
    {

        private DataBase database;
        private int userID_;

        public MainForm(int userID)
        {
            InitializeComponent();
            database = new DataBase();
            this.userID_ = userID;
            RefreshTreeView();
        }

        #region Buttons 

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            CreateMyForm(form, 300, 100);

            Button okBTN = new Button();
            CreateMyOKBTN(okBTN, 10, 40);
            okBTN.Click += (s, args) =>
            {
                this.Close();
                AuthorisationForm authorizationForm = new AuthorisationForm();
                authorizationForm.Show();
            };

            Button cancelBTN = new Button();
            CreateMyCancelBTN(cancelBTN, 100, 40);
            cancelBTN.Click += (s, args) => form.Close();


            Label label = new Label();
            CreateMyLabel(label, "Are you sure?", 12);

            form.Controls.Add(label);
            form.Controls.Add(okBTN);
            form.Controls.Add(cancelBTN);
            form.ShowDialog();
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editBTN_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode selectedNode = treeView1.SelectedNode;

                if (selectedNode.Parent != null)
                {
                    string title = treeView1.SelectedNode.Text;
                    int noteID = database.GetNoteIdByTitleAndUserID(title, userID_);

                    EditForm editForm = new EditForm(noteID, title);
                    editForm.ShowDialog();
                    RefreshTreeView();
                }
                else if (selectedNode.Parent == null)
                {
                    Form form = new Form();
                    CreateMyForm(form, 300, 100);

                    TextBox textBox = new TextBox();
                    CreateMyTextBox(textBox);

                    Button okBTN = new Button();    
                    CreateMyOKBTN(okBTN, 10, 40);
                    okBTN.Click += (s, args) =>
                    {
                        if (textBox.Text != "" && textBox.Text != treeView1.SelectedNode.Text)
                        {
                            int categotyID = database.GetCategoryIdByCategoryNameAndUserID(treeView1.SelectedNode.Text, userID_);
                            string newCategoryName = textBox.Text;
                            database.UpdateCategoryName(categotyID, newCategoryName);
                            RefreshTreeView();
                            form.Close();
                        }
                        else
                        {
                            MessageForm("Enter new category name!", 300, 100);
                        }

                    };

                    Button cancelBTN = new Button();
                    CreateMyCancelBTN(cancelBTN, 110, 40);
                    cancelBTN.Click += (s, args) => form.Close();

                    form.Controls.Add(textBox);
                    form.Controls.Add(okBTN);
                    form.Controls.Add(cancelBTN);
                    form.ShowDialog();
                }
            }
            else {
                MessageForm("Choose note / category", 300, 100);
            }
        }

        private void addNoteBTN_Click(object sender, EventArgs e)
        {
            NewNoteForm newNoteForm = new NewNoteForm(userID_);
            newNoteForm.ShowDialog();
            RefreshTreeView();
        }

        private void addCategoryBTN_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            CreateMyForm(form, 300, 100);

            TextBox textBox = new TextBox();
            CreateMyTextBox(textBox);

            Button okBTN = new Button();    
            CreateMyOKBTN(okBTN, 10, 40);
            okBTN.Click += (s, args) =>
            {
                bool check = database.DoesACategoryWithThisNameExistForThisUserID(userID_, textBox.Text);
                if (textBox.Text != "" && check == false)
                {
                    string categoryName = textBox.Text;
                    database.AddCategory(userID_, categoryName);
                    RefreshTreeView();
                    form.Close();
                }
                else if (check == true)
                {
                    MessageForm("Category is already exist!", 300, 100);
                }

                else
                {
                    MessageForm("Enter category name!", 300, 100);
                }
            };

            Button cancelBTN = new Button();
            CreateMyCancelBTN(cancelBTN, 110, 40);
            cancelBTN.Click += (s, args) => form.Close();

            form.Controls.Add(textBox);
            form.Controls.Add(okBTN);
            form.Controls.Add(cancelBTN);
            form.ShowDialog();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode selectedNode = treeView1.SelectedNode;
                if (selectedNode.Parent != null)
                {
                    string name = selectedNode.Text;
                    database.DeleteNoteByTitleAndUserID(name, userID_);
                }
                else if (selectedNode.Parent == null) {

                    Form form = new Form();
                    CreateMyForm(form, 300, 200);

                    Button okBTN = new Button();
                    CreateMyOKBTN(okBTN, 10, 140);
                    okBTN.Click += (s, args) =>
                    {
                        string name = treeView1.SelectedNode.Text;
                        database.DeleteCategoryByCategoryNameAndUserID(name, userID_);

                        RefreshTreeView();
                        form.Close();
                    };

                    Button cancelBTN = new Button();
                    CreateMyCancelBTN(cancelBTN, 100, 140);
                    cancelBTN.Click += (s, args) => form.Close();


                    Label label = new Label();
                    CreateMyLabel(label, "If you delete this category, all notes \n" +
                                               "within it will also be deleted.\n" +
                                                                      "Do you want to continue?\n", 7);

                    form.Controls.Add(label);
                    form.Controls.Add(okBTN);
                    form.Controls.Add(cancelBTN);
                    form.ShowDialog();
                }
                
                RefreshTreeView();
            }
            else
            {
                MessageForm("Choose note / category", 300, 100);
            }
        }

        #endregion

        #region Refresh TreeView

        public void RefreshTreeView()
        {
            treeView1.Nodes.Clear();
            List<string> categoryNames = database.GetAllCategoriesByUserID(userID_);
            foreach (string categoryName in categoryNames)
            {
                TreeNode categoryNode = new TreeNode(categoryName);
                int categoryID = database.GetCategoryIdByCategoryNameAndUserID(categoryName, userID_);
                List<string> notes = database.GetNotesByCategoryID(categoryID);
                foreach (string note in notes)
                {
                    TreeNode noteNode = new TreeNode(note);
                    categoryNode.Nodes.Add(noteNode);
                }
                treeView1.Nodes.Add(categoryNode);
            }
        }

        #endregion

        #region Form Design

        private Form CreateMyForm(Form form, int height, int width) {
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(height, width);
            form.BackColor = Color.Black;
            return form;
        }

        private Label CreateMyLabel(Label label, string textLabel, int textSize) {
            label.AutoSize = true;
            label.Location = new Point(5, 5);
            label.BorderStyle = BorderStyle.None;
            label.Font = new Font("OCR A Extended", textSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Text = textLabel;
            label.ForeColor = Color.Lime;
            return label;
        }

        private TextBox CreateMyTextBox(TextBox textBox) {
            textBox.Size = new Size(250, 20);
            textBox.Location = new Point(5, 5);
            textBox.BackColor = Color.Black;
            textBox.ForeColor = Color.Lime;
            textBox.Font = new Font("OCR A Extended", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox.BorderStyle = BorderStyle.None;
            return textBox;
        }

        private Button CreateMyCancelBTN(Button cancelBTN, int height, int width) {
            cancelBTN.Size = new Size(100, 50);
            cancelBTN.Font = new Font("OCR A Extended", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBTN.ForeColor = Color.Lime;
            cancelBTN.Text = "Cancel";
            cancelBTN.FlatAppearance.BorderSize = 0;
            cancelBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            cancelBTN.FlatStyle = FlatStyle.Flat;
            cancelBTN.Location = new Point(height, width);
            return cancelBTN;
        }

        private Button CreateMyOKBTN(Button okBTN, int height, int width)
        {
            okBTN.Size = new Size(100, 50);
            okBTN.Font = new Font("OCR A Extended", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            okBTN.ForeColor = Color.Lime;
            okBTN.Text = "OK";
            okBTN.FlatAppearance.BorderSize = 0;
            okBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Location = new Point(height, width);
            return okBTN;
        }

        private void MessageForm(string message, int height, int width) {
            Form messageForm = new Form();
            messageForm.FormBorderStyle = FormBorderStyle.None;
            messageForm.StartPosition = FormStartPosition.CenterScreen;
            messageForm.Size = new Size(height, width);
            messageForm.BackColor = Color.Black;

            Label messageFormLabel = new Label();
            messageFormLabel.AutoSize = true;
            messageFormLabel.Location = new Point(5, 5);
            messageFormLabel.BorderStyle = BorderStyle.None;
            messageFormLabel.Font = new Font("OCR A Extended", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageFormLabel.Text = message;
            messageFormLabel.ForeColor = Color.Lime;

            Button okBTN = new Button();
            okBTN.Size = new Size(100, 50);
            okBTN.Font = new Font("OCR A Extended", 12, FontStyle.Regular, GraphicsUnit.Point, 0);
            okBTN.ForeColor = Color.Lime;
            okBTN.Text = "OK";
            okBTN.FlatAppearance.BorderSize = 0;
            okBTN.FlatAppearance.MouseDownBackColor = Color.Lime;
            okBTN.FlatStyle = FlatStyle.Flat;
            okBTN.Location = new Point(10, 40);
            okBTN.Click += (s, args) => messageForm.Close();

            messageForm.Controls.Add(messageFormLabel);
            messageForm.Controls.Add(okBTN);

            messageForm.ShowDialog();
        }
        #endregion

        #region Form Move

        Point lastPoint;

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        #endregion
    }
}
