using RealWorldUsage.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RealWorldUsage.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}