using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        NewExpenseVM ViewModel;

        public NewExpensePage()
        {
            InitializeComponent();

            ViewModel = Resources["newExpenseVM"] as NewExpenseVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenseStatus();


            // dynamically add rows to the TableView
            int count = 0;
            foreach(var es in ViewModel.ExpenseStatuses)
            {
                var cell = new SwitchCell { Text = es.Name };

                Binding binding = new Binding
                {
                    Source = ViewModel.ExpenseStatuses[count],
                    Path = "Status",
                    Mode = BindingMode.TwoWay
                };
                cell.SetBinding(SwitchCell.OnProperty, binding);

                var section = new TableSection("Statuses");
                section.Add(cell);
                expenseTableView.Root.Add(section);

                count++;
            }
        }
    }
}