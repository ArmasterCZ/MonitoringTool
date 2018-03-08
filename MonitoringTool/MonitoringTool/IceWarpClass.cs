using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceWarpLib.Objects;
using IceWarpLib.Rpc;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.IO;
using System.Threading;
using System.Configuration;


using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace MonitoringTool
{
    class IceWarpClass
    {
        /// <summary>
        /// Class for check files in linux version of Icewarp server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>

        private string userName;
        private string password;
        private string serverIp;

        public IceWarpClass()
        {
            userName = readFromConfig("icewarpUserName");
            password = readFromConfig("icewarpPassword");
            serverIp = readFromConfig("icewarpServerIp");
        }

        static string readFromConfig(string key)
        {
            //načte přihlašovací údaje z .config souboru
            string result = null;
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                Exception icewarpError = new Exception("Chyba při načítání údajů z configuračního souboru. Položka " + key);
                throw icewarpError;
            }
            return result ?? "";
        }

        public List<string> checkIfFileExist()
        {
            //Projde složky email. schránek na pošťákovy, a pokusí se zjistit, jestly je účet uzamčen.
            //(pokud se zdá že by mohl být stáhne soubor a koukne na bit)

            //otevře spojení na pošťáka
            string dirEmails = "/opt/icewarp/mail/domena.cz/";
            List<string> usersBlocked = new List<string>();

            using (SftpClient sftp = new SftpClient(serverIp, userName, password))
            {
                try
                {
                    sftp.Connect();
                    var files = sftp.ListDirectory(dirEmails);
                    foreach (var file in files)
                    {
                        string userName = file.Name;
                        string fullPath = dirEmails + userName + "/login.dat";
                        bool userIsBlocked = sftp.Exists(fullPath);
                        if (userIsBlocked)
                        {
                            //stáhne soubor login.dat do lokálu
                            string localFilePath = Directory.GetCurrentDirectory() + @"\temporary file.dat";
                            Stream file1 = File.OpenWrite(localFilePath);
                            sftp.DownloadFile(fullPath, file1);
                            file1.Close();

                            if (checkDatFile(localFilePath))
                            {
                                //zkontroluje z lokálního souboru zda se jedná o zablokování

                                Console.WriteLine(userName + " je blokován");
                                usersBlocked.Add(userName);
                                //System.Windows.Forms.MessageBox.Show("Uživatel " + userName + " je blokován");
                            }
                            File.Delete(localFilePath);
                        }
                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
            return usersBlocked;
        }

        private bool checkDatFile(string path)
        {
            //zkontroluje zda soubor obsahuje na specifické pozici byt 1 nebo 5
            bool result = false;
            try
            {
                byte[] data = File.ReadAllBytes(path);
                if (data[0] == 1)
                {
                    result = false;
                    //Console.WriteLine("no locked.");
                }
                if (data[0] == 5)
                {
                    result = true;
                    //Console.WriteLine("Locked.");
                }
            }
            catch (Exception e)
            {
                //soubor nenalezen
                throw e;
            }
            return result;
        }

        public int checkOutgoingFilles()
        {
            //zjistí jestli nejsou emaily ve frontě na odeslání ( = spam in progress)

            //otevře spojení na pošťáka
            string dirFolders = "/opt/icewarp/mail/_outgoing/";
            string[] foldersName = { "priority_0", "priority_1", "priority_2" };
            List<string> usersBlocked = new List<string>();
            int numberOfEmails = 0;

            using (SftpClient sftp = new SftpClient(serverIp, userName, password))
            {
                try
                {
                    sftp.Connect();

                    foreach (var folder in foldersName)
                    {
                        string fullPath = dirFolders + folder + "/";
                        var files = sftp.ListDirectory(fullPath);
                        foreach (var file in files)
                        {
                            if ((file.Name != ".") & (file.Name != ".."))
                                numberOfEmails += 1;
                        }

                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
            return numberOfEmails;
        }

        public void unblockEmail(string user1)
        {
            //připojí se k serveru a smaže "login.dat" pod složkou uživatele (způsobý odblokování)
            if (user1 != "")
            {
                string dirEmails = "/opt/icewarp/mail/domena.cz/";

                using (SftpClient sftp = new SftpClient(serverIp, userName, password))
                {
                    try
                    {
                        //připojení k serveru
                        sftp.Connect();

                        var files = sftp.ListDirectory(dirEmails);
                        string fullPath = dirEmails + user1 + "/login.dat";
                        bool userIsBlocked = sftp.Exists(fullPath);

                        if (userIsBlocked)
                        {
                            //zmaže soubor login.dat
                            sftp.DeleteFile(fullPath);
                        }

                        sftp.Disconnect();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An exception has been caught " + e.ToString());
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Uživatel (" + user1 + ") nenalezen.");
            }
        }

    }
}
