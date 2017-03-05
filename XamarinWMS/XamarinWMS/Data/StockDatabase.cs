using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class StockDatabase
    {
        private SQLiteConnection _connection;

        public StockDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<StockData>();
        }

        public List<StockData> GetAllStock()
        {
            return _connection.Query<StockData>("Select * From [StockData]");
        }
        public List<StockData> GetAllStockFromLocation(string LocId)
        {
            return _connection.Query<StockData>("Select * From [StockData] Where Location = ?", LocId);
        }
        public StockData GetStock(int StockId)
        {
            return _connection.Find<StockData>(StockId);
        }
        public int SaveStock(StockData aStock)
        {
            return _connection.Insert(aStock);
        }
        public int DeleteStock(StockData aStock)
        {
            return _connection.Delete(aStock);
        }
        public int EditStock(StockData aStock)
        {
            return _connection.Update(aStock);
        }
    }
}
