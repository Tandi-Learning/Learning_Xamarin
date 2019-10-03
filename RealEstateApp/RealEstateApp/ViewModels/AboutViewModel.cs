using System;
using System.Windows.Input;
using RealEstateApp.ViewModels.Base;
using Xamarin.Forms;

namespace RealEstateApp.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}