using SQLite;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public class DeliveryDatabase
    {
        private SQLiteConnection _connection;

        public DeliveryDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<DeliveryData>();
        }

        public List<DeliveryData> GetAllDeliveries()
        {
            return _connection.Query<DeliveryData>("Select * From [DeliveryData]");
        }
        public DeliveryData GetDeliveryById(int aSelectedDelId)
        {
            return _connection.Find<DeliveryData>(aSelectedDelId);
        }
        public int SaveDelivery(DeliveryData aDelivery)
        {
            return _connection.Insert(aDelivery);
        }
        public int DeleteDelivery(DeliveryData aDelivery)
        {
            return _connection.Delete(aDelivery);
        }
        public int EditDelivery(DeliveryData aDelivery)
        {
            return _connection.Update(aDelivery);
        }
    }
}
