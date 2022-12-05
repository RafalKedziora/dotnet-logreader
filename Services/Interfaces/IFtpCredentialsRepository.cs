using Data;

namespace Services.Interfaces
{
    public interface IFtpCredentialsRepository
    {
        FtpCredentials GetById(int id);
        void Update(FtpCredentials updateFtpCredentials);
    }
}
