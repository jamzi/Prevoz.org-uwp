using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Prevozi.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prevozi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListCarshare : Page
    {
        public static List<CarshareList> carshares = new List<CarshareList>();
        public ListCarshare()
        {
            this.InitializeComponent();
        }

        public async void CallGetCarshares(string fromCity, string toCity, string date)
        {
            string url = String.Format("https://prevoz.org/api/search/shares/?f=" + fromCity + "&t=" + toCity  + "&d=" + date);

            var data = await GetCarshares(url);

            //globalna spremenljivka
            carshares = data.carshare_list;

            if (carshares.Count != 0)
            {
                tblInfoPrevoz.Text = "Ponujeni prevozi (" + fromCity + " --> " + toCity + ")";
                foreach (var carshare in carshares)
                {
                    if (lvCarshares.Items != null) lvCarshares.Items.Add(carshare.date + " " + carshare.price + "€");
                }
            }
            else
            {
                tblInfoPrevoz.Text = "Ni prevozov za določeno pot in termin";
            }
           



        }

        public static async Task<CarshareWrapper> GetCarshares(string url)
        {        
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(url);

            string jsonText = response.Content.ReadAsStringAsync().Result;

            var serializer = new DataContractJsonSerializer(typeof(CarshareWrapper));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));

            var result = (CarshareWrapper)serializer.ReadObject(ms);

            return result;

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //dobimo userdata prek e argumenta
            string[] userData = (string[])e.Parameter;
            //pokličem API
            CallGetCarshares(userData[0], userData[1], userData[2]);

           

            //go back
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
        private void lvCarshares_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ListView lv = sender as ListView;
            var id_carshare = lv.SelectedIndex;
            Frame.Navigate(typeof(CarshareDetails), carshares[id_carshare]);
            
        }

 
    }
}
