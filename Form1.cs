using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hotline_messenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            if (chatMessage.Text != "")
            {
                var time = System.DateTime.Now;
                this.chatBox.Text += time.ToShortTimeString() + " >>> " + this.chatMessage.Text + "\r\n";
                chatMessage.Text = "";
            }
            
        }

        private void addContact_Click(object sender, EventArgs e)
        {
            var addContactForm = new Form2();
            addContactForm.Show();
        }
    }
}
