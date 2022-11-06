using Data;
using RVS_AT.Models;
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
        private readonly FtpCredentialsRepository _ftpCredentialsRepository;
        private readonly UIColorsRepository _uiColorsRepository;
        private readonly List<FileModel> _files;
        private Lazy<Task> _initializeLazy;

        private UIColors _uiColors;
        private FtpCredentials _ftpCredentials;

        public IEnumerable<FileModel> Files => _files;

        public ContentStore(FtpCredentialsRepository ftpCredentialsRepository, UIColorsRepository uiColorsRepository)
        {
            _ftpCredentialsRepository = ftpCredentialsRepository;
            _uiColorsRepository = uiColorsRepository;

            _initializeLazy = new Lazy<Task>(Initialize);

            _files = new List<FileModel>();
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }

        private async Task Initialize()
        {
            _ftpCredentials = await _ftpCredentialsRepository.GetByIdAsync();
            _uiColors = await _uiColorsRepository.GetByIdAsync();
        }
    }
}
