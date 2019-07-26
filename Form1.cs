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
        Configuration conf;
        List<string> contacts;
        public Dictionary<string, string> chats;
        public string activeChat = "";
        Com c;
        public bool isAlive;
        internal StatusChecker sc;
        private DateTime lastActive;
        internal Dictionary<string, DateTime> lastStatusReport;

        public Form1(Com c)
        {
            InitializeComponent();

            conf = new Configuration();
            this.c = c;
            this.c.SetForm(this);
            this.contacts = conf.GetContacts();
            this.chats = new Dictionary<string, string>();
            cButtons = new []{ c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12 };
            this.lastActive = DateTime.Now;
            this.lastStatusReport = new Dictionary<string, DateTime>();

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

            this.sc = new StatusChecker(contacts, this);

            Thread t = new Thread(c.Run);
            Thread statusChecker = new Thread(sc.Run);
            t.Start();
            statusChecker.Start();
            
        }

        internal void AccepMessageFromCom(string msg)
        {
            var contact = GetHostnameFromMessage(msg);
            if(contact != null)
            {
                msg = msg.Replace(contact + "|@|", "");
                msg = msg.Replace(">>>", "<<<");
                contact = Configuration.GetContactByHostname(contact);
            }

            chats[contact] += msg+"\r\n";

            if (!this.Focused)
            {
                FlashWindow.Start(this);
            }

            if (activeChat == contact){
                chatBox.Text = chats[activeChat];
            } else
            {
                MarkChatToHaveNewMessage(contact);
            }
            

            chatBox.SelectionStart = chatBox.Text.Length;
            chatBox.ScrollToCaret();
        }

        private void MarkChatToHaveNewMessage(string contact)
        {
            foreach(var b in cButtons)
            {
                if(b.Text == contact)
                {
                    b.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
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

        internal void ProcessResultFromStatusCheck(string result)
        {

            var time = DateTime.Now;
            var user = result.Split('|')[0];
            var status = result.Split('|')[1];

            if (lastStatusReport.ContainsKey(user))
            {
                lastStatusReport[user] = time;
            } else
            {
                lastStatusReport.Add(user, time);
            }

            Button b = getButtonForUser(user);

            if (status == "online")
            {
                var res = Properties.Resources.Online;
                b.BackgroundImage = res;
            } else
            {
                var res = Properties.Resources.Away;
                b.BackgroundImage = res;
            }
        }

        private Button getButtonForUser(string user)
        {
            foreach(var b in cButtons)
            {
                if(b.Text == user)
                {
                    return b;
                }
            }
            return null;
        }

        internal string GetLastSendTimeDiff()
        {
            return (DateTime.Now - lastActive).TotalSeconds.ToString(); ;
        }

        private void ChatSend_Click(object sender, EventArgs e)
        {

            SendMessage(chatMessage.Text);
            
        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            var addContactForm = new Form2(this, conf);
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
                lastActive = time;
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
                    client.SendTimeout = 3;
                    client.ReceiveTimeout = 3;
                    client.Connect(host, 8888);
                    StreamWriter w = new StreamWriter(client.GetStream());
                    w.WriteLine(fullMessage);
                    w.Flush();
                }
                catch (Exception e)  {
                    Debug.WriteLine(e.Message);
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
            
            foreach (var b in cButtons)
            {
                if(b.Text == activeChat)
                {
                    b.Height = 23;
                    b.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                
            }
            btn.Height = 30;
            btn.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            ActivateChat(btn.Text);

            SetFocusToMessagebox();
        }

        public void SetFocusToMessagebox()
        {
            this.chatMessage.Focus();
        }
        
        public void UpdateContacts()
        {
            this.contacts = conf.GetContacts();
            DisplayContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.isAlive = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            foreach(var b in cButtons)
            {
                var username = b.Text;
                if (lastStatusReport.ContainsKey(username))
                {
                    DateTime lastReport;
                    lastStatusReport.TryGetValue(username, out lastReport);
                    if ((d - lastReport).TotalSeconds > 15)
                    {
                        b.BackgroundImage = Properties.Resources.Offline;
                    }
                } else
                {
                    b.BackgroundImage = Properties.Resources.Offline;
                }
            }
        }
    }
}
