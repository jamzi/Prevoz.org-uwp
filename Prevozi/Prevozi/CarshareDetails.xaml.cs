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

            lvCarshareDetails.Items.Add("Od: "  + carshareDetail.from);
            lvCarshareDetails.Items.Add("Do: " + carshareDetail.to);
            lvCarshareDetails.Items.Add("Avtor: " + carshareDetail.author);
            lvCarshareDetails.Items.Add("Čas: " + carshareDetail.time);
            lvCarshareDetails.Items.Add("Datum: " + carshareDetail.date);
            lvCarshareDetails.Items.Add("Zavarovan: " + carshareDetail.insured);
            lvCarshareDetails.Items.Add("Komentar: " + carshareDetail.comment);

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
