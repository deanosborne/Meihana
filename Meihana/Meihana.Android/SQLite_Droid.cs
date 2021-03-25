using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Meihana.Droid;
using Meihana.Models;
using Meihana.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace Meihana.Droid
{
    public class SQLite_Droid : ISQLite
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
            string fileName = "UserDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            conn = new SQLiteConnection(path);
            conn.CreateTable<User>();
            return conn;
        }
    }
}