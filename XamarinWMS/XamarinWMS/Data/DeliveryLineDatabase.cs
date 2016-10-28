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
    public class DeliveryLineDatabase
    {
        private SQLiteConnection _connection;

        public DeliveryLineDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
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
