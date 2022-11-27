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
        public FtpCredentials GetById(int id = 1)
        {
            return _context.FtpCredentials.FirstOrDefault(elem => elem.Id == id);
        }
        public void Update(FtpCredentials updateFtpCredentials)
        {
            _context.FtpCredentials.Update(updateFtpCredentials);
            _context.SaveChanges();
        }
    }
}
