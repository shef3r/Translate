using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Translate.Pages;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Management.Deployment;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Translate
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public MainPage()
        {
            this.InitializeComponent();
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(DragRegion);
            UpdateSettings(null);
        }

        private void UpdateSettings(string setting)
        {
            if (setting != null)
            {
                bool value = (bool)settings[setting];
                if (setting == "history")
                {
                    if (value)
                    {
                        HistoryPageButton.Visibility = Visibility.Visible;
                    }
                    else if (!value)
                    {
                        HistoryPageButton.Visibility = Visibility.Collapsed;
                    }

                }
                else if (setting == "autotranslate")
                {

                }
                else if (setting == "compactmode")
                {

                }
                else
                {
                }
            }
            else
            {
                UpdateSettings("history");
                UpdateSettings("autotranslate");
                UpdateSettings("compactmode");
            } 
        }

        private void PageInFrame_ValueTransferredEvent(object sender, string value)
            {
                // Access the transferred value here
                // Use the 'value' parameter as needed
            }

        private void navview_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            string page = args.SelectedItemContainer.Tag.ToString();
            Debug.WriteLine(page);
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
                (contentFrame.Content as SettingsPage).SettingChangedEvent += SettingChanged;
            }
            else if (page == "History")
            {
                contentFrame.Navigate(typeof(HistoryPage));
            }
            else
            {
                contentFrame.Navigate(typeof(TranslatePage));
            }
        }

        private void SettingChanged(object sender, string setting)
        {
            UpdateSettings(setting);
        }

        private void navview_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as Microsoft.UI.Xaml.Controls.NavigationView).SelectedItem = TranslatePageButton;
        }
    }
}
