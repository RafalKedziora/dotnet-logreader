using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RVS_AT.Moduls
{
    /// <summary>
    /// Interaction logic for Text.xaml
    /// </summary>
    public partial class Text : UserControl
    {
        private List<string> filesLines = new List<string>();
        public Text()
        {
            InitializeComponent();
            ProcessFilesAsync();
        }

        private async Task ProcessFilesAsync()
        {
            await Task.Run(() => loadFilesContentAsync());
            logsBox.Text += string.Join("\n", await filesToLoadNamesList());
            logsBox.Text += string.Join("\n", filesLines);
        }

        private async Task<List<string>> filesToLoadNamesList()
        {
            List<string> filesNames = new List<string>();
            DirectoryInfo directorySelected = new DirectoryInfo(Environment.CurrentDirectory + "/logs");

            if (directorySelected.Exists)
                if (directorySelected.GetFileSystemInfos().Length != 0)
                    foreach (FileInfo fileToLoad in directorySelected.GetFiles("*.log"))
                    {
                        await Task.Run(() => filesNames.Add(fileToLoad.FullName));
                    }

            return filesNames;
        }

        private async Task loadFilesContentAsync()
        {
            DirectoryInfo directorySelected = new DirectoryInfo(Environment.CurrentDirectory + "/logs");
            if (directorySelected.Exists)
                if (directorySelected.GetFileSystemInfos().Length != 0)
                    foreach (FileInfo fileToLoad in directorySelected.GetFiles("*.log"))
                    {
                        filesLines.Add(fileToLoad.FullName);
                        var fileContent = await Task.Run(() => File.ReadAllLinesAsync(fileToLoad.FullName));
                        await Task.Run(() => filesLines.AddRange(fileContent));
                    }
        }

    }
}
