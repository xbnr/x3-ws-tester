using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleTester.Common
{
    internal class Updater
    {
        public VersionInformation OnLineVersion { get; private set; }

        public List<VersionInformation> AllVersions { get; private set; }

        /// <summary>
        /// Am'I up to date ?
        /// </summary>
        /// <returns></returns>
        public bool UpTodate()
        {
            var onLineVersionInformation = GetLastVersion();

            Version onLineVersion = new Version(onLineVersionInformation.Version);
            Version currentMdVersion = new Version(Program.GetApplicationVersion());

            if (onLineVersion.CompareTo(currentMdVersion) > 0)
            {
                return false;
            }
            return true;
        }

        private List<VersionInformation> DownloadJsonFiles(string urlInformation)
        {
            using (var streamReader = File.OpenText(urlInformation))
            {
                string json = streamReader.ReadToEnd();
                return  JsonConvert.DeserializeObject<List<VersionInformation>>(json);
            }
        }

        private List<VersionInformation> DownloadJsonHttp(string urlInformation)
        {
            List<VersionInformation> result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlInformation);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlInformation).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<VersionInformation>>(json);
                }
                else
                {
                    // UbiLog.Debug($"Error in DownloadJsonDataExecute: {response.ReasonPhrase}");
                }
            }
            return result;
        }

        private VersionInformation GetLastVersion()
        {
            if (OnLineVersion != null)
            {
                return OnLineVersion;
            }
            string urlInformation = ConfigurationManager.AppSettings["Application.UrlUpdateInformation"];
            urlInformation = WebUtility.UrlDecode(urlInformation);
            List<VersionInformation> versions = new List<VersionInformation>();
            if (!string.IsNullOrEmpty(urlInformation))
            {
                if (urlInformation.StartsWith("\\"))
                {
                    versions = DownloadJsonFiles(urlInformation);
                }
                else if (urlInformation.StartsWith("http://") || urlInformation.StartsWith("https://"))
                {                    
                    versions = DownloadJsonHttp(urlInformation);
                }
            }
            AllVersions = versions.OrderByDescending(p => p.Date).ToList();
            OnLineVersion = AllVersions.First();
            return OnLineVersion;
        }
    }
}
