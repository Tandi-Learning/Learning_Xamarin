using ExpensesApp.Droid.DbConnection;
using ExpensesApp.Interfaces;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection))]
namespace ExpensesApp.Droid.DbConnection
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "expenses.db");
            return new SQLiteConnection(path);
        }
    }
}