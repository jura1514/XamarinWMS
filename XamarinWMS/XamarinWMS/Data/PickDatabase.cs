using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class PickDatabase
    {
        private SQLiteConnection _connection;

        public PickDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<PickData>();
        }

        public List<PickData> GetAllPicks()
        {
            return _connection.Query<PickData>("Select * From [PickData]");
        }
        public List<PickData> GetAllPicksForOrder(int OrderId)
        {
            return _connection.Query<PickData>("Select * From [PickData] Where Orderid = ?", OrderId);
        }
        public int SavePick(PickData aPick)
        {
            return _connection.Insert(aPick);
        }
        public int DeletePick(PickData aPick)
        {
            return _connection.Delete(aPick);
        }
        public int EditPick(PickData aPick)
        {
            return _connection.Update(aPick);
        }
    }
}
