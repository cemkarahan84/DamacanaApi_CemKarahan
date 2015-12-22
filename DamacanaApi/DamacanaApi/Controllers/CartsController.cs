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
        public IQueryable<CartDTO> GetCarts()
        {
            var Carts = from c in db.Carts
                        select new CartDTO()
                        {
                            ID = c.ID,
                            List = c.List,
                            Total = c.Total
                        };
            return Carts;
        }

        

        // PUT: api/Carts/5 {ProductId, CartId}

        public void Put (int ProductId, int CartId)
        {



              Product tmp = db.Products.Find(ProductId);

            Cart tmp2 = db.Carts.Find(CartId);

            tmp2.List.Add(tmp);

        
            
                db.SaveChanges(); //Sauvegarde de la BDD
            
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



        // GET: api/Carts{id}
        public Cart Get(int id)
        {

            return db.Carts.Find(id);
        }



       

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