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
    public partial class Form2 : Form
    {
        Form1 caller;
        Configuration conf;
        public Form2()
        {
            InitializeComponent();
        }
        internal Form2(Form1 c, Configuration configuration)
        {
            InitializeComponent();
            this.caller = c;
            this.conf = configuration;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                conf.AddContact(textBox1.Text + ";" + textBox2.Text);
            } else
            {
                this.caller.SendMessage("Unable to add contact, please fill in contact name and client name!", "!");
            }
            this.caller.UpdateContacts();
            this.caller.SetFocusToMessagebox();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
