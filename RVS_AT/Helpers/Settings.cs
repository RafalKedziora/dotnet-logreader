using System.IO;
using Newtonsoft.Json;

namespace RVS_AT
{
    class Settings
    {
        public static Ftp LoadFtp()
        {
            if (File.Exists("Settings/Ftp.json"))
            {
                var settingsDeserialization = File.ReadAllText(@"Settings/Ftp.json");
                Ftp ftp = JsonConvert.DeserializeObject<Ftp>(settingsDeserialization);
                _ = ftp.PathToFiles.Remove(0, 1);
                return ftp;
            }
            return null;
        }

        public static UIColors LoadColors()
        {
            if (File.Exists("Settings/Colors.json"))
            {
                var settingsDeserialization = File.ReadAllText(@"Settings/Colors.json");
                UIColors colors = JsonConvert.DeserializeObject<UIColors>(settingsDeserialization);
                return colors;
            }
            return null;
        }
    }
}
