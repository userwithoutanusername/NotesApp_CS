using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotesLibary;

namespace NotesApplication
{
    public partial class RegistrationForm : Form
    {

        DataBase database;

        public RegistrationForm()
        {
            InitializeComponent();
            database = new DataBase();
        }

        #region Buttons

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegBTN_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text == "" || passwordTB.Text == "")
            {
                regLableStatus.Text = "Please fill in all fields";
            }
            else
            {
                string username = usernameTB.Text;
                string password = passwordTB.Text;

                if (!database.IsUsernameExists(username))
                {
                    database.AddUser(username, password);

                    MessageForm("Registration successful", 300, 100);
                }
                else
                {
                    regLableStatus.Text = "Username already exists";
                }
            }
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorisationForm authForm = new AuthorisationForm();
            authForm.Show();

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

            this.Hide();
            messageForm.ShowDialog();
            AuthorisationForm authForm = new AuthorisationForm();
            authForm.Show();
        }

        #endregion

        #region Form Movement

        Point lastPoint;
        private void RegistrationForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void RegistrationForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        #endregion

        #region TextBoxes Enter/Leave

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTB.Text))
            {
                passwordTB.PasswordChar = '\0';
            }
            else
            {
                passwordTB.PasswordChar = '*';
            }
        }

        private void passwordTB_Enter(object sender, EventArgs e)
        {
            if (passwordTB.Text == "Password")
            {
                passwordTB.Text = "";
            }
        }

        private void passwordTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passwordTB.Text))
            {

                passwordTB.Text = "Password";
                passwordTB.PasswordChar = '\0';
            }
        }

        private void usernameTB_Enter(object sender, EventArgs e)
        {
            if (usernameTB.Text == "Username")
            {
                usernameTB.Text = "";
            }
        }

        private void usernameTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTB.Text))
            {
                usernameTB.Text = "Username";
            }
        }

        #endregion
    }
}
