using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace EveMu.Configurator
{
    public class Configurator
    {
        public Configuration configuration;

        public Boolean Configure(Configuration configuration)
        {
            this.configuration = configuration;

            String configuarionString = "<eve-server>" + Environment.NewLine
                + "<account>" + Environment.NewLine
                + "<loginMessage>" + Environment.NewLine
                + System.IO.File.ReadAllText(configuration.AccLoginMessage) + Environment.NewLine
                + "</loginMessage>" + Environment.NewLine
                + "</account>" + Environment.NewLine
                + "<character>" + configuration.CharStartingAmount + "</character>" + Environment.NewLine
                + "<database>" + Environment.NewLine
                + "<host>" + configuration.DbHostname + "</host>" + Environment.NewLine
                + "<username>" + configuration.DbUsername + "</username>" + Environment.NewLine
                + "<password>" + configuration.DbPassword + "</password>" + Environment.NewLine
                + "<db>" + configuration.DbDatabase + "</db>" + Environment.NewLine
                + "</database>" + Environment.NewLine
                + "<files>" + Environment.NewLine
                + "<log>" + configuration.LogFile + "</log>" + Environment.NewLine
                + "<net>" + Environment.NewLine
                + "<port>" + configuration.ServerPort + "</port>" + Environment.NewLine
                + "</net>" + Environment.NewLine
                + "</eve-server>";

            try
            {
                System.IO.File.WriteAllText("server/etc/eve-server.xml", configuarionString);
                return true;
            }
            catch (Exception ex)
            {
                Logging.Manager.Logger.AddToLog(ex.Message);
                return false;
            }
        }
    }
}
