using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hotline_messenger
{
    public partial class BroadcastForm : Form
    {

        readonly CheckBox[] boxes;
        readonly Dictionary<string, string> contacts;
        Form1 f;
        
        public BroadcastForm(Form1 f)
        {
            InitializeComponent();

            this.f = f;
            var conf = new Configuration();
            this.contacts = new Dictionary<string, string>();
            BuildContactsDictionary(conf.GetContacts());

            this.boxes = new[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };

            int i = 0;
            foreach(var c in contacts)
            {
                boxes[i].Text = c.Key.Split(';')[0];
                boxes[i].Checked = true;
                boxes[i].Visible = true;
                i++;
            }
        }

        private void BuildContactsDictionary(List<string> list)
        {
            foreach (var item in list)
            {
                contacts.Add(item.Split(';')[0], item.Split(';')[1]);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            List<string> clientsToSendMessageTo = new List<string>();
            List<string> usernames = new List<string>();

            foreach(var b in boxes)
            {
                foreach(var c in contacts)
                {
                    if (c.Key == b.Text)
                    {
                        if(b.Checked == true)
                        {
                            clientsToSendMessageTo.Add(c.Value);
                            usernames.Add(c.Key);
                        }
                    }
                }
            }

            f.BroedcastMessage(clientsToSendMessageTo, textBox1.Text);
            broadcastLog.Text += BuildBroadcastInfo(usernames, textBox1.Text);
            textBox1.Text = "";

        }

        private string BuildBroadcastInfo(List<string> users, string text)
        {
            var info = DateTime.Now + ": Sent a message to ";

            for (int i = 0; i < users.Count; i++)
            {
                if(i > 0)
                {
                    info += ", "; 
                }
                info += users[i];
            }



            info += ".\r\n The message was: " + text + "\r\n\r\n";

            return info;
        }
    }
}
