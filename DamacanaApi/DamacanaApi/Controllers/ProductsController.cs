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

         public class TMP
            {
                  public Guid ID { get; set; }
                public string Name { get; set; }
       
            }


        //GET: api/Products  /* To get list of products */

        public IEnumerable<Product>  Get()
        {
            return db.Products;
            
        }

        //DELETE api/Products

       /* public void Delete(int id)
        {

            Product[] A = db.Products.ToArray();

            Product tmp = A[id];

            db.Products.Remove(tmp);
            db.SaveChanges();
         
        } */


        //GET api/Products 
        public Product get (int id)
        {
            Product[] A = db.Products.ToArray();

            Product tmp = A[id];
            return tmp;
        }


     /*   // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        } */

        // GET: api/Products/5
       /* [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        } */

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products


        public void Post(string Name, decimal Price)
        {
            Product A = new Product();

            A.ID = new Guid();
            A.Name = Name;
            A.Price = Price;

            db.Products.Add(A);
            db.SaveChanges();

        }
        /*[ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.ID = new Guid();
            db.Products.Add(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
        }

      /* // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        } */

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(Guid id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}