using Data;

namespace Services.Interfaces
{
    public interface IFtpCredentialsRepository
    {
        Task<FtpCredentials> GetByIdAsync(int id);
        Task UpdateAsync(FtpCredentials updateFtpCredentials);
    }
}
