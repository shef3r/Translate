﻿using System;
using System.Diagnostics;
using Translate.Pages;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Translate
{
    public sealed partial class MainPage : Page
    {
        internal IPropertySet settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        public MainPage()
        {
            this.InitializeComponent();
            CreateDataFile();
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(DragRegion);
            UpdateSettings(null);
        }

        private async void CreateDataFile()
        {
            if ((await ApplicationData.Current.LocalFolder.GetFilesAsync()).Count == 0)
            {
                await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("data.json");
            }
            else
            {
            }
        }

        private void UpdateSettings(string setting)
        {
            if (setting == null)
            {
                UpdateSettings("compactmode");
                UpdateSettings("history");
            }
            else if (settings?.ContainsKey(setting) == true && (settings[setting]?.ToString() == "True" || settings[setting]?.ToString() == "False"))
            {
                bool value = StringToBool(settings[setting].ToString());
                if (setting == "compactmode")
                {
                    int height;
                    if (value)
                    {
                        height = 32;
                    }
                    else
                    {
                        height = 48;
                    }
                    TitleBar.Height = height;
                    DragRegion.Height = height;
                    navview.Margin = new Thickness(0, height, 0, 0);
                }
                if (setting == "history")
                {
                    if (value)
                    {
                        HistoryPageButton.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        HistoryPageButton.Visibility = Visibility.Collapsed;
                    }
                }
            }
            else
            {
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

        private void navview_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            string page = args.SelectedItemContainer.Tag.ToString();
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
