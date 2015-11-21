using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Prevozi.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prevozi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarshareDetails : Page
    {
        public CarshareDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //dobimo userdata prek e argumenta
            CarshareList carshareDetail = (CarshareList)e.Parameter;

            tblDetailsPrevoz.Text = carshareDetail.from + " -> " + carshareDetail.to;

            lvCarshareDetails.Items.Add("Čas: " + carshareDetail.date);
            lvCarshareDetails.Items.Add("Število oseb: " + carshareDetail.num_people);          
            lvCarshareDetails.Items.Add("Strošek: " + carshareDetail.price + "€");
            lvCarshareDetails.Items.Add("Telefon: " + carshareDetail.contact);
            //TODO
            //lahko direktno pokličem oz. pošljemo sms
            if (carshareDetail.insured == "true")
            {
                lvCarshareDetails.Items.Add("Zavarovanje: " + "imam nezgodno zavarovanje za potnike");
            }
            if (carshareDetail.comment != "")
            {
                lvCarshareDetails.Items.Add("Komentar: " + carshareDetail.comment);
            }    
            lvCarshareDetails.Items.Add("Objavljeno: " + carshareDetail.added);

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
    }
}
