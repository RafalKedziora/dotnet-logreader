using System.IO;
using Newtonsoft.Json;

namespace RVS_AT
{
    class Settings
    {
        public static FTP loadSettings()
        {
            string settingsDeserialization;
            if (File.Exists("Settings.json"))
            {
                settingsDeserialization = File.ReadAllText(@"Settings.json");
                FTP FTP = JsonConvert.DeserializeObject<FTP>(settingsDeserialization);
                FTP.pathToFiles.Remove(0, 1);
                return FTP;
            }
            return null;
        }
    }
}
