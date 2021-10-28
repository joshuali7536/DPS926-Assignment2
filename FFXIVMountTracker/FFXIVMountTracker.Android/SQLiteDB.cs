using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FFXIVMountTracker.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace FFXIVMountTracker.Droid
{
    class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "favMountDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}