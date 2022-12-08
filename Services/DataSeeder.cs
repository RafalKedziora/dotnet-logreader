using Domain.Models;
using Services.Data;

namespace Services
{
    public class DataSeeder
    {
        private readonly LFContext _context;

        public DataSeeder(LFContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.FtpCredentials.Any())
                {

                    var ftpCredentials = GetCredentials();
                    _context.FtpCredentials.Add(ftpCredentials);
                    _context.SaveChanges();

                }

                if (!_context.UIColors.Any())
                {
                    var uiColors = GetUIColors();
                    _context.UIColors.Add(uiColors);
                    _context.SaveChanges();
                }
            }
        }

        private UIColors GetUIColors()
        {
            var uiColors = new UIColors()
            {
                Id = 1,
                Background = "#FF141E30",
                BackgroundButton = "#FF141E30",
                Gradient1 = "#FF141E30",
                Gradient2 = "#FF141E30",
                Gradient3 = "#FF243B55"
            };
            return uiColors;
        }

        private FtpCredentials GetCredentials()
        {
            var ftpCredentials = new FtpCredentials
            {
                Id = 1,
                Host = "127.0.0.1",
                Login = "admin",
                Password = "admin",
                PathToFiles = "/main/logs",
                Port = 21
            };
            return ftpCredentials;
        }
    }
}
