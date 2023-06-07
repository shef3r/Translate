using System;
using System.Collections.Generic;
using System.Text.Json;
using Translate.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Translate.Pages
{
    public sealed partial class TranslatePage : Page
    {
        public EntryList history = new EntryList();
        public string jsonpath;

        public TranslatePage()
        {
            this.InitializeComponent();
            jsonpath = ApplicationData.Current.LocalFolder.Path + "\\data.json";
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("data.json");
                string data = await FileIO.ReadTextAsync(file);
                if (!string.IsNullOrEmpty(data))
                {
                    history = JsonSerializer.Deserialize<EntryList>(data);
                }
            }
            catch (Exception ex)
            {
                // Handle file access or deserialization errors
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            history.entries.Add(new HistoryEntry() { 
                inputText = inputtxtbox.Text,
                outputText = outputtxtbox.Text,
                input = inputlangtxtbox.Text,
                output = outputlangtxtbox.Text
            });

            try
            {
                string modifiedJsonData = JsonSerializer.Serialize(history);
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("data.json", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, modifiedJsonData);
            }
            catch (Exception ex)
            {
                // Handle file access or serialization errors
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
