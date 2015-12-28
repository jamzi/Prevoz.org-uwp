using System.Text.RegularExpressions;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Prevozi.Models;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Prevozi
{
    public sealed partial class MainPage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings =
                Windows.Storage.ApplicationData.Current.LocalSettings;

        List<CarshareSearch> last_searches = new List<CarshareSearch>();


        public MainPage()
        {
            this.InitializeComponent();

            //zadnja iskanja
            if (localSettings.Values["lastCarshare"] != null)
            {
            
                lvCarshareRecent.Items.Clear();
                String data = localSettings.Values["lastCarshare"].ToString();
                String[] last_carshares = data.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < last_carshares.Length; i++)
                {
                    string[] carshare_detail = last_carshares[i].Split(new char[0]);
                    CarshareSearch search = new CarshareSearch(
                    carshare_detail[0], carshare_detail[2], carshare_detail[3], carshare_detail[4], carshare_detail[5]);
                    last_searches.Add(search);
                    lvCarshareRecent.Items.Add(search.From +  " -> " + search.To + ", " + search.Day + "-" + search.Month + "-" + search.Year) ;
                }
                    
                }
            }
                
        


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //back 
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

        private async void callApi(string id)
        {
            var CarshareID = await APICall.GetCarsharesID(id);
            if(CarshareID != null)
            {
                Frame.Navigate(typeof(CarshareDetails), CarshareID);
            }
            
        }

        private void btnIskanje_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrihod.Text) &&
                !string.IsNullOrEmpty(txtOdhod.Text))
            {
                CarshareSearch search = new CarshareSearch(
                    txtOdhod.Text, txtPrihod.Text,
                    dpCasOdhoda.Date.Year.ToString(),
                    dpCasOdhoda.Date.Month.ToString("00"),
                    dpCasOdhoda.Date.Day.ToString("00"));

                localSettings.Values["lastCarshare"] += search.From + " -> " + search.To + " " + search.Year + " " + search.Month + " " + search.Day + "\n" ; 

                Frame.Navigate(typeof (ListCarshare), search);
            }
            else
            {
                tblInfo.Text = "Vnesite kraj odhoda in kraj prihoda!";
            }

        }

        private void lvCarshareRecent_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv != null)
            {
                Frame.Navigate(typeof(ListCarshare), last_searches[lv.SelectedIndex]);
            }
        }

        // Gets the rectangle of the element
        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        private void btnClearLastSearch_Click(object sender, RoutedEventArgs e)
        {
            lvCarshareRecent.Items.Clear();
            localSettings.Values["lastCarshare"] = "";
        }

        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnPonudba_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
