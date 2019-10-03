using System.Threading.Tasks;
using RealEstateApp.Services.Navigation;
using RealEstateApp.ViewModels.Base;
using Xamarin.Forms;

namespace RealEstateApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitNavigation();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}