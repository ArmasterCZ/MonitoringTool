using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringTool
{
    class ADuser
    {
        /// <summary>  
        ///  class for passing stored user attributes
        /// </summary>  

        //public string nameGiven; //first name
        //public string nameSurn; //second name
        public string nameFull; //surname + first name
        public string nameAcco; //user name

        public string lockFrom; //for lock list
        public string lockTime; //for lock list
        public string lockDate; //for lock list
        public string eventID;  //for lock list

        public string passwordDateLastSet; //for password expire list
        public int PasswordDayFromChange;  //for password expire list

        public ADuser()
        {
            this.nameAcco = "";
            this.nameFull = "";
        }
        public ADuser(string nameAcco, string nameFull)
        {
            this.nameAcco = nameAcco;
            this.nameFull = nameFull;
        }
    }
}
