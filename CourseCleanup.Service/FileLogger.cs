using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace CourseCleanup.Service
{
    public class FileLogger
    {
        public static void Log(string text)
        {
            var writeLogs = ConfigurationManager.AppSettings["WriteLogs"] ?? "N";

            if (writeLogs == "Y")
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directoryPath = Path.GetDirectoryName(location);

                using (var writer = new StreamWriter(directoryPath + @"\PublicationManager.PubMedSearch.Log.txt", true))
                {
                    writer.WriteLine("{0}: " + text, DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    writer.Close();
                }
            }
        }
    }
}
