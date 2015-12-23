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
                           
                            Total = c.Total
                        };
            return Carts;
        }

        

        // PUT: api/Carts
        public void  Put (int ProductId, int CartId)
        {
            Cart_Product CP = new Cart_Product();
            Cart cart = db.Carts.Find(CartId);
            Product product = db.Products.Find(ProductId);

            //CP.Cart = cart;
            CP.CartId = cart.ID;

            CP.Product = product;
            CP.ProductId = product.ID;

            cart.List.Add(CP);

            cart.Total += product.Price;
            
            db.Carts.Add(cart);




            db.Entry(cart).State = EntityState.Modified;
            
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
            Shop.List = new List<Cart_Product>();

            db.Carts.Add(Shop);
            db.SaveChanges();
        }

        
    
        // GET: api/Carts/{id}
        public CartDetailDTO Get(int Id)
        {
            Cart cart = db.Carts.Find(Id);

            CartDetailDTO CDD = new CartDetailDTO();

            CDD.ID = cart.ID;
            CDD.Total = cart.Total;
            

            var Carts = from c in cart.List
                        select new Product()
                        {
                            ID=c.ProductId,
                            Name=c.Product.Name,
                           Price=c.Product.Price
                        };

            CDD.List = Carts.ToList();
            
            return CDD;
        }



       

       

       
    }
}