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
    public class ProductsController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        //ürünleri listeleme
        public List<ProductModel> GetProductList()
        {
            List<ProductModel> productliste = db.Products.Select(x => new ProductModel() 
            {
                ProductID=x.ProductID,
                ProductName=x.ProductName,
                UnitPrice=(decimal)x.UnitPrice

            }).ToList();

            return productliste;
        }

        //ID göre Product çağırma

        public HttpResponseMessage GetProductID(int id)//500
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID == id);
            ProductModel p = new ProductModel();
            p.ProductID = product.ProductID;
            p.ProductName = product.ProductName;
            p.UnitPrice = (decimal)product.UnitPrice;

            if (p != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı");
                return errorResponse;
            }

        }

        //ürün ekleme
       
        public IHttpActionResult PostProduct(ProductModel productModel)
        {
            Product product = new Product()
            {
                ProductID = productModel.ProductID,
                ProductName = productModel.ProductName,
                UnitPrice = productModel.UnitPrice,
            };

            if (productModel != null)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        //ürün Güncelleme
      
        public HttpResponseMessage Put(ProductModel productModel)
        {
            Product updated = db.Products.FirstOrDefault(x => x.ProductID == productModel.ProductID);
           
            if (updated == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ürün bulunamadı");
            }
            else
            {
                updated.ProductName = productModel.ProductName;
                updated.UnitPrice = productModel.UnitPrice;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, updated);
            }
        }
        //ürün silme
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                Product deleted = db.Products.FirstOrDefault(x => x.ProductID == id);
                db.Products.Remove(deleted);
                db.SaveChanges();

                return Ok("veri silindi");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
