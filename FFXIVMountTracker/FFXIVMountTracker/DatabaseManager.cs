using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FFXIVMountTracker
{
    class DatabaseManager
    {
        SQLiteAsyncConnection _connection;
        public DatabaseManager()
        {
            _connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }

        public async Task<ObservableCollection<MountClass>> CreateTable()
        {
            await _connection.CreateTableAsync<MountClass>();

            var favListDB = await _connection.Table<MountClass>().ToListAsync();
            var obserFavList = new ObservableCollection<MountClass>(favListDB);
            return obserFavList;
        }

        public async void AddNewMount(MountClass mount)
        {
            try
            {
                await _connection.InsertAsync(mount);
            }
            catch (SQLite.SQLiteException ex)
            {
                //throw new Exception("Already exists");
            }
        }

        public async void DeleteMount(MountClass mount)
        {
            await _connection.DeleteAsync(mount);
        }
    }
}
