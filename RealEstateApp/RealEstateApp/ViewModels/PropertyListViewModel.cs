using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using RealEstateApp.ViewModels.Base;
using Xamarin.Forms;

namespace RealEstateApp.ViewModels
{
    public class PropertyListViewModel : ViewModelBase
    {
        public ObservableCollection<PropertyListItemViewModel> Properties { get; } =
            new ObservableCollection<PropertyListItemViewModel>();

        public ICommand PropertySelectedCommand => new Command<PropertyListItemViewModel>(SelectPropertyAsync);
        public ICommand AddPropertyCommand => new Command(AddPropertyAsync);
        public ICommand LoadItemsCommand => new Command(LoadProperties);

        private async void AddPropertyAsync()
        {
            await NavigationService.NavigateToModalAsync<AddEditPropertyViewModel>();
        }

        private async void SelectPropertyAsync(PropertyListItemViewModel item)
        {
            await NavigationService.NavigateToAsync<PropertyDetailViewModel>(item.Property);
        }

        public override Task InitializeAsync(object parameter)
        {
            LoadProperties();

            Repository.ObservePropertySaved()
                .Subscribe(x => LoadProperties());

            return Task.CompletedTask;
        }

        private void LoadProperties()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Properties.Clear();

                var items = Repository.GetProperties();

                foreach (var item in items) Properties.Add(new PropertyListItemViewModel(item));
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}