using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitoringTool
{
    public interface ISend
    {
        int Register();
        string SendMessage(int id, string message);
        string getMessages();
    }
}