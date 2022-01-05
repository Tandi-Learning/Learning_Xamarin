using RealWorldUsage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldUsage.Views.Snackbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SnackbarPage : ContentPage
    {
        NetworkAccess networkAccess = NetworkAccess.Unknown;

        public SnackbarPage()
        {
            InitializeComponent();

            SnackBarView.IsVisible = false;
        }

        private void OnCheckNetworkClicked(object sender, EventArgs e)
        {
            if (networkAccess != Connectivity.NetworkAccess)
            {
                networkAccess = Connectivity.NetworkAccess;

                MessagingCenter.Send(this, "ConnectionEvent",
                    networkAccess == NetworkAccess.Internet);
            }

            SnackBarView.IsVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                SnackBarView.IsVisible = false;
                return false; // True = Repeat again, False = Stop the timer
            });
        }

        private void OnCheckBatteryClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "BatteryEvent", new BatteryModel
            {
                ChargeLevel = Battery.ChargeLevel,
                State = Battery.State
            });

            SnackBarView.IsVisible = true;
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                SnackBarView.IsVisible = false;
                return false; // True = Repeat again, False = Stop the timer
            });
        }
    }
}