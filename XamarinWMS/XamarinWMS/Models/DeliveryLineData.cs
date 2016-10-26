﻿using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS.Models
{
    public class DeliveryLineData
    {
        [PrimaryKey]
        public int DeliveryLineId { get; set; }
        [ForeignKey(typeof(DeliveryData))]
        public int DeliveryId { get; set; }
        public string Name { get; set; }
        public int ExpectedQty { get; set; }
        public int AcceptedQty { get; set; }
        public int RejectedQty { get; set; }

        public DeliveryLineData()
        {
        }
    }
}
