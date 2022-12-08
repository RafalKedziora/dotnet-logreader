using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class LFContext : DbContext
    {
        public LFContext(DbContextOptions options) : base(options) { }

        public DbSet<FtpCredentials> FtpCredentials { get; set; }
        public DbSet<UIColors> UIColors { get; set; }
    }
}
