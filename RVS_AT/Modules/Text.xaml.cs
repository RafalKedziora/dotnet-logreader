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

namespace RVS_AT.Modules
{
    public partial class Text : UserControl
    {
        public Text()
        {
            InitializeComponent();
            LoadFilesContent();
        }

        private void LoadFilesContent()
        {
            var files = ChooseFiles();
            foreach (var fileName in files)
            {
                FileInfo logFileInfo = new FileInfo(fileName); 
                LoadTextDocument(fileName);
            }
        }

        private List<string> ChooseFiles()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.log", SearchOption.AllDirectories).ToList();
            var selectedFiles = new List<string>();
            DateOperator dOperator = new DateOperator();
            DateTime[] lastSevenDays = dOperator.GetLastDays();
            foreach (var file in files)
            {
                int lastIndexOfSpecialChar = file.LastIndexOf("\\") + 1;
                DateTime convertedFileToDate = dOperator.DateParser(file.Remove(0, count: lastIndexOfSpecialChar));
                if (lastSevenDays.Contains(convertedFileToDate))
                {
                    selectedFiles.Add(file);
                }

            }
            return selectedFiles;
        }

        private void LoadTextDocument(string fileName)
        {
            logsBox.AppendText(fileName + "\n");
            using StreamReader reader = File.OpenText(fileName);
            logsBox.AppendText(reader.ReadToEnd());
        }
    }
}
