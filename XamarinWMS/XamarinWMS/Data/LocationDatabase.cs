using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class LocationDatabase
    {
        private SQLiteConnection _connection;

        public LocationDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<LocationData>();
        }

        public List<LocationData> GetAllLoc()
        {
            return _connection.Query<LocationData>("Select * From [LocationData]");
        }
        public int SaveLoc(LocationData aLoc)
        {
            return _connection.Insert(aLoc);
        }
        public int DeleteLoc(LocationData aLoc)
        {
            return _connection.Delete(aLoc);
        }
        public int EditLoc(LocationData aLoc)
        {
            return _connection.Update(aLoc);
        }

    }
}
