using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class PickData
    {
        [PrimaryKey, AutoIncrement]
        public string PickId { get; set; }
        [ForeignKey(typeof(OrderData))]
        public string OrderId { get; set; }
        [ForeignKey(typeof(StockData))]
        public string StockId { get; set; }
        public string PickState { get; set; }
        public DateTime StateChangeTime { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
    }
}
