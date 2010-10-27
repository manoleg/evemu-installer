using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Xml;

namespace EveMu.Downloader
{
    public class Downloader
    {
        private String repoUrl;

        private WebClient client;
        private ZipShit zipShit;

        public Downloader(String repoUrl)
        {
            this.repoUrl = repoUrl;

            this.client = new WebClient();
            this.zipShit = new ZipShit();
        }

        public List<Version> GetAvailableVersions()
        {
            List<Version> versions = new List<Version>();

            Boolean versionsFileExists = this.VersionsFileExists();

            if (versionsFileExists == false)
            {
                this.GetVersionsFile(this.repoUrl);
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("installer/Versions.xml");

                foreach (XmlNode node in xmlDoc.DocumentElement)
                {
                    if (node.Name == "Version")
                    {
                        String id = node.Attributes.GetNamedItem("id").InnerText;
                        String name = node.Attributes.GetNamedItem("name").InnerText;
                        String arch = node.Attributes.GetNamedItem("arch").InnerText;
                        String rev = node.Attributes.GetNamedItem("rev").InnerText;
                        String filename = node.Attributes.GetNamedItem("filename").InnerText;

                        versions.Add(new Version(id, name, arch, rev, filename));
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Manager.Logger.AddToLog(ex.Message);
            }

            return versions;
        }

        private Boolean VersionsFileExists()
        {
            Boolean fileExists = File.Exists("installer\\Versions.xml");
            
            if (fileExists == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GetVersionsFile(String url)
        {
            if (url[url.Length - 1] == '/')
            {
                url = url.Substring(0, url.Length - 1);
            }

            try
            {
                this.client.DownloadFile(url + "/versions.xml", "installer/versions.xml");
            }
            catch (Exception ex)
            {
                Logging.Manager.Logger.AddToLog(ex.Message);
            }
        }

        public Boolean DownloadVersion(String id)
        {
            foreach (Version version in this.GetAvailableVersions())
            {
                if (version.Id == id)
                {
                    try
                    {
                        this.client.DownloadFile(this.repoUrl + "/versions/" + version.Filename, "temp/" + version.Filename);
                        this.Unzip(version);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Logging.Manager.Logger.AddToLog(ex.Message);
                        return false;
                    }
                }
            }

            return false;
        }

        private void Unzip(Version version)
        {
            this.zipShit.ExtractZipFile("temp/" + version.Filename, null, "server");
        }
    }
}
