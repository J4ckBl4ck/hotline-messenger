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
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 c)
        {
            InitializeComponent();
            this.caller = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                Configuration.AddContact(textBox1.Text + ";" + textBox2.Text);
            } else
            {
                this.caller.displayChatMessage("Unable to add contact, please fill in contact name and client name!", "!");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
