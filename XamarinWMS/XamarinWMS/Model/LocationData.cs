using SQLite;
using System;

namespace XamarinWMS.Model
{
    public class LocationData
    {
        [PrimaryKey]
        public string LocationId { get; set; }

        public string LocState { get; set; }

        public DateTime StateChangeTime { get; set; }
    }
}
