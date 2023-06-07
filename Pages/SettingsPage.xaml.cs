using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email.DataProvider;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Translate.Pages
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public event EventHandler<string> SettingChangedEvent;

        public SettingsPage()
        {
            this.InitializeComponent();
            if (settings["history"] != null)
            {
                bool value = (bool)settings["history"];
                historyswitch.IsOn = value;
            }
            if (settings["compactmode"] != null)
            {
                bool value = (bool)settings["compactmode"];
                compactswitch.IsOn = value;
            }
            if (settings["autotranslate"] != null)
            {
                bool value = (bool)settings["autotranslate"];
                autoswitch.IsOn = value;
            }
        }

        private void UpdateSettings(string setting)
        {
            if (setting != null)
            {
                bool value = (bool)settings[setting];
                if (setting == "compactmode")
                {
                    // TODO: add padding change to infobar
                    if (!value)
                    {
                        settingtitle.FontSize = 30;
                        setting1.Padding = new Thickness(16);
                        setting2.Padding = new Thickness(16);
                        setting3.Padding = new Thickness(16);
                    }
                    else if (value)
                    {
                        settingtitle.FontSize = 20;
                        setting1.Padding = new Thickness(15, 10, 15, 10);
                        setting2.Padding = new Thickness(15, 10, 15, 10);
                        setting3.Padding = new Thickness(15, 10, 15, 10);
                    }
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

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            double width = (sender as Grid).ActualWidth;
            if (width > 1000)
            {
                panel.Width = 1000;
            }
            else
            {
                panel.Width = width;
            }
            System.Diagnostics.Debug.WriteLine($"{panel.Width}, {width}");
        }

        private void compactswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "compactmode"; 
            settings[setting] = (sender as ToggleSwitch).IsOn;
            SettingChangedEvent?.Invoke(this, setting); 
            UpdateSettings(setting); }

        private void historyswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "history"; settings[setting] = (sender as ToggleSwitch).IsOn; SettingChangedEvent?.Invoke(this, setting); UpdateSettings(setting); }

        private void autoswitch_Toggled(object sender, RoutedEventArgs e) { string setting = "autotranslate"; settings[setting] = (sender as ToggleSwitch).IsOn; SettingChangedEvent?.Invoke(this, setting); UpdateSettings(setting); }
    }
}
