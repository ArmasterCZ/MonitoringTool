using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using ExtensionMethods;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Timers;
using System.IO;
using System.Xml.Serialization;

//location of povershell library C:\Program Files (x86)\Reference Assemblies\Microsoft\WindowsPowerShell\3.0

/*  ToDo:
    add threads for ...
    //add constructor in IceWarpClass for input userName, password and serverIp
    add feature: if script fail show red light for script (no mbox)
    hide secondCheck (?)
*/

/*  version changes
    ...
    1.2 - 2017.10.31 - added ContextMenuStrip for listView1
    1.3 - 2017.11.3  - added more ContextMenuStrip, remove treeNode in treeView3 lockedOutEmails
    1.4 - 2017.11.24 - move icewarp login to config file
    1.5 - 2018.02.27 - move Departments to XML files (de-serialize), custom timer interval
 */

namespace MonitoringTool
{
    public partial class Form1 : Form
    {
        public string verze = "1.5";
        public DateTime secondCheck = DateTime.Now.AddDays(-1);
        public Form1()
        {
            InitializeComponent();
            this.Text = "Monitoring Tool - V" + verze;
        }

        public void log(string sLog)
        {
            //zapíše aktuálně prováděnou operaci do label
            lLog.Text = sLog;
            this.Refresh();
        }

        private void b_RefCheckEmailsToSend_Click(object sender, EventArgs e)
        {
            //vypíše počet emailů k odeslání (na pošťákovy)
            checkEmailsToSend();
        }

        private void b_RefLockedOutOldList_Click(object sender, EventArgs e)
        {
            //projde eventy na kontroleru a zjistí které účty byly odkud uzamknuty

            //ListViewItem user1 = new ListViewItem("1");
            //user1.SubItems.Add("17:11");
            //user1.SubItems.Add("mojeJmeno");
            //user1.SubItems.Add("mujPC");
            //lv_LockedOutOldList.Items.Add(user1);

            lockedOutOldList();
        }

        private void b_RefLockedOutAccount_Click(object sender, EventArgs e)
        {
            //zobrazí aktuální seznam zaklých účtů
            lockedOutAccount();
        }

        private void b_RefLockedOutEmails_Click(object sender, EventArgs e)
        {
            //zobrazí seznam zamklých poštovních účtů z Icewarpu
            lockedOutEmails();
        }

        private void b_RefExpiredPasswords_Click(object sender, EventArgs e)
        {
            //zobrazí seznam účtů s vypršelým heslem (+účty blízko vypršení)
            expiredPasswords();
        }

        private void b_RefDepartmentCheck_Click(object sender, EventArgs e)
        {
            //load departments (from files)
            List<Department> departmentList = deserialize();

            departmentCheck(departmentList);
        }

        private void b_Timer_Click(object sender, EventArgs e)
        {
            //start timer
            if (timer1.Enabled)
            {
                //zastavý timer
                bTimer.Text = "Start";
                bTimer.BackColor = SystemColors.Control;
                timer1.Stop();
            }
            else
            {
                //nastartuje timer
                setTimer1Interval();
                bTimer.Text = "Stop";
                bTimer.BackColor = SystemColors.ControlLight;
                timer1_Tick(sender, e);
                timer1.Start();
            }
        }

        private void lv_LockedOutOldList_MouseClick(object sender, MouseEventArgs e)
        {
            //create strip nemu for lv_LockedOutOldList. Functions: copy PcName, AllPcName, UserName.
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip myMenu = new ContextMenuStrip();
                if (lv_LockedOutOldList.SelectedItems != null)
                {
                    myMenu.Items.Add("Copy PC name");
                    myMenu.Items.Add("Copy User name");
                    myMenu.Items.Add("Copy all PC names");
                    myMenu.Items.Add("Copy PC name (forAD)");
                    myMenu.Items.Add("Copy all PC names (forAD)");
                    myMenu.Items[0].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyPcName);
                    myMenu.Items[1].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyUserName);
                    myMenu.Items[2].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyPcNames);
                    myMenu.Items[3].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyPcNameAD);
                    myMenu.Items[4].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyPcNamesAD);
                }
                else
                {
                    myMenu.Items.Add("Copy all PC names");
                    myMenu.Items[0].Click += new System.EventHandler(this.lv_LockedOutOldList_CMSI_CopyPcNames);
                }
                myMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void lv_LockedOutOldList_CMSI_CopyPcName(object sender, EventArgs e)
        {
            //copy selected PC name/names from lv_LockedOutOldList to Clipboard
            int itemCount = lv_LockedOutOldList.SelectedItems.Count;
            string itemText = "";
            if (itemCount > 0)
            {
                if (itemCount == 1)
                {
                    itemText = lv_LockedOutOldList.SelectedItems[0].SubItems[3].Text;
                }
                else
                {
                    foreach (ListViewItem item in lv_LockedOutOldList.SelectedItems)
                    {
                        if (itemText == "")
                        {
                            itemText = item.SubItems[3].Text;
                        }
                        else
                        {
                            itemText += " ; " + item.SubItems[3].Text;
                        }
                    }
                }
            }
            //MessageBox.Show("CopyPcName: " + itemText);
            Clipboard.SetText(itemText);
        }

        private void lv_LockedOutOldList_CMSI_CopyUserName(object sender, EventArgs e)
        {
            //copy selected User name/names from lv_LockedOutOldList to Clipboard
            int itemCount = lv_LockedOutOldList.SelectedItems.Count;
            string itemText = "";
            if (itemCount > 0)
            {
                if (itemCount == 1)
                {
                    itemText = lv_LockedOutOldList.SelectedItems[0].SubItems[2].Text;
                }
                else
                {
                    foreach (ListViewItem item in lv_LockedOutOldList.SelectedItems)
                    {
                        if (itemText == "")
                        {
                            itemText = item.SubItems[2].Text;
                        }
                        else
                        {
                            itemText += " ; " + item.SubItems[2].Text;
                        }
                    }
                }
            }
            //MessageBox.Show("CopyUserName: " + itemText);
            Clipboard.SetText(itemText);
        }

        private void lv_LockedOutOldList_CMSI_CopyPcNames(object sender, EventArgs e)
        {
            //copy all PC names from lv_LockedOutOldList to Clipboard separated ;
            string itemText = "";
            foreach (ListViewItem item in lv_LockedOutOldList.Items)
            {
                if (itemText == "")
                {
                    itemText = item.SubItems[3].Text;
                }
                else
                {
                    itemText += " ; " + item.SubItems[3].Text;
                }
            }
            //MessageBox.Show("CopyPcNames: " + itemText);
            Clipboard.SetText(itemText);
        }

        private void lv_LockedOutOldList_CMSI_CopyPcNameAD(object sender, EventArgs e)
        {
            //copy selected PC name/names from lv_LockedOutOldList to Clipboard separated ","
            int itemCount = lv_LockedOutOldList.SelectedItems.Count;
            string itemText = "";
            if (itemCount > 0)
            {
                if (itemCount == 1)
                {
                    itemText = @"""" + lv_LockedOutOldList.SelectedItems[0].SubItems[3].Text + @"""";
                }
                else
                {
                    foreach (ListViewItem item in lv_LockedOutOldList.SelectedItems)
                    {
                        if (itemText == "")
                        {
                            itemText = @"""" + item.SubItems[3].Text;
                        }
                        else
                        {
                            itemText += @""",""" + item.SubItems[3].Text;
                        }
                    }
                    if (itemText != "")
                    {
                        //end quote
                        itemText += @"""";
                    }
                }
            }
            Clipboard.SetText(itemText);
        }

        private void lv_LockedOutOldList_CMSI_CopyPcNamesAD(object sender, EventArgs e)
        {
            //copy all PC names from lv_LockedOutOldList to Clipboard separated ","
            string itemText = "";
            foreach (ListViewItem item in lv_LockedOutOldList.Items)
            {
                if (itemText == "")
                {
                    itemText = @"""" + item.SubItems[3].Text;
                }
                else
                {
                    itemText += @""",""" + item.SubItems[3].Text;
                }
            }
            if (itemText != "")
            {
                //end quote
                itemText += @"""";
            }
            Clipboard.SetText(itemText);
        }

        private void mS_unblockEmail_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //odemknutí emailu
            if (e.Button == MouseButtons.Right)
            {
                mS_unblockEmail.Items[0].Tag = e.Node.Text;
                mS_unblockEmail.Items[0].Text = "Unblock " + e.Node.Text + "@domena.cz";
                mS_unblockEmail.Location = tv_LockedOutEmails.Location;
                mS_unblockEmail.Show();
                toolStripTextBox2.Select();
                toolStripTextBox2.Focus();
            }
            else
            {
                mS_unblockEmail.Visible = false;
            }
        }

        private void tv_DepartmentCheck_MouseMove(object sender, MouseEventArgs e)
        {
            //umožnuje zobrazit tool tip nad pobočkamy

            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.tv_DepartmentCheck.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.tv_DepartmentCheck))
                    {
                        this.toolTip1.SetToolTip(this.tv_DepartmentCheck, theNode.Tag.ToString());
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.tv_DepartmentCheck, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.tv_DepartmentCheck, "");
            }
        }

        private void tv_LockedOutAccount_MouseMove(object sender, MouseEventArgs e)
        {
            //umožnuje zobrazit tool tip nad pobočkamy

            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.tv_LockedOutAccount.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.tv_LockedOutAccount))
                    {
                        this.toolTip1.SetToolTip(this.tv_LockedOutAccount, theNode.Tag.ToString());
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.tv_LockedOutAccount, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.tv_LockedOutAccount, "");
            }
        }

        private void tv_LockedOutAccount_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //odemknutí AD účtu
            if (e.Button == MouseButtons.Right)
            {
                mS_unblockUser.Items[0].Tag = e.Node.Text;
                mS_unblockUser.Items[0].Text = "Unblock " + e.Node.Text;
                mS_unblockUser.Location = tv_LockedOutAccount.Location;
                mS_unblockUser.Show();
            } else
            {
                mS_unblockUser.Visible = false;
            }
        }

        private void tv_ExpiredPasswords_MouseMove(object sender, MouseEventArgs e)
        {
            //umožnuje zobrazit tool tip nad pobočkamy

            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.tv_ExpiredPasswords.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.tv_ExpiredPasswords))
                    {
                        this.toolTip1.SetToolTip(this.tv_ExpiredPasswords, theNode.Tag.ToString());
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.tv_ExpiredPasswords, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.tv_ExpiredPasswords, "");
            }
        }

        private void tv_ExpiredPasswords_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //nastavení hesla pro expirované účty
            if (e.Button == MouseButtons.Right)
            {
                mS_setPassword.Items[0].Tag = e.Node.Text;
                mS_setPassword.Items[0].Text = "Nastav heslo pro " + e.Node.Text;
                mS_setPassword.Location = tv_ExpiredPasswords.Location;
                mS_setPassword.Show();
            }
            else
            {
                mS_unblockEmail.Visible = false;
            }
        }

        private void ts_unblockUser_Click(object sender, EventArgs e)
        {
            string user1 = mS_unblockUser.Items[0].Tag.ToString();
            if (user1 != "")
            {
                log("Odblokovávám uživatele.");
                PS_UnlockAccount(user1);
                mS_unblockUser.Visible = false;
                log("Dokončeno. Odblokovávání uživatele. " + user1);
            } else
            {
                mS_unblockUser.Visible = false;
                log("Nebylo možné odblokovat uživatele " + user1);
            }

        }

        private void ts_unblockEmail_Click(object sender, EventArgs e)
        {
            //name of accountName in tag
            string user1 = mS_unblockEmail.Items[0].Tag.ToString();
            IceWarpClass iwp = new IceWarpClass();

            if (user1 != "")
            {
                log("Odblokovávám email uživatele.");
                iwp.unblockEmail(user1);
                mS_unblockEmail.Visible = false;
                //deletion of item by name
                TreeNode userNode = (tv_LockedOutEmails.Nodes.Find(user1, true))[0];
                tv_LockedOutEmails.Nodes.Remove(userNode);
                user1 = "";
                log("Dokončeno. Odblokovávání emailu. " + user1);
            }
            else
            {
                mS_unblockEmail.Visible = false;
                log("Nebylo možné odblokovat email uživatele " + user1);
            }
        }

        private void ts_exit_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void ts_setPassword_Click(object sender, EventArgs e)
        {

            string userName = mS_setPassword.Items[0].Tag.ToString();
            string password = mS_setPassword.Items[1].Text;
            if (userName != "" & password != "")
            {
                mS_setPassword.Visible = false;
                mS_setPassword.Items[1].Text = "";
                DialogResult result = MessageBox.Show("Nastavit uživately: " + userName + System.Environment.NewLine + "Nové heslo: " + password, "nastavení hesla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //MessageBox.Show("Test");
                    PS_SetNewPassword(userName, password);
                }


            }
            else
            {
                if (userName == "")
                {
                    MessageBox.Show("Error. Není jméno uživatele.");
                }
                else
                {
                    MessageBox.Show("Vyplňte heslo.");
                }
            }


        }

        private void ts_CreateTestDepartments_Click(object sender, EventArgs e)
        {
            createTestDepartmentList();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //načte pobočky ze xml souborů
            List<Department> departmentList = deserialize();


            departmentCheck(departmentList);
            lockedOutAccount();
            lockedOutEmails();
            if (secondCheck.AddHours(1) < DateTime.Now)
            {
                expiredPasswords();
                secondCheck = DateTime.Now;
            }
            checkEmailsToSend();
            lockedOutOldList();

            //zaznamenání kdy proběhla poslední kontrola
            //log("Last Check: " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second);
            log("Last Check: " + DateTime.Now.ToString("HH:mm - ss"));
        }

        private List<ADuser> PS_SearchLocketAccounts()
        {
            //spustí PowerShell script na vyhledání uživatelů se zamklým účtem
            List<ADuser> userList = new List<ADuser>();
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    log("Hledám zamklé uživatelské účty.");
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Search-ADAccount –LockedOut | select name, samaccountname");
                    PSObject[] results = powerShell.Invoke().ToArray();
                    foreach (PSObject result in results)
                    {
                        ADuser user1 = new ADuser();
                        try { user1.nameFull = result.Members["name"].Value.ToString(); } catch { }
                        try { user1.nameAcco = result.Members["samaccountname"].Value.ToString(); } catch { }
                        userList.Add(user1);
                    }

                    if (powerShell.HadErrors == true)
                    {
                        //var test = powerShell.Streams.Error.ElementAt(0).Exception.Message;
                        MessageBox.Show("Chyba při provádění skriptu.");
                        foreach (var error in powerShell.Streams.Error)
                        {
                            MessageBox.Show("Chyba: " + error.Exception.Message);
                        }
                    }

                    log("Dokončeno. Hledani zamklých uživatelů.");
                }

            }
            return userList;
        }

        private List<ADuser> PS_GetOldLockedAccounts()
        {
            //spustí PowerShell script na vyhledání uživatelů s naposledy zamklým účtem
            List<ADuser> userList = new List<ADuser>();
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    log("Zjišťuji naposledy zablokované účty.");
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript("$timeNow = (Get-Date -Format 'dd/MM/yyyy'); $DomainControllers = Get-ADDomainController -Filter * ; $PDCEmulator = ($DomainControllers | Where-Object {$_.OperationMasterRoles -contains 'PDCEmulator'}); $LockedOutEvents = Get-WinEvent -ComputerName $PDCEmulator.HostName -FilterHashtable @{LogName='Security';Id=4740} -ErrorAction Stop | Sort-Object -Property TimeCreated -Descending; $LockedOutEventsMessage = New-Object System.Collections.Generic.List[System.Object];");
                    powerShell.AddScript("Foreach($event in $LockedOutEvents){$eventXML = [xml]$event.ToXml(); $eventArray = New-Object -TypeName PSObject -Property @{EventID = $event.id;EventRecordID = $event.RecordId;EventTimeDate = Get-Date $event.timecreated -Format 'dd/MM/yyyy';EventTime = Get-Date $event.timecreated -Format 'HH:mm:ss';EventDay = $event.timecreated.Day;LockedAccount = $eventXML.Event.EventData.Data[0].'#text' ;FromComputer = $eventXML.Event.EventData.Data[1].'#text' ;OnServer = $eventXML.Event.EventData.Data[4].'#text' };if($timeNow -le ($eventArray.EventTimeDate)){$LockedOutEventsMessage.add($eventArray)}}");
                    powerShell.AddScript("$LockedOutEventsMessage | select LockedAccount,FromComputer,EventTime,EventTimeDate,EventRecordID");
                    PSObject[] results = null;
                    try
                    {
                        //pokus kvůli možnému nevrácení výsledků
                        results = powerShell.Invoke().ToArray();
                    }
                    catch { }

                    if (results != null)
                    {
                        //ošetření erroru při uspání PC  /\

                        foreach (PSObject result in results)
                        {
                            ADuser user1 = new ADuser();
                            try { user1.nameAcco = result.Members["LockedAccount"].Value.ToString(); } catch { }
                            try { user1.lockFrom = result.Members["FromComputer"].Value.ToString(); } catch { }
                            try { user1.lockTime = result.Members["EventTime"].Value.ToString(); } catch { }
                            try { user1.lockDate = result.Members["EventTimeDate"].Value.ToString(); } catch { }
                            try { user1.eventID = result.Members["EventRecordID"].Value.ToString(); } catch { }
                            userList.Add(user1);
                        }
                        log("Dokončeno. Seznam naposledy zamklé účty.");
                    }

                }
            }
            return userList;
        }

        private List<ADuser> PS_GetPasswordExpired()
        {
            //spustí PowerShell script na vyhledání uživatelů s naposledy zamklým účtem
            List<ADuser> userList = new List<ADuser>();
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    log("Procházím účty s expirací hesla.");
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript(@"$samaccountname = ""*"";$ADusers = get-ADuser -filter ""samaccountname -like '$samaccountname'"" -Properties Name,pwdLastSet,PasswordNeverExpires,enabled,logonCount|Sort-Object sAMAccountname;$userListPass = @()");
                    powerShell.AddScript("ForEach($ADuser in $ADusers){if (($ADuser.enabled -eq $true)-and($ADuser.PasswordNeverExpires -eq $false)){ $lastchange = [datetime]::FromFileTime($ADuser.pwdlastset[0]);$today = Get-Date;$timediff = New-TimeSpan $lastchange $(Get-Date);$selected_user = New-Object psobject;$selected_user | Add-Member NoteProperty -Name 'name' -Value $ADuser.name;$selected_user | Add-Member NoteProperty -Name 'sAMAccountname' -Value $ADuser.sAMAccountname;$selected_user | Add-Member NoteProperty -Name 'dateOfPasswSet' -Value $lastchange;$selected_user | Add-Member NoteProperty -Name 'daysFromChange' -Value $timediff.Days;$userListPass+=$selected_user }else{}} $userListPass | Select name,sAMAccountname,dateOfPasswSet,daysFromChange,passwordExpired");
                    PSObject[] results = powerShell.Invoke().ToArray();
                    foreach (PSObject result in results)
                    {
                        ADuser user1 = new ADuser();
                        try { user1.nameFull = result.Members["name"].Value.ToString(); } catch { }
                        try { user1.nameAcco = result.Members["sAMAccountname"].Value.ToString(); } catch { }
                        try { user1.passwordDateLastSet = result.Members["dateOfPasswSet"].Value.ToString(); } catch { }
                        try { user1.PasswordDayFromChange = Convert.ToInt32(result.Members["daysFromChange"].Value.ToString()); } catch { }
                        userList.Add(user1);
                    }
                    log("Dokončeno. Seznam naposledy zamklé účty.");
                }
            }
            return userList;
        }

        private List<Department> deserialize()
        {
            //načte data do listu departmentů ze souborů

            List<Department> departmentList = new List<Department>();

            try
            {
                string path = Environment.CurrentDirectory + "\\department";
                if (Directory.Exists(path))
                {
                    //načte cesty xml souborů
                    string[] files = Directory.GetFiles(path, "*.xml");

                    //vytvoří instance (z xml) přidá do listu
                    foreach (string file in files)
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(Department));
                        using (TextReader reader = new StreamReader(file))
                        {
                            object obj = deserializer.Deserialize(reader);
                            Department XmlData = (Department)obj;
                            departmentList.Add(XmlData);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Nebylo možné načíst položky středisek.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return departmentList;
        }

        private void serialize(List<Department> departmentList)
        {
            //uloží data z listu do souborů (použito pro dostupnost poboček)
            try
            {
                //vytvoří cestu
                string path = Environment.CurrentDirectory + "\\department";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //vytvoří xml soubory
                foreach (Department departmentItem in departmentList)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Department));
                    using (TextWriter writer = new StreamWriter($"{path}\\{departmentItem.name}.xml"))
                    {
                        serializer.Serialize(writer, departmentItem);
                    }
                }
                MessageBox.Show("Položky středisek uloženy.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Nebylo možné uložit položky středisek.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void departmentCheck(List<Department> departmentList)
        {
            //zkontoluje dostupnost ip adres poboček a zobrazí seznam

            pb_DepartmentCheck.Image = Properties.Resources.icon_Y;
            tv_DepartmentCheck.Nodes.Clear();

            //přidá strukturu na zobrazení
            tv_DepartmentCheck.Nodes.Add("Nedostupné servery");
            tv_DepartmentCheck.Nodes.Add("Dostupné servery");

            //projde servery a zobrazí je v treeview
            foreach (Department dep1 in departmentList)
            {
                log("Ověřuju dostupnost poboček: " + dep1.name);
                int pingnuto = dep1.pingIt();

                TreeNode tnode1 = new TreeNode();
                tnode1.Text = dep1.name;
                tnode1.Tag = dep1.ip; //pro tooltip
                tnode1.ImageIndex = pingnuto + 1;
                tnode1.SelectedImageIndex = pingnuto + 1;
                tv_DepartmentCheck.Nodes[pingnuto].Nodes.Add(tnode1);

                //treeView1.Nodes[dep1.pingIt()].Nodes.Add(dep1.name);

                //rozbalí zobrazení
                tv_DepartmentCheck.Nodes[0].ExpandAll();
                tv_DepartmentCheck.Nodes[1].ExpandAll();
            }

            //přířadí obrázky do treeView
            //foreach (TreeNode node1 in treeView1.Nodes[1].Nodes)
            //{
            //    node1.ImageIndex = 2;
            //}
            //foreach (TreeNode node1 in treeView1.Nodes[0].Nodes)
            //{
            //    node1.ImageIndex = 1;
            //}

            pb_DepartmentCheck.Image = Properties.Resources.icon_G;
            log("...");
        }

        private void PS_UnlockAccount(string userName)
        {
            //spustí PowerShell script na odblokování uživatele
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    log("Odblokovávám uživatele " + userName);
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript(@"Unlock-ADaccount -Identity " + userName);
                    powerShell.Invoke();
                    log("Dokončeno. Odblokování uživatele " + userName);
                }
            }
        }

        private void PS_SetNewPassword(string userName, string password)
        {
            //spustí PowerShell script na změnu hesla uživatele
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    log("Nastavuji heslo pro uživatele " + userName);
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript(@"Set-ADAccountPassword -Identity """ + userName + @""" -Reset -NewPassword (ConvertTo-SecureString -AsPlainText """ + password + @""" -Force)");
                    powerShell.Invoke();

                    if (powerShell.HadErrors == true)
                    {
                        log("Error. Nastavení hesla Selhalo. ");
                        foreach (var error in powerShell.Streams.Error)
                        {
                            DialogResult nextmessage = MessageBox.Show("" + error, "Error v Powershellu. Detailed message.", MessageBoxButtons.OKCancel);
                            if (nextmessage == DialogResult.Cancel)
                                break;
                        }
                    }
                    else
                    {
                        log("Dokončeno. Nastavení hesla pro " + userName);
                    }


                }
            }
        }

        private void lockedOutAccount()
        {
            //zobrazí aktuální seznam zaklých účtů
            pb_LockedOutAccount.Image = Properties.Resources.icon_Y;
            log("Kontroluji uzamklé účty.");
            tv_LockedOutAccount.Nodes.Clear();
            List<ADuser> locketAccounts = PS_SearchLocketAccounts();
            foreach (ADuser user1 in locketAccounts)
            {
                if (locketAccounts[0].ToString() != "")
                {
                    //MessageBox.Show("Účet: " + locketAccounts[0].ToString() + ", S jménem: " + locketAccounts[1].ToString());
                    TreeNode tnode1 = new TreeNode();
                    tnode1.Text = user1.nameAcco;
                    tnode1.Tag = user1.nameFull;
                    tnode1.ImageIndex = 1;
                    tnode1.SelectedImageIndex = 1;
                    tv_LockedOutAccount.Nodes.Add(tnode1);

                    //treeView2.Nodes.Add(user1.nameAcco + "    - (" + user1.nameFull + ")");
                }
            }

            foreach (TreeNode node1 in tv_LockedOutAccount.Nodes)
            {
                node1.ImageIndex = 1;
            }

            pb_LockedOutAccount.Image = Properties.Resources.icon_G;
            log("...");
        }

        private void lockedOutEmails()
        {
            //zobrazí seznam zamklých poštovních účtů z Icewarpu
            pb_LockedOutEmails.Image = Properties.Resources.icon_Y;

            log("Kontroluji zablokované emaily.");
            tv_LockedOutEmails.Nodes.Clear();
            IceWarpClass iwp = new IceWarpClass();
            List<string> usersBlocked = iwp.checkIfFileExist();
            int citacka = 0;
            foreach (string user1 in usersBlocked)
            {
                tv_LockedOutEmails.Nodes.Add(user1);
                tv_LockedOutEmails.Nodes[citacka].Name = user1;
                citacka++;
            }
            pb_LockedOutEmails.Image = Properties.Resources.icon_G;
            log("Icewarp Done. " + citacka);
        }

        private void lockedOutOldList()
        {
            //zobrazí seznam naposledy zamklých účtů (z DCčka)
            pb_LockedOutOldList.Image = Properties.Resources.icon_Y;
            log("Zjišťuji naposledy zablokované účty.");
            int nacitacka = 0;
            //získá seznam zamklých účtů z powershelu
            List<ADuser> lockedAccounts = PS_GetOldLockedAccounts();
            lv_LockedOutOldList.Items.Clear();
            //vloží data do listView
            foreach (ADuser lockedUser in lockedAccounts)
            {
                ListViewItem user0 = new ListViewItem(nacitacka.ToString());
                user0.SubItems.Add(lockedUser.lockTime);
                user0.SubItems.Add(lockedUser.nameAcco);
                user0.SubItems.Add(lockedUser.lockFrom);
                lv_LockedOutOldList.Items.Add(user0);
                nacitacka++;
            }
            pb_LockedOutOldList.Image = Properties.Resources.icon_G;
            log("...");
        }

        private void expiredPasswords()
        {
            //zobrazí seznam účtů s vypršelým heslem (+účty blízko vypršení)
            pb_ExpiredPasswords.Image = Properties.Resources.icon_Y;

            log("Kontroluji účty na expiraci hesla.");
            List<ADuser> ExpiredPassAccount = PS_GetPasswordExpired();

            tv_ExpiredPasswords.Nodes.Clear();
            tv_ExpiredPasswords.Nodes.Add("Vyprší heslo do dvou dnů:");
            tv_ExpiredPasswords.Nodes.Add("Vypršelo heslo:");
            int citacka = 0;
            foreach (ADuser user1 in ExpiredPassAccount)
            {
                TreeNode tnode1 = new TreeNode();
                tnode1.Text = user1.nameAcco;
                tnode1.Tag = (user1.nameFull + " , " + user1.PasswordDayFromChange + " , " + user1.passwordDateLastSet);
                tnode1.ImageIndex = 1;

                if (user1.PasswordDayFromChange >= 120)
                {
                    tnode1.SelectedImageIndex = 1;
                    tv_ExpiredPasswords.Nodes[1].Nodes.Add(tnode1);
                }
                else if ((user1.PasswordDayFromChange >= 118) & (user1.PasswordDayFromChange <= 120))
                {
                    tnode1.ImageIndex = 1;
                    tnode1.SelectedImageIndex = 1;
                    tv_ExpiredPasswords.Nodes[0].Nodes.Add(tnode1);
                }
                citacka++;
            }
            tv_ExpiredPasswords.Nodes[0].Text = "(" + tv_ExpiredPasswords.Nodes[0].Nodes.Count + ") Vyprší heslo do dvou dnů:";
            tv_ExpiredPasswords.Nodes[1].Text = "(" + tv_ExpiredPasswords.Nodes[1].Nodes.Count + ") Vypršelo heslo:";
            tv_ExpiredPasswords.Nodes[0].ExpandAll();
            pb_ExpiredPasswords.Image = Properties.Resources.icon_G;
            log("...");
        }

        private void checkEmailsToSend()
        {
            //zobrazí počet emailů k odeslání ve složce poštovního serveru

            pb_CheckEmailsToSend.Image = Properties.Resources.icon_Y;
            log("Kontroluji frontu emailů.");
            IceWarpClass iwp = new IceWarpClass();
            int numberOfEmails = iwp.checkOutgoingFilles();
            tb_numberOfEmails.Text = "" + numberOfEmails;

            if (numberOfEmails > 10)
            {
                tb_numberOfEmails.BackColor = Color.Orange;
                if (numberOfEmails > 100)
                {
                    tb_numberOfEmails.BackColor = Color.Red;
                }
            }
            else
            {
                tb_numberOfEmails.BackColor = SystemColors.Window;
            }
            pb_CheckEmailsToSend.Image = Properties.Resources.icon_G;
            log("...");
        }

        private void createTestDepartmentList()
        {
            //fill departmentList with test data
            List<Department> departmentList = new List<Department>();

            Department p2 = new Department("Google", "8.8.8.8");
            departmentList.Add(p2);
            Department p3 = new Department("FalseIP", "111.111.111.111");
            departmentList.Add(p3);
            Department p4 = new Department("local", "10.0.0.1");
            departmentList.Add(p4);


            //uloží data do souborů
            serialize(departmentList);
        }

        private void hideMenu()
        {
            //schová všechna otevřená menu (MenuStrip)
            mS_unblockUser.Visible = false;
            mS_unblockEmail.Visible = false;
            mS_setPassword.Visible = false;
        }

        private void setTimer1Interval()
        {
            //nasvavý interval timeru (z tool strip text boxu TsTbTimerInterval)

            string textBox = TsTbTimerInterval.Text;

            try
            {
                int interval = Convert.ToInt32(textBox) * 1000;
                if (interval > 0)
                {
                    timer1.Interval = interval;
                }
                else
                {
                    throw new Exception("Range error for Interval.");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Nepodařilo se nastavyt interval pro opakovanou kontrolu.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                timer1.Interval = 100000;
            }
        }
    }
}

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        //public static string addQuotes(this String input)
        //{
        //    return @"""" + input + @"""";
        //}

        //public static string addQuotes(this Boolean input)
        //{
        //    string final = "";
        //    if (input)
        //    {
        //        final = "$true";
        //    }
        //    else
        //    {
        //        final = "$false";
        //    }
        //    return final;
        //}

        //public static int toInt(this bool input)
        //{
        //    //vrátí 1 pokud ano jinak ne
        //    int final = 0;
        //    if (input)
        //    {
        //        final = 1;
        //    } else
        //    {
        //        final = 0;
        //    }
        //    return final;
        //}
    }
}