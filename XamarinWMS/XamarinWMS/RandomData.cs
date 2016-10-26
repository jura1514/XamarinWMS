using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS
{
    public class RandomData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Thought { get; set; }
        public DateTime CreatedOn { get; set; }

        public RandomData()
        {
        }
    }
}
