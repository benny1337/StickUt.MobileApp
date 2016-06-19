using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.MobileApp.Data
{
    public interface ISQLiteConnectionProvider
    {
        SQLiteConnectionWithLock GetConnection();
    }
}
