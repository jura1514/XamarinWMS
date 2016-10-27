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
    class SQLite_WinPhone : ISQLite
    {
        public SQLite_WinPhone()
        {
        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "XamarinWMS.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            connection.CreateDatabaseBackup(platform);

            return connection;
        }

        #endregion


    }
}
