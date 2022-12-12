using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class LFDbContextFactory
    {
        private readonly string _connectionString;

        public LFDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LFContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new LFContext(options);
        }
    }
}
