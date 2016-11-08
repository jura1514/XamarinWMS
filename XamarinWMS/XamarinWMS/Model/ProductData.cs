using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Model
{
    public class ProductData
    {
        [PrimaryKey]
        public string ProdId { get; set; }

        public string ProdState { get; set; }

        public DateTime StateChangeTime { get; set; }
    }
}
