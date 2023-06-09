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
using System.Threading.Tasks;

namespace Translate.Pages
{
    public sealed partial class TranslatePage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public EntryList history = new EntryList();
        public string jsonpath;
        public NameParser parser = new NameParser();
        public bool automatic;

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
                UpdateSettings("autotranslate");
                UpdateSettings("fontSize");
            }
            else if (settings != null && settings.ContainsKey(setting) && (settings[setting]?.ToString() == "True" || settings[setting]?.ToString() == "False"))
            {
                if (setting == "compactmode")
                {
                    bool value = StringToBool(settings[setting].ToString());
                    int height;
                    if (value)
                    {
                        height = 32;
                    }
                    else
                    {
                        height = 48;
                    }
                    // handle compact mode here.
                }
                if (setting == "autotranslate")
                {
                    bool value = StringToBool(settings[setting].ToString());
                    if (value)
                    {
                        TranslateButton.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        TranslateButton.Visibility = Visibility.Visible;
                    }
                    automatic = value;
                }

            }
            else if (setting == "fontSize")
            {
                if (settings["fontSize"] != null)
                {
                    inputtxtbox.FontSize = Convert.ToDouble(settings["fontSize"]);
                    outputtxtbox.FontSize = Convert.ToDouble(settings["fontSize"]);
                }
                else
                {
                    inputtxtbox.FontSize = 16;
                    outputtxtbox.FontSize = 16;
                }
            }
            
            if (settings["fontFamily"] != null)
            {
                inputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily($"{settings["fontFamily"]}");
                outputtxtbox.FontFamily = new Windows.UI.Xaml.Media.FontFamily($"{settings["fontFamily"]}");
            }
            else
            {
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
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (inputlangtxtbox.SelectedItem == null || outputlangtxtbox.SelectedItem == null)
            {
                try
                {
                    string translation = await TranslateText(inputtxtbox.Text, null, null);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                try
                {
                    string translation = await TranslateText(inputtxtbox.Text, inputlangtxtbox.SelectedItem.ToString(), outputlangtxtbox.SelectedItem.ToString());
                    outputtxtbox.Text = translation;
                    WriteToHistory(inputtxtbox.Text, translation, inputlangtxtbox.SelectedItem.ToString(), outputlangtxtbox.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }


        private async void ShowError(Exception exception)
        {
            await (new ContentDialog() { Title = "Oops, an error occured. Here are the the details:", Content = exception.Message, PrimaryButtonText= "OK" }).ShowAsync();
        }

        private async void WriteToHistory(string input, string output, string inputLang, string outputLang)
        {
            history.entries.Add(new HistoryEntry()
            {
                inputText = input,
                outputText = output,
                input = inputLang,
                output = outputLang
            });



            try
            {
                string modifiedJsonData = JsonSerializer.Serialize(history);
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("data.json", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, modifiedJsonData);
            }
            catch (Exception ex)
            {
            }
        }

        private async Task<string> TranslateText(string inputText, string inputLanguage, string outputLanguage)
        {
            await Task.Delay(1000);

            if (inputText == null || inputLanguage == null || outputLanguage == null)
            {
                throw new Exception("One of the values is null. Check if you selected a language in both language fields and if the input textbox has text.");
            }
            else
            {
                return "[TRANSLATION]";
            }
            
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;
            double availableHeight = e.NewSize.Height;

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
