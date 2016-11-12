using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class StockData
    {
        [PrimaryKey, AutoIncrement]
        public int StockId { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(DeliveryLineData))]    
        public int DeliveryLineId { get; set; }

        [ForeignKey(typeof(ProductData))]
        public string Product { get; set; }

        [ForeignKey(typeof(LocationData))]
        public string Location { get; set; }

        public string StockState { get; set; }

        public DateTime StateChangeTime { get; set; }

        public int Qty { get; set; }
    }
}
