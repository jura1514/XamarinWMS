using System;
using System.IO;
using XamarinWMS.Droid;
using Xamarin.Forms;

//[assembly: Dependency(typeof(SQLite_Android))]
namespace XamarinWMS.Droid
{
    class SQLite_Android
    {
        public SQLite_Android()
        {
        }

        //#region ISQLite implementation

        //public SQLite.Net.SQLiteConnection GetConnection()
        //{
        //    var sqliteFilename = "XamarinWMS.db3";
        //    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        //   // string libraryPath = Path.Combine(documentsPath, "..", "Library");
        //    var path = Path.Combine(documentsPath, sqliteFilename);
        //    Console.WriteLine(path);
        //    if (!File.Exists(path)) File.Create(path);
        //    var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //    var conn = new SQLite.Net.SQLiteConnection(plat, path);
        //    // Return the database connection 
        //    return conn;
        //}

        //#endregion

    }
}