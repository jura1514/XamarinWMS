using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderState { get; set; }

        public string Description { get; set; }

        public DateTime StateChangeTime { get; set; }
    }
}