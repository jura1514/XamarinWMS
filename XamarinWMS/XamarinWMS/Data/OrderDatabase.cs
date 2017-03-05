using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class OrderDatabase
    {
        private SQLiteConnection _connection;

        public OrderDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<OrderData>();
        }

        public List<OrderData> GetAllOrders()
        {
            return _connection.Query<OrderData>("Select * From [OrderData]");
        }
        public int SaveOrder(OrderData aOrder)
        {
            return _connection.Insert(aOrder);
        }
        public int DeleteOrder(OrderData aOrder)
        {
            return _connection.Delete(aOrder);
        }
        public int EditOrder(OrderData aOrder)
        {
            return _connection.Update(aOrder);
        }
    }
}
