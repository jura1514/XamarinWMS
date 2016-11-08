using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class DeliveryLineData
    {
        [PrimaryKey]
        public int DeliveryLineId { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(DeliveryData))]
        public int DeliveryId { get; set; }

        [ForeignKey(typeof(ProductData))]
        public string Product { get; set; }

        public int ExpectedQty { get; set; }

        public int AcceptedQty { get; set; }

        public int RejectedQty { get; set; }

        public DeliveryLineData()
        {
        }
    }
}
