using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MonitoringTool
{
    public class Department
    {
        /// <summary>  
        ///  This class store functions for check accessibility of IP adress.  
        /// </summary>  

        public Department()
        {
            name = "";
            ip = "";
            available = false;
        }

        public Department(string name, string ip)
        {
            this.name = name;
            this.ip = ip;
        }

        public Department(string name, string ip, bool available)
        {
            name = this.name;
            ip = this.ip;
            available = this.available;
        }

        public string name;
        public string ip;
        public bool available;

        public int pingIt()
        {
            //check accessibility of IP adress return 1 (available) or 0 (unavailable)
            bool input = pingHost(ip);
            int final = 0;
            if (input)
            {
                final = 1;
            }
            else
            {
                final = 0;
            }
            return final;
        }

        public static bool pingHost(string nameOrAddress)
        {
            //start ping server
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }

    }
}
