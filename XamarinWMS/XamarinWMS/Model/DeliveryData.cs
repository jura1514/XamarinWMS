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

        public string Customer { get; set; } 

        public string State { get; set; }

        public DateTime StateChangeTime { get; set; }

        public DeliveryData()
        {
        }
    }
}
