using System;
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using System.Diagnostics;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Hosting;
using Windows.Management.Deployment;
using Windows.UI.Xaml.Media;
using SoftwareKobo.Net;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Text;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Translate
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Popup : Page
    {
        public Popup()
        {
            this.InitializeComponent();
            if (historyitems.Items.Count == 0) { nohistory.Visibility = Visibility.Visible; }
            Window.Current.SetTitleBar(AppTitleBar);
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            Object value = localSettings.Values["FirstLaunchFinished"];

            if (value == null)
            {
                WelcomeDialog();
            }
            if (localSettings != null)
            {
                if (localSettings.Values["history"] != null)
                {
                    if (localSettings.Values["history"].ToString() == "False")
                    {
                        histbutton.Visibility = Visibility.Collapsed;
                        hisshow.IsOn = false;
                    }
                    else
                    {
                        histbutton.Visibility = Visibility.Visible;
                        hisshow.IsOn = true;
                    }
                }
                if (localSettings.Values["compact"] != null)
                {
                    Debug.WriteLine(ApplicationData.Current.LocalSettings.Values["compact"].ToString());
                    if (ApplicationData.Current.LocalSettings.Values["compact"].ToString() == "True")
                    {
                        compact.IsOn = true;
                        big.Padding = new Thickness(8, 8, 8, 8);
                        mainflyout.Padding = new Thickness(3, 3, 3, 3);
                        big.Margin = new Thickness(5, 0, 5, 5);
                        settingstext.Padding = new Thickness(10, 10, 5, 8);
                        settingitem0.Padding = new Thickness(5, 3, 5, 3);
                        settingitem1.Padding = new Thickness(5, 3, 5, 3);
                        settingitem2.Padding = new Thickness(5, 3, 5, 3);
                        settingitem5.Padding = new Thickness(5, 3, 5, 3);
                        mainflyout.Padding = new Thickness(0, 0, 0, 0);
                        apply.Margin = new Thickness(165, 0, 0, 0);
                        bighistory.Padding = new Thickness(8, 8, 8, 8);
                        mainflyouthistory.Padding = new Thickness(3, 3, 3, 3);
                        bighistory.Margin = new Thickness(5, 0, 5, 5);
                        historytext.Padding = new Thickness(10, 10, 5, 8);
                        mainflyouthistory.Padding = new Thickness(0, 0, 0, 0);
                        apply.Margin = new Thickness(165, 0, 0, 0);
                    }
                    else
                    {
                        compact.IsOn = false;
                        big.Margin = new Thickness(5, 0, 5, 5);
                        big.Padding = new Thickness(15, 15, 15, 15);
                        settingitem0.Padding = new Thickness(5, 5, 5, 5);
                        settingitem1.Padding = new Thickness(5, 5, 5, 5);
                        settingitem2.Padding = new Thickness(5, 5, 5, 5);
                        settingitem5.Padding = new Thickness(5, 5, 5, 5);
                        mainflyout.Padding = new Thickness(5, 5, 5, 5);
                        settingstext.Padding = new Thickness(10, 10, 20, 15);
                        apply.Margin = new Thickness(144, 0, 0, 0);
                        bighistory.Padding = new Thickness(15, 15, 15, 15);
                        mainflyouthistory.Padding = new Thickness(5, 5, 5, 5);
                        bighistory.Margin = new Thickness(5, 0, 5, 5);
                        historytext.Padding = new Thickness(10, 10, 20, 15);
                        mainflyouthistory.Padding = new Thickness(5, 5, 5, 5);
                    }
                }
                if (localSettings.Values["theme"] != null)
                {

                    if (localSettings.Values["theme"].ToString() == "1")
                    {
                        lightmode.IsChecked = true;
                        darkmode.IsChecked = false;
                        page.RequestedTheme = ElementTheme.Light;
                        AppTitleBar.RequestedTheme = ElementTheme.Light;
                        FrameworkElement root = (FrameworkElement)Window.Current.Content;
                        root.RequestedTheme = ElementTheme.Light;
                    }
                    if (localSettings.Values["theme"].ToString() == "2")
                    {
                        lightmode.IsChecked = false;
                        darkmode.IsChecked = true;
                        page.RequestedTheme = ElementTheme.Dark;
                        AppTitleBar.RequestedTheme = ElementTheme.Dark;
                        FrameworkElement root = (FrameworkElement)Window.Current.Content;
                        root.RequestedTheme = ElementTheme.Dark;
                    }
                    if (localSettings.Values["theme"].ToString() == "3")
                    {
                        return;
                    }



                }
            }
            from.Items.Add("Afrikaans");
            from.Items.Add("Albanian");
            from.Items.Add("Amharic");
            from.Items.Add("Arabic");
            from.Items.Add("Armenian");
            from.Items.Add("Azerbaijani");
            from.Items.Add("Basque");
            from.Items.Add("Belarusian");
            from.Items.Add("Bengali");
            from.Items.Add("Bosnian");
            from.Items.Add("Bulgarian");
            from.Items.Add("Catalan");
            from.Items.Add("Cebuano");
            from.Items.Add("Chinese (Simplified)");
            from.Items.Add("Chinese (Traditional)");
            from.Items.Add("Corsican");
            from.Items.Add("Croatian");
            from.Items.Add("Czech");
            from.Items.Add("Danish");
            from.Items.Add("Dutch");
            from.Items.Add("English");
            from.Items.Add("Esperanto");
            from.Items.Add("Estonian");
            from.Items.Add("Finnish");
            from.Items.Add("French");
            from.Items.Add("Frisian");
            from.Items.Add("Galician");
            from.Items.Add("Georgian");
            from.Items.Add("German");
            from.Items.Add("Greek");
            from.Items.Add("Gujarati");
            from.Items.Add("Haitian Creole");
            from.Items.Add("Hausa");
            from.Items.Add("Hawaiian");
            from.Items.Add("Hebrew");
            from.Items.Add("Hindi");
            from.Items.Add("Hmong");
            from.Items.Add("Hungarian");
            from.Items.Add("Icelandic");
            from.Items.Add("Igbo");
            from.Items.Add("Indonesian");
            from.Items.Add("Irish");
            from.Items.Add("Italian");
            from.Items.Add("Japanese");
            from.Items.Add("Javanese");
            from.Items.Add("Kannada");
            from.Items.Add("Kazakh");
            from.Items.Add("Khmer");
            from.Items.Add("Kinyarwanda");
            from.Items.Add("Korean");
            from.Items.Add("Kurdish");
            from.Items.Add("Kyrgyz");
            from.Items.Add("Lao");
            from.Items.Add("Latvian");
            from.Items.Add("Lithuanian");
            from.Items.Add("Luxembourgish");
            from.Items.Add("Macedonian");
            from.Items.Add("Malagasy");
            from.Items.Add("Malay");
            from.Items.Add("Malayalam");
            from.Items.Add("Maltese");
            from.Items.Add("Maori");
            from.Items.Add("Marathi");
            from.Items.Add("Mongolian");
            from.Items.Add("Myanmar (Burmese)");
            from.Items.Add("Nepali");
            from.Items.Add("Norwegian");
            from.Items.Add("Nyanja (Chichewa)");
            from.Items.Add("Odia (Oriya)");
            from.Items.Add("Pashto");
            from.Items.Add("Persian");
            from.Items.Add("Polish");
            from.Items.Add("Portuguese (Portugal, Brazil)");
            from.Items.Add("Punjabi");
            from.Items.Add("Romanian");
            from.Items.Add("Russian");
            from.Items.Add("Samoan");
            from.Items.Add("Scots Gaelic");
            from.Items.Add("Serbian");
            from.Items.Add("Sesotho");
            from.Items.Add("Shona");
            from.Items.Add("Sindhi");
            from.Items.Add("Sinhala (Sinhalese)");
            from.Items.Add("Slovak");
            from.Items.Add("Slovenian");
            from.Items.Add("Somali");
            from.Items.Add("Spanish");
            from.Items.Add("Sundanese");
            from.Items.Add("Swahili");
            from.Items.Add("Swedish");
            from.Items.Add("Tagalog (Filipino)");
            from.Items.Add("Tajik");
            from.Items.Add("Tamil");
            from.Items.Add("Tatar");
            from.Items.Add("Telugu");
            from.Items.Add("Thai");
            from.Items.Add("Turkish");
            from.Items.Add("Turkmen");
            from.Items.Add("Ukrainian");
            from.Items.Add("Urdu");
            from.Items.Add("Uyghur");
            from.Items.Add("Uzbek");
            from.Items.Add("Vietnamese");
            from.Items.Add("Welsh");
            from.Items.Add("Xhosa");
            from.Items.Add("Yiddish");
            from.Items.Add("Yoruba");
            from.Items.Add("Zulu");
            to.Items.Add("Afrikaans");
            to.Items.Add("Albanian");
            to.Items.Add("Amharic");
            to.Items.Add("Arabic");
            to.Items.Add("Armenian");
            to.Items.Add("Azerbaijani");
            to.Items.Add("Basque");
            to.Items.Add("Belarusian");
            to.Items.Add("Bengali");
            to.Items.Add("Bosnian");
            to.Items.Add("Bulgarian");
            to.Items.Add("Catalan");
            to.Items.Add("Cebuano");
            to.Items.Add("Chinese (Simplified)");
            to.Items.Add("Chinese (Traditional)");
            to.Items.Add("Corsican");
            to.Items.Add("Croatian");
            to.Items.Add("Czech");
            to.Items.Add("Danish");
            to.Items.Add("Dutch");
            to.Items.Add("English");
            to.Items.Add("Esperanto");
            to.Items.Add("Estonian");
            to.Items.Add("Finnish");
            to.Items.Add("French");
            to.Items.Add("Frisian");
            to.Items.Add("Galician");
            to.Items.Add("Georgian");
            to.Items.Add("German");
            to.Items.Add("Greek");
            to.Items.Add("Gujarati");
            to.Items.Add("Haitian Creole");
            to.Items.Add("Hausa");
            to.Items.Add("Hawaiian");
            to.Items.Add("Hebrew");
            to.Items.Add("Hindi");
            to.Items.Add("Hmong");
            to.Items.Add("Hungarian");
            to.Items.Add("Icelandic");
            to.Items.Add("Igbo");
            to.Items.Add("Indonesian");
            to.Items.Add("Irish");
            to.Items.Add("Italian");
            to.Items.Add("Japanese");
            to.Items.Add("Javanese");
            to.Items.Add("Kannada");
            to.Items.Add("Kazakh");
            to.Items.Add("Khmer");
            to.Items.Add("Kinyarwanda");
            to.Items.Add("Korean");
            to.Items.Add("Kurdish");
            to.Items.Add("Kyrgyz");
            to.Items.Add("Lao");
            to.Items.Add("Latvian");
            to.Items.Add("Lithuanian");
            to.Items.Add("Luxembourgish");
            to.Items.Add("Macedonian");
            to.Items.Add("Malagasy");
            to.Items.Add("Malay");
            to.Items.Add("Malayalam");
            to.Items.Add("Maltese");
            to.Items.Add("Maori");
            to.Items.Add("Marathi");
            to.Items.Add("Mongolian");
            to.Items.Add("Myanmar (Burmese)");
            to.Items.Add("Nepali");
            to.Items.Add("Norwegian");
            to.Items.Add("Nyanja (Chichewa)");
            to.Items.Add("Odia (Oriya)");
            to.Items.Add("Pashto");
            to.Items.Add("Persian");
            to.Items.Add("Polish");
            to.Items.Add("Portuguese (Portugal, Brazil)");
            to.Items.Add("Punjabi");
            to.Items.Add("Romanian");
            to.Items.Add("Russian");
            to.Items.Add("Samoan");
            to.Items.Add("Scots Gaelic");
            to.Items.Add("Serbian");
            to.Items.Add("Sesotho");
            to.Items.Add("Shona");
            to.Items.Add("Sindhi");
            to.Items.Add("Sinhala (Sinhalese)");
            to.Items.Add("Slovak");
            to.Items.Add("Slovenian");
            to.Items.Add("Somali");
            to.Items.Add("Spanish");
            to.Items.Add("Sundanese");
            to.Items.Add("Swahili");
            to.Items.Add("Swedish");
            to.Items.Add("Tagalog (Filipino)");
            to.Items.Add("Tajik");
            to.Items.Add("Tamil");
            to.Items.Add("Tatar");
            to.Items.Add("Telugu");
            to.Items.Add("Thai");
            to.Items.Add("Turkish");
            to.Items.Add("Turkmen");
            to.Items.Add("Ukrainian");
            to.Items.Add("Urdu");
            to.Items.Add("Uyghur");
            to.Items.Add("Uzbek");
            to.Items.Add("Vietnamese");
            to.Items.Add("Welsh");
            to.Items.Add("Xhosa");
            to.Items.Add("Yiddish");
            to.Items.Add("Yoruba");
            to.Items.Add("Zulu");
            Translate.IsEnabled = false;
            switchlang.IsEnabled = false;
        }

        private async void WelcomeDialog()
        {
            try
            {
                ContentDialog dialog = new ContentDialog() { PrimaryButtonText = "Let's get started!" };
                StackPanel desc = new StackPanel();
                desc.HorizontalAlignment = HorizontalAlignment.Center;
                desc.Children.Add(new Image() { Source = new BitmapImage() { UriSource = new Uri("ms-appx:///logowtext.png") }, Width = 300, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center });
                desc.Children.Add(new TextBlock() { Text = "Welcome to Translate!", FontSize = 30, FontWeight = FontWeights.Bold, FontFamily = new FontFamily("Segoe UI Variable"), HorizontalAlignment = HorizontalAlignment.Center });
                desc.Children.Add(new TextBlock() { Text = "the Google Translate client for Windows 10 and 11", FontSize = 20, FontFamily = new FontFamily("Segoe UI"), HorizontalAlignment = HorizontalAlignment.Center });
                dialog.Content = desc;
                dialog.PrimaryButtonClick += Dialog_PrimaryButtonClick;
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                showerror(ex.ToString());
            }
        }

        private void Dialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["FirstLaunchFinished"] = true;
        }

        private async void Translate_Click(object sender, RoutedEventArgs e)
        {
            if (from.SelectedItem != null)
            {
                if (to.SelectedItem != null)
                {
                    if (!from.SelectedItem.Equals(to.SelectedItem))
                    {
                        if (input.Text != null)
                        {
                            if (output.Text != null)
                            {
                                var client = new HttpClient();
                                try
                                {
                                    var result = await client.GetAsync(new Uri("https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + fromchosen.Text + "&tl=" + tochosen.Text + "&dt=t&q=" + input.Text));
                                    string[] json = result.Content.ToString().Split('"');
                                    output.Text = json[1];
                                    historyitems.Items.Add(from.SelectedItem.ToString() + " → " + to.SelectedItem.ToString() + "\n" + input.Text + " → " + output.Text + "\n");
                                    if (historyitems.Items.Count > 0) { nohistory.Visibility = Visibility.Collapsed; }
                                    if (output.Text == "initial-scale=1, minimum-scale=1, width=device-width")
                                    {
                                        try { showerror("There was something wrong with your request. Please try again."); } catch { };
                                    }
                                }
                                catch (Exception ex)
                                {
                                    showerror(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void showerror(string error)
        {
            ContentDialog dialogerror = new ContentDialog();
            dialogerror.Title = "Oops, an error occured!";
            dialogerror.PrimaryButtonText = "OK";
            dialogerror.Content = error;
            await dialogerror.ShowAsync();
        }

        private void to_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            check();
            if (to.SelectedItem.ToString() == "Afrikaans") { tochosen.Text = "af"; }
            if (to.SelectedItem.ToString() == "Albanian") { tochosen.Text = "sq"; }
            if (to.SelectedItem.ToString() == "Amharic") { tochosen.Text = "am"; }
            if (to.SelectedItem.ToString() == "Arabic") { tochosen.Text = "ar"; }
            if (to.SelectedItem.ToString() == "Armenian") { tochosen.Text = "hy"; }
            if (to.SelectedItem.ToString() == "Azerbaijani") { tochosen.Text = "az"; }
            if (to.SelectedItem.ToString() == "Basque") { tochosen.Text = "eu"; }
            if (to.SelectedItem.ToString() == "Belarusian") { tochosen.Text = "be"; }
            if (to.SelectedItem.ToString() == "Bengali") { tochosen.Text = "bn"; }
            if (to.SelectedItem.ToString() == "Bosnian") { tochosen.Text = "bs"; }
            if (to.SelectedItem.ToString() == "Bulgarian") { tochosen.Text = "bg"; }
            if (to.SelectedItem.ToString() == "Catalan") { tochosen.Text = "ca"; }
            if (to.SelectedItem.ToString() == "Cebuano") { tochosen.Text = "ceb"; }
            if (to.SelectedItem.ToString() == "Chinese (Simplified)") { tochosen.Text = "zh"; }
            if (to.SelectedItem.ToString() == "Chinese (Traditional)") { tochosen.Text = "zh-TW"; }
            if (to.SelectedItem.ToString() == "Corsican") { tochosen.Text = "co"; }
            if (to.SelectedItem.ToString() == "Croatian") { tochosen.Text = "hr"; }
            if (to.SelectedItem.ToString() == "Czech") { tochosen.Text = "cs"; }
            if (to.SelectedItem.ToString() == "Danish") { tochosen.Text = "da"; }
            if (to.SelectedItem.ToString() == "Dutch") { tochosen.Text = "nl"; }
            if (to.SelectedItem.ToString() == "English") { tochosen.Text = "en"; }
            if (to.SelectedItem.ToString() == "Esperanto") { tochosen.Text = "eo"; }
            if (to.SelectedItem.ToString() == "Estonian") { tochosen.Text = "et"; }
            if (to.SelectedItem.ToString() == "Finnish") { tochosen.Text = "fi"; }
            if (to.SelectedItem.ToString() == "French") { tochosen.Text = "fr"; }
            if (to.SelectedItem.ToString() == "Frisian") { tochosen.Text = "fy"; }
            if (to.SelectedItem.ToString() == "Galician") { tochosen.Text = "gl"; }
            if (to.SelectedItem.ToString() == "Georgian") { tochosen.Text = "ka"; }
            if (to.SelectedItem.ToString() == "German") { tochosen.Text = "de"; }
            if (to.SelectedItem.ToString() == "Greek") { tochosen.Text = "el"; }
            if (to.SelectedItem.ToString() == "Gujarati") { tochosen.Text = "gu"; }
            if (to.SelectedItem.ToString() == "Haitian Creole") { tochosen.Text = "ht"; }
            if (to.SelectedItem.ToString() == "Hausa") { tochosen.Text = "ha"; }
            if (to.SelectedItem.ToString() == "Hawaiian") { tochosen.Text = "haw"; }
            if (to.SelectedItem.ToString() == "Hebrew") { tochosen.Text = "he"; }
            if (to.SelectedItem.ToString() == "Hindi") { tochosen.Text = "hi"; }
            if (to.SelectedItem.ToString() == "Hmong") { tochosen.Text = "hmn"; }
            if (to.SelectedItem.ToString() == "Hungarian") { tochosen.Text = "hu"; }
            if (to.SelectedItem.ToString() == "Icelandic") { tochosen.Text = "is"; }
            if (to.SelectedItem.ToString() == "Igbo") { tochosen.Text = "ig"; }
            if (to.SelectedItem.ToString() == "Indonesian") { tochosen.Text = "id"; }
            if (to.SelectedItem.ToString() == "Irish") { tochosen.Text = "ga"; }
            if (to.SelectedItem.ToString() == "Italian") { tochosen.Text = "it"; }
            if (to.SelectedItem.ToString() == "Japanese") { tochosen.Text = "ja"; }
            if (to.SelectedItem.ToString() == "Javanese") { tochosen.Text = "jv"; }
            if (to.SelectedItem.ToString() == "Kannada") { tochosen.Text = "kn"; }
            if (to.SelectedItem.ToString() == "Kazakh") { tochosen.Text = "kk"; }
            if (to.SelectedItem.ToString() == "Khmer") { tochosen.Text = "km"; }
            if (to.SelectedItem.ToString() == "Kinyarwanda") { tochosen.Text = "rw"; }
            if (to.SelectedItem.ToString() == "Korean") { tochosen.Text = "ko"; }
            if (to.SelectedItem.ToString() == "Kurdish") { tochosen.Text = "ku"; }
            if (to.SelectedItem.ToString() == "Kyrgyz") { tochosen.Text = "ky"; }
            if (to.SelectedItem.ToString() == "Lao") { tochosen.Text = "lo"; }
            if (to.SelectedItem.ToString() == "Latvian") { tochosen.Text = "lv"; }
            if (to.SelectedItem.ToString() == "Lithuanian") { tochosen.Text = "lt"; }
            if (to.SelectedItem.ToString() == "Luxembourgish") { tochosen.Text = "lb"; }
            if (to.SelectedItem.ToString() == "Macedonian") { tochosen.Text = "mk"; }
            if (to.SelectedItem.ToString() == "Malagasy") { tochosen.Text = "mg"; }
            if (to.SelectedItem.ToString() == "Malay") { tochosen.Text = "ms"; }
            if (to.SelectedItem.ToString() == "Malayalam") { tochosen.Text = "ml"; }
            if (to.SelectedItem.ToString() == "Maltese") { tochosen.Text = "mt"; }
            if (to.SelectedItem.ToString() == "Maori") { tochosen.Text = "mi"; }
            if (to.SelectedItem.ToString() == "Marathi") { tochosen.Text = "mr"; }
            if (to.SelectedItem.ToString() == "Mongolian") { tochosen.Text = "mn"; }
            if (to.SelectedItem.ToString() == "Myanmar (Burmese)") { tochosen.Text = "my"; }
            if (to.SelectedItem.ToString() == "Nepali") { tochosen.Text = "ne"; }
            if (to.SelectedItem.ToString() == "Norwegian") { tochosen.Text = "no"; }
            if (to.SelectedItem.ToString() == "Nyanja (Chichewa)") { tochosen.Text = "ny"; }
            if (to.SelectedItem.ToString() == "Odia (Oriya)") { tochosen.Text = "or"; }
            if (to.SelectedItem.ToString() == "Pashto") { tochosen.Text = "ps"; }
            if (to.SelectedItem.ToString() == "Persian") { tochosen.Text = "fa"; }
            if (to.SelectedItem.ToString() == "Polish") { tochosen.Text = "pl"; }
            if (to.SelectedItem.ToString() == "Portuguese (Portugal, Brazil)") { tochosen.Text = "pt"; }
            if (to.SelectedItem.ToString() == "Punjabi") { tochosen.Text = "pa"; }
            if (to.SelectedItem.ToString() == "Romanian") { tochosen.Text = "ro"; }
            if (to.SelectedItem.ToString() == "Russian") { tochosen.Text = "ru"; }
            if (to.SelectedItem.ToString() == "Samoan") { tochosen.Text = "sm"; }
            if (to.SelectedItem.ToString() == "Scots Gaelic") { tochosen.Text = "gd"; }
            if (to.SelectedItem.ToString() == "Serbian") { tochosen.Text = "sr"; }
            if (to.SelectedItem.ToString() == "Sesotho") { tochosen.Text = "st"; }
            if (to.SelectedItem.ToString() == "Shona") { tochosen.Text = "sn"; }
            if (to.SelectedItem.ToString() == "Sindhi") { tochosen.Text = "sd"; }
            if (to.SelectedItem.ToString() == "Sinhala (Sinhalese)") { tochosen.Text = "si"; }
            if (to.SelectedItem.ToString() == "Slovak") { tochosen.Text = "sk"; }
            if (to.SelectedItem.ToString() == "Slovenian") { tochosen.Text = "sl"; }
            if (to.SelectedItem.ToString() == "Somali") { tochosen.Text = "so"; }
            if (to.SelectedItem.ToString() == "Spanish") { tochosen.Text = "es"; }
            if (to.SelectedItem.ToString() == "Sundanese") { tochosen.Text = "su"; }
            if (to.SelectedItem.ToString() == "Swahili") { tochosen.Text = "sw"; }
            if (to.SelectedItem.ToString() == "Swedish") { tochosen.Text = "sv"; }
            if (to.SelectedItem.ToString() == "Tagalog (Filipino)") { tochosen.Text = "tl"; }
            if (to.SelectedItem.ToString() == "Tajik") { tochosen.Text = "tg"; }
            if (to.SelectedItem.ToString() == "Tamil") { tochosen.Text = "ta"; }
            if (to.SelectedItem.ToString() == "Tatar") { tochosen.Text = "tt"; }
            if (to.SelectedItem.ToString() == "Telugu") { tochosen.Text = "te"; }
            if (to.SelectedItem.ToString() == "Thai") { tochosen.Text = "th"; }
            if (to.SelectedItem.ToString() == "Turkish") { tochosen.Text = "tr"; }
            if (to.SelectedItem.ToString() == "Turkmen") { tochosen.Text = "tk"; }
            if (to.SelectedItem.ToString() == "Ukrainian") { tochosen.Text = "uk"; }
            if (to.SelectedItem.ToString() == "Urdu") { tochosen.Text = "ur"; }
            if (to.SelectedItem.ToString() == "Uyghur") { tochosen.Text = "ug"; }
            if (to.SelectedItem.ToString() == "Uzbek") { tochosen.Text = "uz"; }
            if (to.SelectedItem.ToString() == "Vietnamese") { tochosen.Text = "vi"; }
            if (to.SelectedItem.ToString() == "Welsh") { tochosen.Text = "cy"; }
            if (to.SelectedItem.ToString() == "Xhosa") { tochosen.Text = "xh"; }
            if (to.SelectedItem.ToString() == "Yiddish") { tochosen.Text = "yi"; }
            if (to.SelectedItem.ToString() == "Yoruba") { tochosen.Text = "yo"; }
            if (to.SelectedItem.ToString() == "Zulu") { tochosen.Text = "zu"; }
        }

        private void from_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            check();
            if (from.SelectedItem.ToString() == "Afrikaans") { fromchosen.Text = "af"; }
            if (from.SelectedItem.ToString() == "Albanian") { fromchosen.Text = "sq"; }
            if (from.SelectedItem.ToString() == "Amharic") { fromchosen.Text = "am"; }
            if (from.SelectedItem.ToString() == "Arabic") { fromchosen.Text = "ar"; }
            if (from.SelectedItem.ToString() == "Armenian") { fromchosen.Text = "hy"; }
            if (from.SelectedItem.ToString() == "Azerbaijani") { fromchosen.Text = "az"; }
            if (from.SelectedItem.ToString() == "Basque") { fromchosen.Text = "eu"; }
            if (from.SelectedItem.ToString() == "Belarusian") { fromchosen.Text = "be"; }
            if (from.SelectedItem.ToString() == "Bengali") { fromchosen.Text = "bn"; }
            if (from.SelectedItem.ToString() == "Bosnian") { fromchosen.Text = "bs"; }
            if (from.SelectedItem.ToString() == "Bulgarian") { fromchosen.Text = "bg"; }
            if (from.SelectedItem.ToString() == "Catalan") { fromchosen.Text = "ca"; }
            if (from.SelectedItem.ToString() == "Cebuano") { fromchosen.Text = "ceb"; }
            if (from.SelectedItem.ToString() == "Chinese (Simplified)") { fromchosen.Text = "zh"; }
            if (from.SelectedItem.ToString() == "Chinese (Traditional)") { fromchosen.Text = "zh-TW"; }
            if (from.SelectedItem.ToString() == "Corsican") { fromchosen.Text = "co"; }
            if (from.SelectedItem.ToString() == "Croatian") { fromchosen.Text = "hr"; }
            if (from.SelectedItem.ToString() == "Czech") { fromchosen.Text = "cs"; }
            if (from.SelectedItem.ToString() == "Danish") { fromchosen.Text = "da"; }
            if (from.SelectedItem.ToString() == "Dutch") { fromchosen.Text = "nl"; }
            if (from.SelectedItem.ToString() == "English") { fromchosen.Text = "en"; }
            if (from.SelectedItem.ToString() == "Esperanto") { fromchosen.Text = "eo"; }
            if (from.SelectedItem.ToString() == "Estonian") { fromchosen.Text = "et"; }
            if (from.SelectedItem.ToString() == "Finnish") { fromchosen.Text = "fi"; }
            if (from.SelectedItem.ToString() == "French") { fromchosen.Text = "fr"; }
            if (from.SelectedItem.ToString() == "Frisian") { fromchosen.Text = "fy"; }
            if (from.SelectedItem.ToString() == "Galician") { fromchosen.Text = "gl"; }
            if (from.SelectedItem.ToString() == "Georgian") { fromchosen.Text = "ka"; }
            if (from.SelectedItem.ToString() == "German") { fromchosen.Text = "de"; }
            if (from.SelectedItem.ToString() == "Greek") { fromchosen.Text = "el"; }
            if (from.SelectedItem.ToString() == "Gujarati") { fromchosen.Text = "gu"; }
            if (from.SelectedItem.ToString() == "Haitian Creole") { fromchosen.Text = "ht"; }
            if (from.SelectedItem.ToString() == "Hausa") { fromchosen.Text = "ha"; }
            if (from.SelectedItem.ToString() == "Hawaiian") { fromchosen.Text = "haw"; }
            if (from.SelectedItem.ToString() == "Hebrew") { fromchosen.Text = "he"; }
            if (from.SelectedItem.ToString() == "Hindi") { fromchosen.Text = "hi"; }
            if (from.SelectedItem.ToString() == "Hmong") { fromchosen.Text = "hmn"; }
            if (from.SelectedItem.ToString() == "Hungarian") { fromchosen.Text = "hu"; }
            if (from.SelectedItem.ToString() == "Icelandic") { fromchosen.Text = "is"; }
            if (from.SelectedItem.ToString() == "Igbo") { fromchosen.Text = "ig"; }
            if (from.SelectedItem.ToString() == "Indonesian") { fromchosen.Text = "id"; }
            if (from.SelectedItem.ToString() == "Irish") { fromchosen.Text = "ga"; }
            if (from.SelectedItem.ToString() == "Italian") { fromchosen.Text = "it"; }
            if (from.SelectedItem.ToString() == "Japanese") { fromchosen.Text = "ja"; }
            if (from.SelectedItem.ToString() == "Javanese") { fromchosen.Text = "jv"; }
            if (from.SelectedItem.ToString() == "Kannada") { fromchosen.Text = "kn"; }
            if (from.SelectedItem.ToString() == "Kazakh") { fromchosen.Text = "kk"; }
            if (from.SelectedItem.ToString() == "Khmer") { fromchosen.Text = "km"; }
            if (from.SelectedItem.ToString() == "Kinyarwanda") { fromchosen.Text = "rw"; }
            if (from.SelectedItem.ToString() == "Korean") { fromchosen.Text = "ko"; }
            if (from.SelectedItem.ToString() == "Kurdish") { fromchosen.Text = "ku"; }
            if (from.SelectedItem.ToString() == "Kyrgyz") { fromchosen.Text = "ky"; }
            if (from.SelectedItem.ToString() == "Lao") { fromchosen.Text = "lo"; }
            if (from.SelectedItem.ToString() == "Latvian") { fromchosen.Text = "lv"; }
            if (from.SelectedItem.ToString() == "Lithuanian") { fromchosen.Text = "lt"; }
            if (from.SelectedItem.ToString() == "Luxembourgish") { fromchosen.Text = "lb"; }
            if (from.SelectedItem.ToString() == "Macedonian") { fromchosen.Text = "mk"; }
            if (from.SelectedItem.ToString() == "Malagasy") { fromchosen.Text = "mg"; }
            if (from.SelectedItem.ToString() == "Malay") { fromchosen.Text = "ms"; }
            if (from.SelectedItem.ToString() == "Malayalam") { fromchosen.Text = "ml"; }
            if (from.SelectedItem.ToString() == "Maltese") { fromchosen.Text = "mt"; }
            if (from.SelectedItem.ToString() == "Maori") { fromchosen.Text = "mi"; }
            if (from.SelectedItem.ToString() == "Marathi") { fromchosen.Text = "mr"; }
            if (from.SelectedItem.ToString() == "Mongolian") { fromchosen.Text = "mn"; }
            if (from.SelectedItem.ToString() == "Myanmar (Burmese)") { fromchosen.Text = "my"; }
            if (from.SelectedItem.ToString() == "Nepali") { fromchosen.Text = "ne"; }
            if (from.SelectedItem.ToString() == "Norwegian") { fromchosen.Text = "no"; }
            if (from.SelectedItem.ToString() == "Nyanja (Chichewa)") { fromchosen.Text = "ny"; }
            if (from.SelectedItem.ToString() == "Odia (Oriya)") { fromchosen.Text = "or"; }
            if (from.SelectedItem.ToString() == "Pashto") { fromchosen.Text = "ps"; }
            if (from.SelectedItem.ToString() == "Persian") { fromchosen.Text = "fa"; }
            if (from.SelectedItem.ToString() == "Polish") { fromchosen.Text = "pl"; }
            if (from.SelectedItem.ToString() == "Portuguese (Portugal, Brazil)") { fromchosen.Text = "pt"; }
            if (from.SelectedItem.ToString() == "Punjabi") { fromchosen.Text = "pa"; }
            if (from.SelectedItem.ToString() == "Romanian") { fromchosen.Text = "ro"; }
            if (from.SelectedItem.ToString() == "Russian") { fromchosen.Text = "ru"; }
            if (from.SelectedItem.ToString() == "Samoan") { fromchosen.Text = "sm"; }
            if (from.SelectedItem.ToString() == "Scots Gaelic") { fromchosen.Text = "gd"; }
            if (from.SelectedItem.ToString() == "Serbian") { fromchosen.Text = "sr"; }
            if (from.SelectedItem.ToString() == "Sesotho") { fromchosen.Text = "st"; }
            if (from.SelectedItem.ToString() == "Shona") { fromchosen.Text = "sn"; }
            if (from.SelectedItem.ToString() == "Sindhi") { fromchosen.Text = "sd"; }
            if (from.SelectedItem.ToString() == "Sinhala (Sinhalese)") { fromchosen.Text = "si"; }
            if (from.SelectedItem.ToString() == "Slovak") { fromchosen.Text = "sk"; }
            if (from.SelectedItem.ToString() == "Slovenian") { fromchosen.Text = "sl"; }
            if (from.SelectedItem.ToString() == "Somali") { fromchosen.Text = "so"; }
            if (from.SelectedItem.ToString() == "Spanish") { fromchosen.Text = "es"; }
            if (from.SelectedItem.ToString() == "Sundanese") { fromchosen.Text = "su"; }
            if (from.SelectedItem.ToString() == "Swahili") { fromchosen.Text = "sw"; }
            if (from.SelectedItem.ToString() == "Swedish") { fromchosen.Text = "sv"; }
            if (from.SelectedItem.ToString() == "Tagalog (Filipino)") { fromchosen.Text = "tl"; }
            if (from.SelectedItem.ToString() == "Tajik") { fromchosen.Text = "tg"; }
            if (from.SelectedItem.ToString() == "Tamil") { fromchosen.Text = "ta"; }
            if (from.SelectedItem.ToString() == "Tatar") { fromchosen.Text = "tt"; }
            if (from.SelectedItem.ToString() == "Telugu") { fromchosen.Text = "te"; }
            if (from.SelectedItem.ToString() == "Thai") { fromchosen.Text = "th"; }
            if (from.SelectedItem.ToString() == "Turkish") { fromchosen.Text = "tr"; }
            if (from.SelectedItem.ToString() == "Turkmen") { fromchosen.Text = "tk"; }
            if (from.SelectedItem.ToString() == "Ukrainian") { fromchosen.Text = "uk"; }
            if (from.SelectedItem.ToString() == "Urdu") { fromchosen.Text = "ur"; }
            if (from.SelectedItem.ToString() == "Uyghur") { fromchosen.Text = "ug"; }
            if (from.SelectedItem.ToString() == "Uzbek") { fromchosen.Text = "uz"; }
            if (from.SelectedItem.ToString() == "Vietnamese") { fromchosen.Text = "vi"; }
            if (from.SelectedItem.ToString() == "Welsh") { fromchosen.Text = "cy"; }
            if (from.SelectedItem.ToString() == "Xhosa") { fromchosen.Text = "xh"; }
            if (from.SelectedItem.ToString() == "Yiddish") { fromchosen.Text = "yi"; }
            if (from.SelectedItem.ToString() == "Yoruba") { fromchosen.Text = "yo"; }
            if (from.SelectedItem.ToString() == "Zulu") { fromchosen.Text = "zu"; }
        }

        private async void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (livetrans.IsOn == true)
            {
                if (output.Text == "initial-scale=1, minimum-scale=1, width=device-width")
                {

                    try { showerror("There was something wrong with your request. Please try again."); } catch { };
                }
                if (from.SelectedItem != null)
                {
                    if (to.SelectedItem != null)
                    {
                        var client = new HttpClient();
                        try
                        {
                            var result = await client.GetAsync(new Uri("https://translate.googleapis.com/translate_a/single?client=gtx&sl=" + fromchosen.Text + "&tl=" + tochosen.Text + "&dt=t&q=" + input.Text));
                            string[] json = result.Content.ToString().Split('"');
                            output.Text = json[1];


                        }
                        catch (Exception ex)
                        {
                            showerror(ex.Message);
                        }
                        if (output.Text == "-//W3C//DTD HTML 4.01 Transitional//EN")
                        {
                            try
                            {
                                showerror("You've been temporairly banned from the Google Translate API. This might have happened because you have live translation on. Wait a couple hours and be careful in the future.");
                            }
                            catch
                            {
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                check();
            }
        }

        private void check()
        {
            int count = 0;
            if (from.SelectedItem != null)
            {
                count++;
                Debug.WriteLine(count);
            }
            if (to.SelectedItem != null)
            {
                count++;
                Debug.WriteLine(count);
            }
            if (!string.IsNullOrEmpty(input.Text))
            {
                count++;
                Debug.WriteLine(count);
            }
            if (count == 3)
            {
                Translate.IsEnabled = true;
                count = 0;
            }
            else
            {
                Translate.IsEnabled = false;
                count = 0;
            }
            if (from.SelectedItem != null)
            {
                if (to.SelectedItem != null)
                {
                    if (!from.SelectedItem.Equals(to.SelectedItem))
                    {
                        switchlang.IsEnabled = true;
                    }
                }
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (page.ActualWidth < 690)
            {
                mainmf.Orientation = Orientation.Vertical;
                MF.Visibility = Visibility.Collapsed;
                MFD.Visibility = Visibility.Visible;
            }
            else
            {
                mainmf.Orientation = Orientation.Horizontal;
                MF.Visibility = Visibility.Visible;
                MFD.Visibility = Visibility.Collapsed;
            }

            if (page.ActualHeight > 350)
            {
                input.Height = 96;
                output.Height = 96;
                input.MinHeight = 96;
                output.MinHeight = 96;
            }
            else
            {
                input.Height = 32;
                output.Height = 32;
                input.MinHeight = 32;
                output.MinHeight = 32;
                input.MaxHeight = 32;
                output.MaxHeight = 32;
            }
        }



        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {

        }
        public interface ISettingsService
        {
            void SetValue<T>(string key, T value);
            T GetValue<T>(string key);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (livetrans.IsOn == true)
            {
                livetransison.IsOpen = true;
                Translate.Visibility = Visibility.Collapsed;
            }
            else
            {
                livetransison.IsOpen = false;
                Translate.Visibility = Visibility.Visible;
            }
            if (hisshow.IsOn == false)
            {
                ApplicationData.Current.LocalSettings.Values["history"] = false;
                histbutton.Visibility = Visibility.Collapsed;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["history"] = true;
                histbutton.Visibility = Visibility.Visible;
            }
            if (compact.IsOn == true)
            {
                ApplicationData.Current.LocalSettings.Values["compact"] = true;
                big.Padding = new Thickness(8, 8, 8, 8);
                mainflyout.Padding = new Thickness(3, 3, 3, 3);
                big.Margin = new Thickness(5, 0, 5, 5);
                settingstext.Padding = new Thickness(10, 10, 5, 8);
                settingitem0.Padding = new Thickness(5, 3, 5, 3);
                settingitem1.Padding = new Thickness(5, 3, 5, 3);
                settingitem2.Padding = new Thickness(5, 3, 5, 3);
                settingitem5.Padding = new Thickness(5, 3, 5, 3);
                mainflyout.Padding = new Thickness(0, 0, 0, 0);
                apply.Margin = new Thickness(165, 0, 0, 0);
                bighistory.Padding = new Thickness(8, 8, 8, 8);
                mainflyouthistory.Padding = new Thickness(3, 3, 3, 3);
                bighistory.Margin = new Thickness(5, 0, 5, 5);
                historytext.Padding = new Thickness(10, 10, 5, 8);
                mainflyouthistory.Padding = new Thickness(0, 0, 0, 0);
                apply.Margin = new Thickness(165, 0, 0, 0);
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["compact"] = false;
                big.Margin = new Thickness(5, 0, 5, 5);
                big.Padding = new Thickness(15, 15, 15, 15);
                settingitem0.Padding = new Thickness(5, 5, 5, 5);
                settingitem1.Padding = new Thickness(5, 5, 5, 5);
                settingitem2.Padding = new Thickness(5, 5, 5, 5);
                settingitem5.Padding = new Thickness(5, 5, 5, 5);
                mainflyout.Padding = new Thickness(5, 5, 5, 5);
                settingstext.Padding = new Thickness(10, 10, 20, 15);
                apply.Margin = new Thickness(144, 0, 0, 0);
                bighistory.Padding = new Thickness(15, 15, 15, 15);
                mainflyouthistory.Padding = new Thickness(5, 5, 5, 5);
                bighistory.Margin = new Thickness(5, 0, 5, 5);
                historytext.Padding = new Thickness(10, 10, 20, 15);
                mainflyouthistory.Padding = new Thickness(5, 5, 5, 5);
            }
            if (lightmode.IsChecked == true)
            {
                ApplicationData.Current.LocalSettings.Values["theme"] = "1";
            }
            if (darkmode.IsChecked == true)
            {
                ApplicationData.Current.LocalSettings.Values["theme"] = "2";
            }
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings != null)
            {
                if (localSettings.Values["theme"] != null)
                {
                    if (localSettings.Values["theme"].ToString() == "1")
                    {
                        // TODO: make themes work in compact overlay
                        page.RequestedTheme = ElementTheme.Light;
                        AppTitleBar.RequestedTheme = ElementTheme.Light;
                        FrameworkElement root = (FrameworkElement)Window.Current.Content;
                        root.RequestedTheme = ElementTheme.Light;
                    }
                    if (localSettings.Values["theme"].ToString() == "2")
                    {
                        AppTitleBar.RequestedTheme = ElementTheme.Dark;
                        FrameworkElement root = (FrameworkElement)Window.Current.Content;
                        root.RequestedTheme = ElementTheme.Dark;
                        // this one sets dark mode
                    }

                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void faviconbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void pipbutton_Click(object sender, RoutedEventArgs e)
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync();
            appWindow.Closed += AppWindow_Closed;
            Frame appWindowFrame = new Frame();
            AppWindowPage page = (AppWindowPage)appWindowFrame.Content;
            var localSettings = ApplicationData.Current.LocalSettings;
            appWindow.Presenter.RequestPresentation(AppWindowPresentationKind.CompactOverlay);
            appWindowFrame.Navigate(typeof(AppWindowPage));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowFrame);
            await appWindow.TryShowAsync();
            pipbutton.Visibility = Visibility.Collapsed;
        }

        private void AppWindow_Closed(AppWindow sender, AppWindowClosedEventArgs args)
        {
            pipbutton.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string)
            {
                input.Text = SoftwareKobo.Net.WebUtility.UrlDecode(e.Parameter.ToString());
            }
            else
            {
            }
        }

        private void switchlang_Click(object sender, RoutedEventArgs e)
        {
            var fromlang = from.SelectedItem;
            var tolang = to.SelectedItem;
            from.SelectedItem = tolang;
            to.SelectedItem = fromlang;
        }
    }
}