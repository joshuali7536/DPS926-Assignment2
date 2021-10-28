using FFXIVMountTracker.iOS;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDB))]
namespace FFXIVMountTracker.iOS
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "favMountDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}