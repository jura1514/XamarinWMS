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
        public int PickId { get; set; }

        [ForeignKey(typeof(OrderData))]
        public string OrderId { get; set; }

        [ForeignKey(typeof(DeliveryLineData))]
        public int DeliveryLineId { get; set; }

        [ForeignKey(typeof(ProductData))]
        public int Product { get; set; }

        public string PickState { get; set; }

        public DateTime StateChangeTime { get; set; }

        public string Description { get; set; }

        public int ActualQty { get; set; }

        public int PlannedQty { get; set; }

    }
}
