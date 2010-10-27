using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logging
{
    public class Logger
    {
        public void AddToLog(String message)
        {
            File.AppendAllText("installer/Error.log", DateTime.Now + " - " + message);
        }
    }
}
