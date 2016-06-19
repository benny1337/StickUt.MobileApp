using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;
using StickUt.MobileApp.Data;
using SQLite.Net.Interop;

namespace StickUt.MobileApp.Droid.PlatformSpecifics
{
    public class DatabaseConnectionProvider : ISQLiteConnectionProvider
    {
        private ISQLitePlatform _platform;

        public DatabaseConnectionProvider(ISQLitePlatform platform)
        {
            _platform = platform;
        }
        public SQLiteConnectionWithLock GetConnection()
        {
            var sqliteFilename = "stickut.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = System.IO.Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.Net.SQLiteConnectionWithLock(_platform, new SQLiteConnectionString(path, true, null, null, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex));
            return conn;        }
    }
}