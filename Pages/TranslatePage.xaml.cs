using System;
using System.Text.Json;
using Translate.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using TranslateBackend;
using Windows.UI.Xaml.Controls;
using Windows.Foundation.Collections;
using System.Threading.Tasks;
using System.Threading;

namespace Translate.Pages
{
    public sealed partial class TranslatePage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public EntryList history = new EntryList();
        public string jsonpath;
        public NameParser parser = new NameParser();
        public bool automatic;
        public Translator translator = new Translator();

        public TranslatePage()
        {
            this.InitializeComponent();
            UpdateSettings(null);
            jsonpath = ApplicationData.Current.LocalFolder.Path + "\\data.json";
            LoadDataAsync();
            foreach (string key in NameParser.languageDictionary.Keys)
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
            catch { }
        }

        private async void Translate()
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
            try
            {
                await (new ContentDialog() { Title = "Oops, an error occurred. Here are the details:", Content = exception.Message, PrimaryButtonText = "OK" }).ShowAsync();
            }
            catch { }
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
            catch { }
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
                // TRANSLATION CODE HERE!
                string fromcode = NameParser.GetCode(inputLanguage);
                string tocode = NameParser.GetCode(outputLanguage);
                TranslationQuery query = new TranslationQuery() { fromCode = fromcode, toCode = tocode, translateQuery = inputText };

                try
                {
                    return await translator.GetTranslation(query);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                    return null;
                }
            }

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;
            double availableHeight = e.NewSize.Height;

            if (availableWidth >= availableHeight)
            {
                mainGrid.ColumnDefinitions.Clear();
                mainGrid.RowDefinitions.Clear();
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            else
            {
                mainGrid.ColumnDefinitions.Clear();
                mainGrid.RowDefinitions.Clear();
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
        }

        DispatcherTimer translatetimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };

        private void inputtxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            translatetimer.Tick += Translatetimer_Tick;
            translatetimer.Stop();
            translatetimer.Start();
        }

        private void Translatetimer_Tick(object sender, object e)
        {
            if (outputlangtxtbox.SelectedItem != null && inputlangtxtbox.SelectedItem != null && inputtxtbox.Text != string.Empty) { Translate(); }
            translatetimer.Stop();
        }
    }
}
