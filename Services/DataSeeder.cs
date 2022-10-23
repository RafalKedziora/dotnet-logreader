using Data;
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

        public async void Seed()
        {
            if(await _context.Database.CanConnectAsync())
            {
                if(!_context.FtpCredentials.Any())
                {
                    _ = Task.Run(() =>
                    {
                        var ftpCredentials = GetCredentials();
                        _context.FtpCredentials.AddAsync(ftpCredentials);
                        _context.SaveChangesAsync();

                    });
                }

                if(!_context.UIColors.Any())
                {
                    _ = Task.Run(() =>
                    {
                        var uiColors = GetUIColors();
                        _context.UIColors.AddAsync(uiColors);
                        _context.SaveChangesAsync();
                    });
                }
            }
        }

        private UIColors GetUIColors()
        {
            var uiColors = new UIColors()
            {
                Id = 1,
                BackGround = "#FF141E30",
                BackGroundButton = "#FF141E30",
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
