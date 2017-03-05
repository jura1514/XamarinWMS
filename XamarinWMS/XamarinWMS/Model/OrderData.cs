using SQLite;
using System;

namespace XamarinWMS.Model
{
    public class OrderData
    {
        [PrimaryKey, AutoIncrement]
        public int OrderId { get; set; }

        public string OrderState { get; set; }

        public string Description { get; set; }

        public DateTime StateChangeTime { get; set; }

        public bool IsDispatched { get; set; }

        public bool InQueue { get; set; }
    }
}
