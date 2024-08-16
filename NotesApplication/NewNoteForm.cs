using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotesLibary;

namespace NotesApplication
{
    public partial class NewNoteForm : Form
    {

        DataBase database;
        int userID_;

        public NewNoteForm(int userID)
        {
            database = new DataBase();
            InitializeComponent();
            this.userID_ = userID;
            List<string> categoryNames = database.GetAllCategoriesByUserID(userID);
            foreach (string categoryName in categoryNames)
            {
                comboBox1.Items.Add(categoryName);
            }
        }

        #region Buttons

        private void okBTN_Click(object sender, EventArgs e)
        {
            bool check = database.DoesANoteWithThisNameExistForThisUserID(userID_, titleTB.Text);

            if (comboBox1.Items.Count == 0)
            {
                MessageForm("Please create a category first", 300, 100);
            }
            else if (check == true)
            {
                MessageForm("Note with this name already exists", 300, 100);
            }
            else if (comboBox1.SelectedItem == null)
            {
                MessageForm("Please select a category", 300, 100);
            }
            else
            {
                string categoryName = comboBox1.Text;
                int categoryId = database.GetCategoryIdByCategoryNameAndUserID(categoryName, userID_);
                database.AddNoteToCategory(userID_, categoryId, titleTB.Text, contentTB.Text);
                this.Hide();
            }

        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region Message Form

        private void MessageForm(string message, int height, int width)
        {
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

        #region TextBoxes Enter/Leave

        private void titleTB_Enter(object sender, EventArgs e)
        {
            if (titleTB.Text == "Title")
            {
                titleTB.Text = "";
            }
        }

        private void titleTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTB.Text))
            {
                titleTB.Text = "Title";
            }
        }

        private void contentTB_Enter(object sender, EventArgs e)
        {
            if (contentTB.Text == "Text")
            {
                contentTB.Text = "";
            }
        }

        private void contentTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contentTB.Text))
            {
                contentTB.Text = "Text";
            }
        }

        #endregion
    }
}
