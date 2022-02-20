using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace RVS_AT
{
    public class LogFile //Probably need to move to another location later, need list of files in text to use prev, next btns
    {
        public string Title { get; set; }
    }

    public partial class PopupFiltrationText : Window
    {
        public PopupFiltrationText()
        {
            InitializeComponent();
            App.Current.Windows.OfType<MainWindow>().FirstOrDefault().uiColors.UpdatePopupColor();

			List<LogFile> items = new List<LogFile>();
			items.Add(new LogFile() { Title = "Test1"});
			items.Add(new LogFile() { Title = "Test2"});
			items.Add(new LogFile() { Title = "Test3"});
			lbTodoList.ItemsSource = items;
		}

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            UseFilter();
        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void UseFilter()
        {
            MainWindow temp = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (textToFind.Text != "")
            {
                var query = temp._textModule.logsBox.Text.Split("\n").Where(line => line.Contains(textToFind.Text));
                temp._textModule.logsBox.Text = string.Join("\n", query);
            }
            else
                temp._textModule.LoadFilesContent();

        }


		private void lbTodoList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (lbTodoList.SelectedItem != null)
				this.Title = (lbTodoList.SelectedItem as LogFile).Title;
		}

		private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
		{
			foreach (object o in lbTodoList.SelectedItems)
				MessageBox.Show((o as LogFile).Title);
		}

		private void btnSelectLast_Click(object sender, RoutedEventArgs e)
		{
			lbTodoList.SelectedIndex = lbTodoList.Items.Count - 1;
		}

        private void btnSelectLastThreeDays_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in lbTodoList.Items)
                lbTodoList.SelectedItems.Add(o);
        }

        private void btnSelectLastSevenDays_Click(object sender, RoutedEventArgs e)
		{
			foreach (object o in lbTodoList.Items)
				lbTodoList.SelectedItems.Add(o);
		}
	}
}
