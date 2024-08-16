using NotesLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesApplication
{
    public partial class EditForm : Form
    {

        DataBase database;
        int noteID_;
        string title_;
        string content;

        public EditForm(int noteID, string title)
        {
            InitializeComponent();
            database = new DataBase();
            titleTB.Text = title;
            contentTB.Text = database.GetNoteContentByNoteID(noteID);
            string content_ = database.GetNoteContentByNoteID(noteID);
            this.noteID_ = noteID;
            this.title_ = title;
            this.content = content_;

        }

        #region Buttons

        private void okBTN_Click(object sender, EventArgs e)
        {
            if (titleTB.Text != title_)
            {
                string newTitle = titleTB.Text;
                database.UpdateNoteTitle(noteID_, newTitle);
            }
            else if (contentTB.Text != content)
            {
                string newContent = contentTB.Text;
                database.UpdateNoteContent(noteID_, newContent);
            }
            else if (titleTB.Text != title_ && contentTB.Text != content)
            {
                string newTitle = titleTB.Text;
                database.UpdateNoteTitle(noteID_, newTitle);
                string newContent = contentTB.Text;
                database.UpdateNoteContent(noteID_, newContent);
            }
            else
            {
                this.Hide();
            }
            this.Hide();
        }

        #endregion

        #region TextBoexes Enter/Leave

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
