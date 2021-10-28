using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FFXIVMountTracker
{
    public interface SQLiteDBInterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
