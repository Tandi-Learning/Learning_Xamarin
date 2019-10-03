using RealEstateApp.Models;
using RealEstateApp.ViewModels.Base;

namespace RealEstateApp.ViewModels
{
    public class PropertyListItemViewModel : ViewModelBase
    {
        public PropertyListItemViewModel(Property property)
        {
            Property = property;
        }

        private Property _property;

        public Property Property
        {
            get => _property;
            set => SetProperty(ref _property, value);
        }
    }
}