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
    public class CustomersController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        //listeleme
        public List<CustomerModel> GetCustomers()
        {
            return db.Customers.Select(x => new CustomerModel
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
                ContactName=x.ContactName

            }).ToList();
        }

        //ID göre çağırma

        public CustomerModel GetCustomer(string id)
        {
            return db.Customers.Where(x => x.CustomerID == id).Select(x => new CustomerModel
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName
            }).FirstOrDefault();
        }
    }
}
