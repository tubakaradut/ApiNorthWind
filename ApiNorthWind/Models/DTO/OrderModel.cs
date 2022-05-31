using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNorthWind.Models.DTO
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
    }
}