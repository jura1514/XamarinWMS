using SQLite;
using System.Collections.Generic;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class ProdDatabase
    {
        private SQLiteConnection _connection;

        public ProdDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<ProductData>();
        }

        public List<ProductData> GetAllProducts()
        {
            return _connection.Query<ProductData>("Select * From [ProductData]");
        }
        public ProductData GetProdById(int aSelectedProdId)
        {
            return _connection.Find<ProductData>(aSelectedProdId);
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
