using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveMu.Configurator
{
    public class Configuration
    {
        public String DbHostname;
        public String DbPort;
        public String DbUsername;
        public String DbPassword;
        public String DbDatabase;

        public String ServerPort;

        public String LogFile;

        public String CharStartingAmount;

        public String AccLoginMessage;

        public Configuration(String dbHostname,
            String dbPort, String dbUsername,
            String dbPassword,
            String dbDatabase,
            String serverPort,
            String logFile,
            String charStartingAmount,
            String accLoginMessage)
        {
            this.DbHostname = dbHostname;
            this.DbPort = dbPort;
            this.DbUsername = dbUsername;
            this.DbPassword = dbPassword;
            this.DbDatabase = dbDatabase;

            this.ServerPort = serverPort;

            this.LogFile = logFile;

            this.CharStartingAmount = charStartingAmount;

            this.AccLoginMessage = accLoginMessage;
        }
    }
}
