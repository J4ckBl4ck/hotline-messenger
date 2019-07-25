using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hotline_messenger
{
    public partial class Form1 : Form
    {
        List<string> contacts;

        public Form1()
        {
            InitializeComponent();
            this.contacts = Configuration.GetContacts();
            displayContacts();
        }

        private void chatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chatSend_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        private void chatSend_Click(object sender, EventArgs e)
        {
            displayChatMessage(chatMessage.Text);
            
        }

        private void addContact_Click(object sender, EventArgs e)
        {
            var addContactForm = new Form2(this);
            addContactForm.Show();
        }
        

        public void displayChatMessage(string text, string splitSign = ">>>")
        {
            if (text != "")
            {
                var time = DateTime.Now;
                this.chatBox.Text += time.ToShortTimeString() + " " + splitSign + " " + text + "\r\n";
                chatMessage.Text = "";
            }
        }

        private void displayContacts()
        {
            Button[] cButtons = { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12 };
            string cName;
            for(var i = 0; i < contacts.Count; i++)
            {
                cName = contacts[i].Split(';')[0];
                cButtons[i].Text = cName;
                cButtons[i].Visible = true;
            }
            
        }

        
    }
}
