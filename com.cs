using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace hotline_messenger
{
    public class Com
    {
        Form1 form;

        public Com()
        {
            
        }

        public void Run()
        {
            TcpListener chatServer = new TcpListener(8888);
            while(!form.isAlive)
            {
                Thread.Sleep(200);
            }
            chatServer.Start();

            while (!form.IsDisposed)
            {
                if (chatServer.Pending())
                {
                    var client = chatServer.AcceptTcpClient();
                    GetMessage(client);
                }
            }
        }

        public void GetMessage(TcpClient cl)
        {
            try
            {
                var r = new StreamReader(cl.GetStream());
                var line = r.ReadLine();
                SendMessage(line);
            } catch (Exception e) {
                Debug.WriteLine(e.StackTrace);
                
            }
            
        }


        public void SendMessage(string msg)
        {
            if (msg.Trim() == "")
            {
                return;
            }

            form.Invoke((Action)delegate { form.AccepMessageFromCom(msg); });

            //form.AccepMessageFromCom(msg);
        }

        public void SetForm(Form1 f)
        {
            this.form = f;
        }
        
    }
}
