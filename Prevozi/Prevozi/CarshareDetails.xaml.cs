using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Prevozi.Models;
using Windows.UI.StartScreen;
using System;
using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prevozi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarshareDetails : Page
    {
        CarshareList carshareDetail = new CarshareList();
        public CarshareDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //dobimo userdata prek e argumenta
            carshareDetail = (CarshareList)e.Parameter;

            tblDetailsPrevoz.Text = carshareDetail.from + " -> " + carshareDetail.to;

            if (lvCarshareDetails.Items != null)
            {
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
            }

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

        private async void PinUnPinCommandButton_Click(object sender, RoutedEventArgs e)
        {
            Uri square150x150Logo = new Uri("ms-appx:///Assets/tile.png");
            Uri wide310x150Logo = new Uri("ms-appx:///Assets/tile.png");
            Uri square310x310Logo = new Uri("ms-appx:///Assets/tile.png");
            Uri square30x30Logo = new Uri("ms-appx:///Assets/tile.png");

            SecondaryTile secondaryTile = new SecondaryTile("Prevoz",
                carshareDetail.from + "->" + carshareDetail.to + " . " +  carshareDetail.date + " (" + carshareDetail.contact + ")",
                carshareDetail.id.ToString(),
                square150x150Logo,
                TileSize.Square150x150);

            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent(("Windows.Phone.UI.Input.HardwareButtons"))))
            {
                secondaryTile.VisualElements.Wide310x150Logo = wide310x150Logo;
                secondaryTile.VisualElements.Square310x310Logo = square310x310Logo;
            }

            secondaryTile.VisualElements.Square30x30Logo = square30x30Logo;
            secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;

            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent(("Windows.Phone.UI.Input.HardwareButtons"))))
            {
                secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;
                secondaryTile.VisualElements.ShowNameOnSquare310x310Logo = true;
            }

            // Specify a foreground text value.
            // The tile background color is inherited from the parent unless a separate value is specified.
            secondaryTile.VisualElements.ForegroundText = ForegroundText.Light;

            // Set this to false if roaming doesn't make sense for the secondary tile.
            // The default is true;
            secondaryTile.RoamingEnabled = false;

            // OK, the tile is created and we can now attempt to pin the tile.
            if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent(("Windows.Phone.UI.Input.HardwareButtons"))))
            {
                bool isPinned = await secondaryTile.RequestCreateForSelectionAsync(MainPage.GetElementRect((FrameworkElement)sender), Windows.UI.Popups.Placement.Below);                  
            }
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(("Windows.Phone.UI.Input.HardwareButtons")))
            {
                await secondaryTile.RequestCreateAsync();
            }
            
        }

        private void CopyPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(carshareDetail.contact);
            Clipboard.SetContent(dataPackage);

        }
    }
}
