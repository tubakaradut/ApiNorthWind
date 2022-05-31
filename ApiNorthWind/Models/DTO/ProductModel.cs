using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiNorthWind.Models.DTO
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}