using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
{

    public class Share : IShare
    {
        public async Task Show(string title, string message, string filePath)
        {
  
        }
    }
}