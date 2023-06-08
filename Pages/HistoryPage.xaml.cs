using System.IO;
using System.Text.Json;
using Translate.Models;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Translate.Pages
{
    public sealed partial class HistoryPage : Page
    {
        public EntryList entries = new EntryList();
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;

        public HistoryPage()
        {
            this.InitializeComponent();
            string jsonpath = ApplicationData.Current.LocalFolder.Path + "\\data.json";
            if (File.Exists(jsonpath))
            {
                if (!string.IsNullOrEmpty((File.ReadAllText(jsonpath))))
                {
                    string data = File.ReadAllText(jsonpath);
                    entries = JsonSerializer.Deserialize<EntryList>(data);
                }
            }

            if (entries.entries.Count == 0)
            {
                NoItemsTextBlock.Visibility = Visibility.Visible;
                TestList.Visibility = Visibility.Collapsed;
            }
            else
            {
                NoItemsTextBlock.Visibility = Visibility.Collapsed;
                TestList.Visibility = Visibility.Visible;
                TestList.ItemsSource = entries.entries;
            }
        }

        private bool StringToBool(string v)
        {
            if (v == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
