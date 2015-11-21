using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Prevozi.Models;

namespace Prevozi
{   
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            string myPages = "";
            foreach (PageStackEntry page in rootFrame.BackStack)
            {
                myPages += page.SourcePageType.ToString() + "\n";
            }

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }    
        }

        private void btnIskanje_Click(object sender, RoutedEventArgs e)
        {
            //podatki o željah prevoza
            string[] userData = new string[3];
            userData[0] = txtOdhod.Text;
            userData[1] = txtPrihod.Text;
            userData[2] = dpCasOdhoda.Date.Year.ToString() + "-" +
                          dpCasOdhoda.Date.Month.ToString() + "-" +
                          dpCasOdhoda.Date.Day.ToString();

            if (userData[0] != null && userData[0] != "" && userData[1] != null && userData[1] != "")
            {
                Windows.Storage.ApplicationDataContainer localSettings =
                    Windows.Storage.ApplicationData.Current.LocalSettings;
                Windows.Storage.StorageFolder localFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;
                localSettings.Values["recentSearch"] += userData[0] + userData[1] + "\n";

                tblZadnjaIskanjaData.Text = localSettings.Values["recentSearch"].ToString();
                Frame.Navigate(typeof(ListCarshare), userData);
            }
            else
            {
                tblInfo.Text = "Vnesite kraj odhoda in kraj prihoda!";
            }         
        }

 
    }
}
