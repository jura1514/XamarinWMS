using SQLite;
using System.Collections.Generic;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public class DeliveryLineDatabase
    {
        private SQLiteConnection _connection;

        public DeliveryLineDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<DeliveryLineData>();
        }

        public List<DeliveryLineData> GetAllDelLines()
        {
            return _connection.Query<DeliveryLineData>("Select * From [DeliveryLineData]");
        }
        public List<DeliveryLineData> GetAllDelLinesForDelID(DeliveryData aSelectedDel)
        {
            return _connection.Query<DeliveryLineData>("Select * From [DeliveryLineData] Where DeliveryId = ?", aSelectedDel.DeliveryId);
        }
        public DeliveryLineData GetDeliveryLine(int DelLineId )
        {
            return _connection.Find<DeliveryLineData>(DelLineId);
        }
        public int SaveDelLine(DeliveryLineData aDelLine)
        {
            return _connection.Insert(aDelLine);
        }
        public int DeleteDelLine(DeliveryLineData aDelLine)
        {
            return _connection.Delete(aDelLine);
        }
        public int EditDelLine(DeliveryLineData aDelLine)
        {
            return _connection.Update(aDelLine);
        }
    }
}
