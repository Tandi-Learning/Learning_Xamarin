using ExpensesApp.Interfaces;
using ExpensesApp.iOS.DbConnection;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection))]
namespace ExpensesApp.iOS.DbConnection
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "..", "Library", "expenses.db");
            return new SQLiteConnection(path);
        }
    }
}