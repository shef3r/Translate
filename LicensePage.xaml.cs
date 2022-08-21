using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Translate
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class LicensePage : Page
    {
        public LicensePage()
        {
            this.InitializeComponent();
            licensebutton.IsSelected = true;
        }

        private void chooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (licensebutton.IsSelected)
            {
                license.Visibility = Visibility.Visible;
                credits.Visibility = Visibility.Collapsed;
                about.Visibility = Visibility.Collapsed;
            }
            if (authorsbutton.IsSelected)
            {
                license.Visibility = Visibility.Collapsed;
                credits.Visibility = Visibility.Visible;
                about.Visibility = Visibility.Collapsed;
            }
            if (aboutbutton.IsSelected)
            {
                license.Visibility = Visibility.Collapsed;
                credits.Visibility = Visibility.Collapsed;
                about.Visibility = Visibility.Visible;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Translate.Popup));
        }
    }
}
