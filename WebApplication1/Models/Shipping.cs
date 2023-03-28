using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            Payment = new HashSet<Payment>();
            ShipmentStg = new HashSet<ShipmentStg>();
        }

        public int ShipId { get; set; }
        public string ShipStatus { get; set; }

        public ICollection<Payment> Payment { get; set; }
        public ICollection<ShipmentStg> ShipmentStg { get; set; }
    }
}
