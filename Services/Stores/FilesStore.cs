using Domain.Models;

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
