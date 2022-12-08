using Domain.Models;
using RVS_AT.Models;
using Services.Interfaces;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Stores
{
    public class ContentStore
    {
        public IFtpCredentialsRepository _ftpCredentialsRepository;
        public IUIColorsRepository _uiColorsRepository;
        public List<FileModel> _files;

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
        }

        public UIColors GetUIColors() => _uiColorsRepository.GetById(1);
        public FtpCredentials GetFtpDataAccess() => _ftpCredentialsRepository.GetById(1);
    }
}
