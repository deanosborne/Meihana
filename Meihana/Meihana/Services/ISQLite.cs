using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Meihana.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
