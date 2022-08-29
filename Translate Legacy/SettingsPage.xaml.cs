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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            foreach (var value in localSettings.Values)
            {
                Debug.WriteLine(value);
            }
            if ((string)localSettings.Values["livetrans"] == "no")
            {
                Debug.WriteLine("live translation is off");
            }
            if ((string)localSettings.Values["livetrans"] == "yes")
            {
                Debug.WriteLine("live translation is on");
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            foreach (var value in localSettings.Values)
            {
                Debug.WriteLine(value);
            }
            if ((string)localSettings.Values["livetrans"] == "no")
            {
                Debug.WriteLine("live translation is off");
            }
            if ((string)localSettings.Values["livetrans"] == "yes")
            {
                Debug.WriteLine("live translation is on");
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

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (livetrans.IsOn == true)
            {
                localSettings.Values["livetrans"] = "yes";
            }
            else
            {
                localSettings.Values["livetrans"] = "no";
            }
            if (systemmode.IsSelected == true)
            {
                localSettings.Values["mode"] = "system";
            }
            if (lightmode.IsSelected == true)
            {
                localSettings.Values["mode"] = "light";
            }
            if (darkmode.IsSelected == true)
            {
                localSettings.Values["mode"] = "dark";
            }
            
        }
    }
}
