using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DamacanaApi.Models;

namespace DamacanaApi.Controllers
{
    public class ProductsController : ApiController
    {
        private DamacanaApiContext db = new DamacanaApiContext();

         


        //GET: api/Products  /* To get list of products */

        public IQueryable<ProductDTO>  Get()
        {
           
            var Products = from p in db.Products
                           select new ProductDTO()
                           {
                               ID = p.ID,
                               Name = p.Name

                           };
            return Products;
            
        }

        

        //GET api/Products 
        public Product get (int id)
        {
            Product[] A = db.Products.ToArray();

            Product tmp = A[id];
            return tmp;
        }



        

        private int ProductCount()
        {
            Product[] tmp = db.Products.ToArray();


            return tmp.Length;
        }

        //POST: api/Products

         public void Post(string Name, decimal Price)
        {
            Product A = new Product();

            A.ID = ProductCount() + 1;
            A.Name = Name;
            A.Price = Price;

            db.Products.Add(A);
            db.SaveChanges();

        } 
       

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}