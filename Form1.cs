using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace hotline_messenger
{
    public partial class Form1 : Form
    {
        Button[] cButtons;
        List<string> contacts;
        public Dictionary<string, string> chats;
        public string activeChat = "";
        Com c;
        public bool isAlive;

        public Form1(Com c)
        {
            InitializeComponent();

            this.c = c;
            this.c.SetForm(this);
            this.contacts = Configuration.GetContacts();
            this.chats = new Dictionary<string, string>();
            cButtons = new []{ c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12 };

            if (this.contacts.Count > 12)
            {
                SendMessage("This application doesn't support more than 12 contacts, please check your config!","!!!");
            } else
            {
                DisplayContacts();
                
            }

            foreach(var cont in contacts)
            {
                chats[cont.Split(';')[0]] = "";
            }

            var scheck = new StatusChecker(contacts, this);

            Thread t = new Thread(c.Run);
            Thread statusChecker = new Thread(scheck.Run);
            t.Start();
            statusChecker.Start();
            
        }

        internal void AccepMessageFromCom(string msg)
        {
            var contact = GetHostnameFromMessage(msg);
            if(contact != null)
            {
                msg = msg.Replace(contact + "|@|", "");
                contact = Configuration.GetContactByHostname(contact);
            }

            chats[contact] += msg+"\r\n";

            if (activeChat == contact){
                chatBox.Text = chats[activeChat];
            }
            

            chatBox.SelectionStart = chatBox.Text.Length;
            chatBox.ScrollToCaret();
        }

        private string GetHostnameFromMessage(string msg)
        {
            if (msg.Contains("|@|"))
            {
                return msg.Split('|')[0];
            }
            else
            {
                return null;
            }
        }

        private void ChatMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChatSend_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        private void ChatSend_Click(object sender, EventArgs e)
        {

            SendMessage(chatMessage.Text);
            
        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            var addContactForm = new Form2(this);
            addContactForm.Show();
        }
        

        public void SendMessage(string text, string splitSign = ">>>")
        {
            if (text != "" && activeChat != "")
            {
                var message = "";
                var fullMessage = "";
                var cname = Environment.GetEnvironmentVariable("COMPUTERNAME");
                var time = DateTime.Now;
                if (!text.Contains("<<<"))
                {
                    fullMessage = cname +"|@|"+time.ToShortTimeString() + " " + splitSign + " " + text + "\r\n";
                    message = time.ToShortTimeString() + " " + splitSign + " " + text + "\r\n";
                } else
                {
                    message = text + "\r\n";
                }
                
                chats[activeChat] += message;
                chatMessage.Text = "";
                chatBox.Text = chats[activeChat];

                var client = new TcpClient();
                var host = GetHostnameFromUser(activeChat);
                try
                {
                    client.Connect(host, 8888);
                    client.SendTimeout = 3;
                    client.ReceiveTimeout = 3;
                    StreamWriter w = new StreamWriter(client.GetStream());
                    w.WriteLine(fullMessage);
                    w.Flush();
                }
                catch (Exception e)  {
                    Debug.WriteLine(e.StackTrace);
                }
                
            }
        }

        private string GetHostnameFromUser(string name)
        {
            foreach(var i in contacts)
            {
                if (i.StartsWith(name))
                {
                    return i.Split(';')[1];
                }
            }
            return null;
        }

        private void DisplayContacts()
        {
            string cName;
            for(var i = 0; i < contacts.Count; i++)
            {
                cName = contacts[i].Split(';')[0];
                cButtons[i].Text = cName;
                cButtons[i].Visible = true;
            }
            
        }

        internal void AddChat(string name)
        {
            chats.Add(name, "");
        }

        internal void ActivateChat(string name)
        {
            if (chats.ContainsKey(name) == false)
            {
                AddChat(name);
            }

            this.activeChat = name;
            this.chatBox.Text = chats[name];
        }

        private void C1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C9_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C10_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C11_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void C12_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void ActivateButton(object sender)
        {
            var btn = (Button)sender;
            ActivateChat(btn.Text);
            foreach (var b in cButtons)
            {

                b.UseVisualStyleBackColor = true;
            }
            btn.BackColor = System.Drawing.Color.Green;
            
            SetFocusToMessagebox();
        }

        public void SetFocusToMessagebox()
        {
            this.chatMessage.Focus();
        }
        
        public void UpdateContacts()
        {
            this.contacts = Configuration.GetContacts();
            DisplayContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.isAlive = true;
        }

    }
}
