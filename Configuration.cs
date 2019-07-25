using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;

namespace hotline_messenger
{

    class Configuration
    {
        
        const string CONFIG_PATH = ".\\hotline-messenger.cfg";


        public Configuration()
        {
        }

        public static void AddContact(string contact)
        {
            try
            {
                var file = File.AppendText(CONFIG_PATH);
                file.WriteLine(contact);
                file.Flush();
                file.Close();


            } catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public static List<string> GetContacts()
        {
            var contacts = new List<string>();
            try
            {
                var file = new StreamReader(CONFIG_PATH);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    contacts.Add(line);
                }
                file.Close();
                file.Dispose();

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.GetType());
                if (e.GetType().ToString() == "System.IO.FileNotFoundException")
                {
                    File.Create(CONFIG_PATH);
                }
            }
            return contacts;
        }

        internal static string GetContactByHostname(string name)
        {
            string contactName = "";
            try
            {
                var file = new StreamReader(CONFIG_PATH);
                string line;
                
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(name))
                    {
                        contactName = line.Split(';')[0];
                        break;
                    }
                }
                file.Close();
                file.Dispose();

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.GetType());
                if (e.GetType().ToString() == "System.IO.FileNotFoundException")
                {
                    File.Create(CONFIG_PATH);
                }
            }
            return contactName;
        }
    }
}
