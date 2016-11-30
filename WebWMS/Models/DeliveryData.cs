﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public class DeliveryData
    {
        public int DeliveryId { get; set; }

        public string Name { get; set; }

        public DateTime ExpectedDate { get; set; }

        public string Customer { get; set; }

        public string State { get; set; }

        public DateTime StateChangeTime { get; set; }

    }
}