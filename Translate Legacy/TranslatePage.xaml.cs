using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Translate_Legacy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TranslatePage : Page
    {
        public TranslatePage()
        {
            this.InitializeComponent();
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
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            foreach (var value in localSettings.Values)
            {
                Debug.WriteLine(value);
            }
            if ((string)localSettings.Values["mode"] == "system")
            {
                Debug.WriteLine("system theme");
            }
            if ((string)localSettings.Values["mode"] == "dark")
            {
                Debug.WriteLine("dark theme");
            }
            if ((string)localSettings.Values["mode"] == "light")
            {
                Debug.WriteLine("light theme");
            }
        }
    }
}
