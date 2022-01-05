using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using ExpensesApp.Interfaces;

namespace ExpensesApp.Models
{
    public class Expense
    {
        private static SQLiteConnection database;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public float Ammount
        {
            get;
            set;
        }

        [MaxLength(25)]
        public string Description
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public Expense()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
        }

        public static int InsertExpense(Expense expense)
        {
            //using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            //{
            //    conn.CreateTable<Expense>();
            //    return conn.Insert(expense);
            //}

            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Expense>();
            return database.Insert(expense);
        }

        public static List<Expense> GetExpenses()
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            //{
            //    conn.CreateTable<Expense>();
            //    return conn.Table<Expense>().ToList();
            //}

            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Expense>();
            return database.Table<Expense>().ToList();
        }

        public static float TotalExpensesAmmount()
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            //{
            //    conn.CreateTable<Expense>();
            //    return conn.Table<Expense>().ToList().Sum(e => e.Ammount);
            //}

            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Expense>();
            return database.Table<Expense>().ToList().Sum(e => e.Ammount);
        }

        public static List<Expense> GetExpenses(string category)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            //{
            //    conn.CreateTable<Expense>();
            //    return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            //}

            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Expense>();
            return database.Table<Expense>().Where(e => e.Category == category).ToList();
        }
    }
}
