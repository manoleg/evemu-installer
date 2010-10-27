using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveMu_Installer
{
    class Engine
    {
        private EveMu.Downloader.Downloader downloader;

        String dbHostname = "127.0.0.1";
        String dbPort = "3306";
        String dbUsername = "root";
        String dbPassword = "123456";
        String dbdatabase = "evemu";

        String serverPort = "26001";

        String logFile = "../log/eve-server.log";

        String charStartingAmount = "5000";

        String accLoginMessage = "installer/login.txt";

        public Boolean DownloadServer()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("[Server Download]");
            Console.WriteLine("-----------------");
            Console.WriteLine();

            String defaultRepoUrl = "http://www.sourced-software.co.cc/evemu_installer";

            Console.WriteLine("Which repository would you like to use?[" + defaultRepoUrl + "]");

            String repoUrlInput = Console.ReadLine();

            if (repoUrlInput == "")
            {
                repoUrlInput = defaultRepoUrl;
            }

            this.downloader = new EveMu.Downloader.Downloader(repoUrlInput);

            Console.WriteLine("The following versions are available at " + repoUrlInput);
            Console.WriteLine();
            
            foreach (EveMu.Downloader.Version version in this.downloader.GetAvailableVersions())
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("-   Id: " + version.Id);
                Console.WriteLine("- Name: " + version.Name);
                Console.WriteLine("- Arch: " + version.Arch);
                Console.WriteLine("-  Rev: " + version.Rev);
                Console.WriteLine("- File: " + version.Filename);
                Console.WriteLine("---------------------------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("Please enter the Id of the Version you wish to install:");
            Console.Write("#");

            String serverVersionId = Console.ReadLine();

            if (downloader.GetAvailableVersions().Count == 0)
            {
                return false;
            }

            foreach (EveMu.Downloader.Version version in downloader.GetAvailableVersions())
            {
                if (version.Id == serverVersionId)
                {
                    if (System.IO.File.Exists("temp/" + version.Filename))
                    {
                        Console.WriteLine(version.Name + " already downloaded.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Downloading " + version.Name);
                        Console.WriteLine();
                        return downloader.DownloadVersion(serverVersionId);
                    }
                }
            }

            return true;
        }

        public Boolean ConfigureServer()
        {
            EveMu.Configurator.Configurator configurator = new EveMu.Configurator.Configurator();

            Console.WriteLine("-------------------");
            Console.WriteLine("[Database Settings]");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            #region Get MySQL Host
            Console.Write("MySQL Hostname:[" + this.dbHostname + "]");
            String dbHostnameInput = Console.ReadLine();

            if (dbHostnameInput != "")
            {
                dbHostname = dbHostnameInput;
            }
            #endregion

            #region Get MySQL Port
            Console.Write("MySQL Port:[" + this.dbPort + "]");
            String dbPortInput = Console.ReadLine();

            if(dbPortInput != "")
            {
                this.dbPort = dbPortInput;
            }
            #endregion

            #region Get MySQL Username
            Console.Write("MySQL Username:[" + this.dbUsername + "]");
            String dbUsernameInput = Console.ReadLine();

            if (dbUsername != "")
            {
                dbUsername = dbUsernameInput;
            }
            #endregion

            #region Get MySQL Password
            while (GetMySQLPassword() == false)
            {
                Console.WriteLine("YOU MUST SUPPLY THE PASSWORD FOR " + this.dbUsername.ToUpper() + "!");
            }
            #endregion

            #region Get MySQL Database
            Console.Write("MySQL Database:[" + this.dbdatabase + "]");
            String dbdatabaseInput = Console.ReadLine();

            if (dbdatabaseInput != "")
            {
                this.dbdatabase = dbdatabaseInput;
            }
            #endregion

            Console.WriteLine();

            Console.WriteLine("-----------------");
            Console.WriteLine("[Server Settings]");
            Console.WriteLine("-----------------");
            Console.WriteLine();

            #region Get Server port
            Console.Write("Server Port:[" + this.serverPort + "]");
            String serverPortInput = Console.ReadLine();

            if (serverPortInput != "")
            {
                this.serverPort = serverPortInput;
            }
            #endregion

            Console.WriteLine();

            Console.WriteLine("--------------");
            Console.WriteLine("[Log Settings]");
            Console.WriteLine("--------------");
            Console.WriteLine();

            #region Get Log File
            Console.Write("Log File:[" + this.logFile + "]");
            String logFileInput = Console.ReadLine();

            if (logFileInput != "")
            {
                this.logFile = logFileInput;
            }
            #endregion

            Console.WriteLine();

            Console.WriteLine("------------------");
            Console.WriteLine("[Character Settings]");
            Console.WriteLine("------------------");
            Console.WriteLine();

            #region Get Character Starting Credits
            Console.Write("Starting Credits:[" + this.charStartingAmount + "]");
            String charStartingAmountInput = Console.ReadLine();

            if (charStartingAmountInput != "")
            {
                this.charStartingAmount = charStartingAmountInput;
            }
            #endregion

            return configurator.Configure(new EveMu.Configurator.Configuration(this.dbHostname, 
                this.dbPort, 
                this.dbUsername, 
                this.dbPassword, 
                this.dbdatabase, 
                this.serverPort, 
                this.logFile, 
                this.charStartingAmount,
                this.accLoginMessage));
        }

        private Boolean GetMySQLPassword()
        {
            Console.Write("MySQL Password:");

            String dbPasswordInput = Console.ReadLine();

            if (dbPasswordInput != "")
            {
                this.dbPassword = dbPasswordInput;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
