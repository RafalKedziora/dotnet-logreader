using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
