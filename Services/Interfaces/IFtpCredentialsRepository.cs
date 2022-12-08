using Domain.Models;

namespace Services.Interfaces
{
    public interface IFtpCredentialsRepository
    {
        FtpCredentials GetById(int id);
        void Update(FtpCredentials updateFtpCredentials);
    }
}
