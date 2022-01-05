using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        ExpensesVM ViewModel;

        public ExpensesPage()
        {
            InitializeComponent();
            ViewModel = Resources["expenseVM"] as ExpensesVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenses();
        }
    }
}