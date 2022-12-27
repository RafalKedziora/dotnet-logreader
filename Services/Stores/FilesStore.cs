using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stores
{
    public class FilesStore
    {
        public List<FileModel> _files;
        public IEnumerable<FileModel> Files => _files;
        public FileModel currentFile;
        

        public FilesStore()
        {
            _files = new List<FileModel>();
            currentFile = null;
        }
    }
}
