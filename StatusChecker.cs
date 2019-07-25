using System;
using System.Collections.Generic;
using System.Threading;

namespace hotline_messenger
{
    internal class StatusChecker
    {
        internal string[] hostnames;
        internal List<Thread> checks;
        internal Form1 form;

        public StatusChecker(List<string> contacts, Form1 f)
        {
            checks = new List<Thread>();
            hostnames = EvaluateContacts(contacts);
            form = f;
            
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

        private void StartAllThreads()
        {
            foreach(var hn in hostnames)
            {
                var c = new Checker(hn, form);
                var t = new Thread(c.StartChecking);
                checks.Add(t);
                t.Start();
            }
        }

        private void KillAllRunningThreads()
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

        internal void StartChecking()
        {

        }
    }

    internal class Checker
    {
        readonly string hostname;
        readonly Form1 form;

        internal Checker(string hostname, Form1 form)
        {
            this.hostname = hostname;
            this.form = form;
        }
        internal void StartChecking()
        {

        }
    }
}