using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class DeliveryData
    {
        [PrimaryKey]
        public int DeliveryId { get; set; }
        public string Name { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Status { get; set; }
        public DateTime StatusChangeTime { get; set; }

        public DeliveryData()
        {
        }
    }
}
