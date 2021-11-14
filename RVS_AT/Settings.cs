using System.IO;
using Newtonsoft.Json;

namespace RVS_AT
{
    class Settings
    {
        public static Ftp Load()
        {
            if (File.Exists("Settings.json"))
            {
                var settingsDeserialization = File.ReadAllText(@"Settings.json");
                Ftp ftp = JsonConvert.DeserializeObject<Ftp>(settingsDeserialization);
                _ = ftp.PathToFiles.Remove(0, 1);
                return ftp;
            }
            return null;
        }
    }
}
