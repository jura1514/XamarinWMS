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
        public string StockId { get; set; }
        [ForeignKey(typeof(DeliveryLineData))]
        public string DeliveryLineId { get; set; }
        public string StockState { get; set; }
        public DateTime StateChangeTime { get; set; }
        public int Qty { get; set; }
        public string Location { get; set; }
    }
}
