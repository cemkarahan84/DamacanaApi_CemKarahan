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
    public class CartsController : ApiController
    {
        private DamacanaApiContext db = new DamacanaApiContext();
        
        

        // GET: api/Carts
        public IQueryable<Cart> GetCarts()
        {
            return db.Carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> GetCart(Guid id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5

        public void Put (int ProductId, int CartId)
        {
            

            
            Product[] A = db.Products.ToArray();
            

            Product tmp = A[ProductId]; //Recherche produit



           //recherche cart
            foreach(var item in db.Carts)
            {
                if(CartId==item.ID)
                {
                    item.List.Add(tmp);
                }
            }
           
            
                db.SaveChanges(); 
            
        }

        private int count()
        {
           return db.Carts.Count();
        }

        //POST: api/Carts
        
        public void Post ()
        {
            Cart Shop = new Cart();
            Shop.ID = count();
            Shop.List = new List<Product>();

            db.Carts.Add(Shop);
            db.SaveChanges();
        }
       /* [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(Guid id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.ID)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        } */

        // POST: api/Carts
        

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> DeleteCart(Guid id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            await db.SaveChangesAsync();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.ID == id) > 0;
        }
    }
}