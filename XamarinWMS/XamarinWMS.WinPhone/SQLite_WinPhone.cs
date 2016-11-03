using SQLite.Net.Interop;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XamarinWMS.WinPhone;

[assembly: Dependency(typeof(SQLite_WinPhone))]

namespace XamarinWMS.WinPhone
{
    class SQLite_WinPhone
    {
        public SQLite_WinPhone()
        {
        }

        #region ISQLite implementation

        //public SQLite.Net.SQLiteConnection GetConnection()
        //{
        //    //var fileName = "XamarinWMS.db3";
        //    //var documentsPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        //    //var path = Path.Combine(documentsPath, fileName);
        //    //// var path = "/users/george/documents/wms.db3"
        //    //var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
        //    //var connection = new SQLite.Net.SQLiteConnection(platform, path);
        //    //connection.CreateDatabaseBackup(platform);

        //    //var sqliteFilename = "XamarinWMS.db3";
        //    //string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        //    //var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
        //    //var conn = new SQLite.Net.SQLiteConnection(platform, path);
        //    //return conn;
        //}

        #endregion


    }
}
