using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Services.Data
{
    public class LFDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LFContext>
    {
        public LFContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=settings.db").Options;

            return new LFContext(options);
        }
    }
}
