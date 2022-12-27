using Domain.Models;
using Services.Interfaces;

namespace Services.Stores
{
    public class ContentStore
    {
        public IFtpCredentialsRepository _ftpCredentialsRepository;
        public IUIColorsRepository _uiColorsRepository;

        public UIColors _uiColors;
        public FtpCredentials _ftpCredentials;

        public ContentStore(IFtpCredentialsRepository ftpCredentialsRepository, IUIColorsRepository uiColorsRepository)
        {
            _ftpCredentialsRepository = ftpCredentialsRepository;
            _uiColorsRepository = uiColorsRepository;

            _uiColors = GetUIColors();
            _ftpCredentials = GetFtpDataAccess();
        }

        public UIColors GetUIColors() => _uiColorsRepository.GetById(1);
        public FtpCredentials GetFtpDataAccess() => _ftpCredentialsRepository.GetById(1);
    }
}
