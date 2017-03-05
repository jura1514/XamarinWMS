using SQLite;
using System;

namespace XamarinWMS.Model
{
    public class ProductData
    {
        [PrimaryKey]
        public string ProdId { get; set; }

        public string ProdState { get; set; }

        public DateTime StateChangeTime { get; set; }
    }
}
