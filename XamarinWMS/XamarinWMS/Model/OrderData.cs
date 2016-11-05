using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class OrderData
    {
        [PrimaryKey, AutoIncrement]
        public string OrderId { get; set; }
        public string OrderState { get; set; }
        public DateTime StateChangeTime { get; set; }
    }
}
