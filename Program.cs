using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotline_messenger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 



        [STAThread]


        
        static void Main()
        {

            //Thread t = new Thread(new com().StartListening);
            //t.Start();
            var c = new Com();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new Form1(c);
            Application.Run(f);

            f.Close();
            f.Dispose();

            
        }

        internal static void UpdateChatbox(Form1 f, string v)
        {
            f.chatBox.Text = v;
        }
    }
}
