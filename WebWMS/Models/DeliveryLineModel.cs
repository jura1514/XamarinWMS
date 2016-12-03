using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebWMS.Models
{
    public class DeliveryLineModel
    {
        [Key]
        public int DeliveryLineId { get; set; }

        public string Name { get; set; }

        [ForeignKey("DeliveryModel")]
        public int DeliveryId { get; set; }

        public string Product { get; set; }

        public int ExpectedQty { get; set; }

        public int AcceptedQty { get; set; }

        public int RejectedQty { get; set; }

        public bool isUsedForStock { get; set; }

    }
}