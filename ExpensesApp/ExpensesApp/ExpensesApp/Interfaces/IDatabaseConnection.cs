using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Interfaces
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}