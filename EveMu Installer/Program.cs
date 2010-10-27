using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveMu_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EveMu Server Installer");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Engine engine = new Engine();

            if (engine.DownloadServer())
            {
                engine.ConfigureServer();
            }
        }
    }
}
