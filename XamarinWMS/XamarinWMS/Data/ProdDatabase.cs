using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class ProdDatabase
    {
        private SQLiteConnection _connection;

        public ProdDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ProductData>();
        }

        public List<ProductData> GetAllProducts()
        {
            return _connection.Query<ProductData>("Select * From [ProductData]");
        }
        public int SaveProduct(ProductData aProd)
        {
            return _connection.Insert(aProd);
        }
        public int DeleteProduct(ProductData aProd)
        {
            return _connection.Delete(aProd);
        }
        public int EditProduct(ProductData aProd)
        {
            return _connection.Update(aProd);
        }
    }
}
