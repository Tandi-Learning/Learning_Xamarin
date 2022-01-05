using ExpensesApp.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class App : Application
    {
        private SQLiteConnection database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
