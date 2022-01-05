using RealWorldUsage.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldUsage.Views.Snackbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SnackBarView : ContentView
    {
        public SnackBarView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<SnackbarPage, BatteryModel>(this, 
                "BatteryEvent", 
                ManageBattery);

            MessagingCenter.Subscribe<SnackbarPage, bool>(this,
                "ConnectionEvent",
                ManageConnection);
        }

        private void ManageConnection(SnackbarPage arg1, bool networkConnected)
        {
            NetworkStatus.Text = $"Internet connection {(networkConnected ? "good" : "unavailable")}";
        }

        private void ManageBattery(SnackbarPage arg1, BatteryModel batteryModel)
        {
            NetworkStatus.Text = $"Battery {batteryModel.State.ToText()} at level {batteryModel.ChargeLevel * 100}%";
        }
    }

    public static class BatterModelExtension
    {
        public static string ToText(this BatteryState batteryState)
        {
            return batteryState switch
            {
                BatteryState.Discharging => "Discharging",
                BatteryState.Charging => "Charging",
                BatteryState.NotCharging => "Not Charging",
                BatteryState.Full => "Full",
                BatteryState.Unknown => "Unknown",
                _ => "Unknown"
            };
        }
    }
}