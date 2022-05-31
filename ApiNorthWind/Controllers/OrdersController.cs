using ApiNorthWind.Models.DTO;
using ApiNorthWind.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiNorthWind.Controllers
{
    public class OrdersController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        //Order listeleme

        public List<OrderModel> GetOrders()
        {
            return db.Orders.Select(x => new OrderModel
            {
                OrderId = x.OrderID,
                ShipName = x.ShipName,
                ShipCountry=x.ShipCountry

            }).ToList();
        }

        //ID göre Order çağırma

        public OrderModel GetOrder(int id)
        {
            return db.Orders.Where(x => x.OrderID == id).Select(x => new OrderModel
            {
                OrderId = x.OrderID,
                ShipName = x.ShipName,
                ShipCountry=x.ShipCountry
            }).FirstOrDefault();
        }
    }
}
