using System;
using System.Text.Json;
using Translate.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using TranslateBackend;
using Windows.UI.Xaml.Controls;
using Windows.Globalization;
using System.Net;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using System.Linq;

namespace Translate.Pages
{
    public sealed partial class TranslatePage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public EntryList history = new EntryList();
        public string jsonpath;
        public NameParser parser = new NameParser();

        public TranslatePage()
        {
            this.InitializeComponent();
            UpdateSettings(null);
            jsonpath = ApplicationData.Current.LocalFolder.Path + "\\data.json";
            LoadDataAsync();
            foreach (string key in parser.languageDictionary.Keys)
            {
                inputlangtxtbox.Items.Add(key);
                outputlangtxtbox.Items.Add(key);
            }
        }

        private void UpdateSettings(string setting)
        {
            if (setting == null)
            {
                UpdateSettings("compactmode");
                UpdateSettings("fontSize");
            }
            else if (settings != null && settings.ContainsKey(setting) && (settings[setting]?.ToString() == "True" || settings[setting]?.ToString() == "False"))
            {
                if (setting == "compactmode")
                {
                    bool value = StringToBool(settings[setting].ToString());
                    // Debug.WriteLine(setting);
                    int height;
                    if (value)
                    {
                        height = 32;
                    }
                    else
                    {
                        height = 48;
                    }
                    // Debug.Write(height);
                    // handle compact mode here.
                }
                
            }
            else if (setting == "fontSize")
            {
                if (settings["fontSize"] != null)
                {
                    System.Diagnostics.Debug.WriteLine($"setting to: {settings["fontSize"]}");
                    inputtxtbox.FontSize = Convert.ToDouble(settings["fontSize"]);
                    outputtxtbox.FontSize = Convert.ToDouble(settings["fontSize"]);
                }
                else
                {
                    inputtxtbox.FontSize = 16;
                    outputtxtbox.FontSize = 16;
                }
            }
            
            System.Diagnostics.Debug.WriteLine($"! ! ! checking that h0e");
            if (settings["fontFamily"] != null)
            {
                System.Diagnostics.Debug.WriteLine($"! ! ! setting to: {settings["fontFamily"]}");
                inputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily($"{settings["fontFamily"]}");
                outputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily($"{settings["fontFamily"]}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"setting to default, wh0re");
                inputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe UI");
                outputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe UI");
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
                // System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            history.entries.Add(new HistoryEntry() { 
                inputText = inputtxtbox.Text,
                outputText = outputtxtbox.Text,
                input = inputlangtxtbox.SelectedItem.ToString(),
                output = outputlangtxtbox.SelectedItem.ToString()
            });

            try
            {
                string modifiedJsonData = JsonSerializer.Serialize(history);
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("data.json", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, modifiedJsonData);
            }
            catch (Exception ex)
            {
                // System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;
            double availableHeight = e.NewSize.Height;

            // Adjust the orientation of the mainpanel based on the available width and height
            if (availableWidth >= availableHeight)
            {
                mainpanel.Orientation = Orientation.Horizontal;
            }
            else
            {
                mainpanel.Orientation = Orientation.Vertical;
            }

            // Calculate the width and height of the textboxes grid based on the mainpanel's orientation
            if (mainpanel.Orientation == Orientation.Horizontal)
            {
                double textBoxesWidth = availableWidth - 300;
                txtboxes.Width = textBoxesWidth;
                txtboxes.Height = availableHeight;
                listcont.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                double textBoxesHeight = availableHeight - 200;
                txtboxes.Width = availableWidth;
                txtboxes.Height = textBoxesHeight;
                listcont.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }
    }
}
