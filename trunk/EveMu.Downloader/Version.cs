using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveMu.Downloader
{
    public class Version
    {
        private String id;
        private String name;
        private String arch;
        private String rev;
        private String filename;

        public String Id
        {
            get { return this.id; }
        }
        public String Name
        {
            get { return this.name; }
        }
        public String Arch
        {
            get { return this.arch; }
        }
        public String Rev
        {
            get { return this.rev; }
        }
        public String Filename
        {
            get { return this.filename; }
        }

        public Version(String id, String name, String arch, String rev, String filename)
        {
            this.id = id;
            this.name = name;
            this.arch = arch;
            this.rev = rev;
            this.filename = filename;
        }
    }
}
