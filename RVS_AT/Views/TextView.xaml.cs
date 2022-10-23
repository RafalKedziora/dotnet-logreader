using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RVS_AT.Views
{
    public partial class Text : UserControl
    {
        public Text()
        {
            InitializeComponent();
        }

        public async Task LoadFilesContent()
        {
            var files = await ChooseFiles();
            foreach (var fileName in files)
            {
                FileInfo logFileInfo = new FileInfo(fileName); 
                LoadTextDocument(fileName);
            }
        }

        public string LogsboxContent()
        {
            return logsBox.Text;
        }

        private async Task<List<string>> ChooseFiles()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.log", SearchOption.AllDirectories).ToList();
            var selectedFiles = new List<string>();
            DateOperator dOperator = new DateOperator();
            DateTime[] lastSevenDays = await dOperator.GetLastDays();
            foreach (var file in files)
            {
                int lastIndexOfSpecialChar = file.LastIndexOf("\\") + 1;
                DateTime convertedFileToDate = await dOperator.DateParser(file.Remove(0, count: lastIndexOfSpecialChar));
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
            //new Thread(async () =>
            //{
            //    using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //    {
            //        this.Dispatcher.Invoke(() => { logsBox.Text += fileName + "\n"; });
            //        using (BufferedStream bs = new BufferedStream(fs))
            //        {
            //            using (StreamReader sr = new StreamReader(bs))
            //            {
            //                string line;
            //                while ((line = await sr.ReadLineAsync()) != null)
            //                {
            //                    this.Dispatcher.Invoke(() =>
            //                    {
            //                        logsBox.Text += line + "\n";
            //                    });

            //                    Thread.Sleep(100);
            //                }
            //            }
            //        }
            //    }
            //}).Start();
        }
    }
}
