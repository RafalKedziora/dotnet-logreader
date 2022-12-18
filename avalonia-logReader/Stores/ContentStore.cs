using Domain.Models;
using AvaloniaLogReader.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace AvaloniaLogReader.Stores
{
    public class ContentStore
    {
        public IFtpCredentialsRepository _ftpCredentialsRepository;
        public IUIColorsRepository _uiColorsRepository;
        public List<FileModel> _files;
        public FileModel currentFile;

        public UIColors _uiColors;
        public FtpCredentials _ftpCredentials;

        public IEnumerable<FileModel> Files => _files;

        public ContentStore(IFtpCredentialsRepository ftpCredentialsRepository, IUIColorsRepository uiColorsRepository)
        {
            _ftpCredentialsRepository = ftpCredentialsRepository;
            _uiColorsRepository = uiColorsRepository;

            _uiColors = GetUIColors();
            _ftpCredentials = GetFtpDataAccess();

            _files = new List<FileModel>();
            currentFile = null;
        }

        public UIColors GetUIColors() => _uiColorsRepository.GetById(1);
        public FtpCredentials GetFtpDataAccess() => _ftpCredentialsRepository.GetById(1);
    }
}
