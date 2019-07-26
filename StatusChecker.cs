using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace hotline_messenger
{
    internal class StatusChecker
    {
        internal string[] hostnames;
        internal List<Thread> checks;
        internal Form1 form;
        internal ResultReceiver listen;

        public StatusChecker(List<string> contacts, Form1 f)
        {
            checks = new List<Thread>();
            hostnames = EvaluateContacts(contacts);
            form = f;

            listen = new ResultReceiver(f, Environment.GetEnvironmentVariable("COMPUTERNAME"));

            Thread listener = new Thread(listen.AwaitResult);
            listener.Start();
            
        }

        private string[] EvaluateContacts(List<string> contacts)
        {
            string[] contactsToCheck = new string[contacts.Count];
            var i = 0;
            foreach(var c in contacts)
            {
                var hostname = c.Split(';')[1];
                contactsToCheck[i] = hostname;
                i++;
            }
            return contactsToCheck;
        }

        internal void ShutDown()
        {
            KillAllRunningThreads();
            listen.Close();
        }

        private void StartAllThreads()
        {
            foreach(var hn in hostnames)
            {
                var c = new Checker(hn);
                var t = new Thread(c.StartChecking);
                checks.Add(t);
                t.Start();
            }
        }

        internal void KillAllRunningThreads()
        {
            foreach(var t in checks)
            {
                t.Abort();
            }
        }

        internal void Run()
        {
            StartAllThreads();
        }

        internal void UpdateChecks(List<string> contacts)
        {
            EvaluateContacts(contacts);

            KillAllRunningThreads();
            StartAllThreads();
        }
    }

    internal class ResultReceiver
    {
        internal Form1 form;
        internal string hostname;
        TcpListener listen;
        bool shouldRun = true;

        internal ResultReceiver(Form1 form, string hostname)
        {
            this.form = form;
            this.hostname = hostname;
        }

        internal void Close()
        {
            this.shouldRun = false;
            listen.Stop();
        }

        internal void AwaitResult()
        {
            listen = new TcpListener(8889);
            
            listen.Start();

            while (this.shouldRun)
            {

                if (!listen.Pending())
                {
                    Thread.Sleep(50);
                    continue;
                }
                try
                {
                    TcpClient cl = listen.AcceptTcpClient();
                    StreamReader r = new StreamReader(cl.GetStream());

                    var msg = "";
                    while(r != null){
                        var l = r.ReadLine();
                        if(l != null)
                        {
                            msg += l;
                        } else
                        {
                            r.Close();
                            r = null;
                        }
                        
                    }
                    
                    ProcessClientCommand(msg);
                } catch (SocketException e)
                {
                    if(e.SocketErrorCode == SocketError.Interrupted)
                    {

                    } else
                    {
                        Debug.WriteLine(e.StackTrace);
                    }
                } catch (Exception e)
                {
                    continue;
                }
                
            }
        }

        private void ProcessClientCommand(string msg)
        {
            if (msg == "")
            {
                return;
            }
            
            

            if(msg.StartsWith("@STATUS"))
            {
                try
                {
                    var status = form.GetLastSendTimeDiff();
                    status = status.Split('.')[0];
                    int s;
                    int.TryParse(status, out s);

                    if(s < 300)
                    {
                        status = "online";
                    } else
                    {
                        status = "away";
                    }
                    var response = hostname + "|" + status;
                    var targetHost = msg.Split('|')[1];

                    TcpClient answeringClient = new TcpClient();
                    answeringClient.Connect(targetHost, 8889);
                    var answerStream = new StreamWriter(answeringClient.GetStream());
                    answerStream.WriteLine(response);
                    answerStream.Flush();
                    answerStream.Close();
                    answeringClient.Close();
                } catch (Exception e)
                {

                }
                

            } else //message seems to be a status report
            {
                var username = Configuration.GetContactByHostname(msg.Split('|')[0]);
                var result = username + "|" + msg.Split('|')[1];
                form.Invoke((Action)delegate { form.ProcessResultFromStatusCheck(result); });
            }
            
        }
    }

    internal class Checker
    {
        readonly string targetHostname;
        readonly string myHostname;

        internal Checker(string hostname)
        {
            this.targetHostname = hostname;
            this.myHostname = Environment.GetEnvironmentVariable("COMPUTERNAME");
        }
        internal void StartChecking()
        {
            TcpClient client = new TcpClient();
            var statusCheck = "@STATUS|"+myHostname;

            while (myHostname != targetHostname)
            {
                try
                {

                    if (client.Connected)
                    {
                        client.Close();
                        client = new TcpClient();
                    }
                    
                    client.Connect(targetHostname, 8889);

                    StreamWriter w = new StreamWriter(client.GetStream());
                    w.WriteLine(statusCheck);
                    w.Flush();
                    
                }
                catch (Exception e)
                {
                    
                    if(e.Message.Contains("No connection could be made because the target machine actively refused it"))
                    {
                        Debug.WriteLine(String.Format("Refused from {0}", targetHostname));
                    } else if (e.Message.Contains("No such host is known"))
                    {
                        e = null;
                        //Debug.WriteLine(String.Format("Unknown host: {0}", targetHostname));
                    } else if (e.Message.Contains("A connect request was made on an already connected socket"))
                    {
                        Debug.WriteLine(String.Format("Already requested host: {0}", targetHostname));
                    }
                    else 
                    {
                        Debug.WriteLine(e.Message);
                    }
                    

                    //Debug.WriteLine("Exception in Checker.StartChecking()");

                }
                Thread.Sleep(5000);

            }
            
        }
    }
}

