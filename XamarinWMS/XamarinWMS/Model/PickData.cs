using SQLite;
using System;

namespace XamarinWMS.Model
{
    public class PickData
    {
        [PrimaryKey, AutoIncrement]
        public int PickId { get; set; }

        //[ForeignKey(typeof(OrderData))]
        public int OrderId { get; set; }

        //[ForeignKey(typeof(DeliveryLineData))]
        public int DeliveryLineId { get; set; }

       // [ForeignKey(typeof(ProductData))]
        public string Product { get; set; }

        public string PickState { get; set; }

        public DateTime StateChangeTime { get; set; }

        public string Description { get; set; }

        public int ActualQty { get; set; }

        public int PlannedQty { get; set; }

    }
}
