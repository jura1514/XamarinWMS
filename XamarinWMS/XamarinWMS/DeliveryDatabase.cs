using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public class DeliveryDatabase
    {
        private SQLiteConnection _connection;

        public DeliveryDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<DeliveryData>();
        }

        public IEnumerable<DeliveryData> GetDeliveries()
        {
            return (from t in _connection.Table<DeliveryData>()
                    select t).ToList();
        }

        public DeliveryData GetDelivery(int id)
        {
            return _connection.Table<DeliveryData>().FirstOrDefault(t => t.DeliveryId == id);
        }

        public void DeleteDelivery(int id)
        {
            _connection.Delete<DeliveryData>(id);
        }

        public void AddDelivery(int deliveryId, string name, string status)
        {
            var newDelivery = new DeliveryData
            {
                DeliveryId = deliveryId,
                Name = name,
                Status = status,
                StatusChangeTime = DateTime.Now,
                ExpectedDate = DateTime.Now
            };

            _connection.Insert(newDelivery);
        }
    }
}
