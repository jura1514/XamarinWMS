using SQLite;
using System.Collections.Generic;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class LocationDatabase
    {
        private SQLiteConnection _connection;

        public LocationDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<LocationData>();
        }

        public List<LocationData> GetAllLoc()
        {
            return _connection.Query<LocationData>("Select * From [LocationData]");
        }
        public LocationData GetLocationById(string LocId)
        {
            return _connection.Find<LocationData>(LocId);
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
