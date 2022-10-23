using Data;
using Services.Data;
using Services.Interfaces;

namespace Services.Repositories
{
    public class FtpCredentialsRepository : IFtpCredentialsRepository
    {
        private readonly LFContext _context;
        public FtpCredentialsRepository(LFContext context)
        {
            _context = context;
        }
        public async Task<FtpCredentials> GetByIdAsync(int id = 1)
        {
            return await _context.FtpCredentials.FindAsync(id);
        }
        public async Task UpdateAsync(FtpCredentials updateFtpCredentials)
        {
            _context.FtpCredentials.Update(updateFtpCredentials);
            await _context.SaveChangesAsync();
        }
    }
}
