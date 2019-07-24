using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace hotline_messenger
{

    class Configuration
    {
        public string Hostname;


        public Configuration()
        {
            this.Hostname = Environment.GetEnvironmentVariable("CLIENTNAME");
            if (this.Hostname == "")
            {
                this.Hostname = Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
        }
    }
}
