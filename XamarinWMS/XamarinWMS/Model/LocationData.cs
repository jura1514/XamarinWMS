using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
