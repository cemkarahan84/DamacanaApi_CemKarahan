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
    public class PurchasesController : ApiController
    {
        private DamacanaApiContext db = new DamacanaApiContext();

       
        // GET: /api/Purchases/5
        public IQueryable<PurchaseDTO> Get()
        {
            var Purch = from p in db.Purchases
                        select new PurchaseDTO()
                        {
                            Date=p.Date,
                           ID=p.ID,
                           totalammount=p.totalammount

                        };
            return Purch;
        }


        // POST: /api/Purchases/5
        public void Post(int C_Id)
        {
            Cart cart=db.Carts.Find(C_Id); //recherche cart

            Purchase purchases = new Purchase();// new purchase
            purchases.List=new List<Purchase_Product> ();//new list purchase
            

            purchases.Date = new DateTime();
            purchases.totalammount = cart.Total;
          
            var products = from p in cart.List
                           select new Purchase_Product
                           {
                               Id = p.Id,
                               Product = p.Product,
                               ProductId = p.ProductId,


                           };
            purchases.List = products.ToList();

            db.Purchases.Add(purchases);
            //db.Entry(purchases).State = EntityState.Modified;
            db.SaveChanges();



        }

        /*
        // GET: api/Purchases/{id}
        public PurchasesDetailDTO get(int P_ID)
        {

            Purchase purch= db.Purchases.Find(P_ID);
            PurchasesDetailDTO PDTO = new PurchasesDetailDTO();

            PDTO.ID = purch.ID;
            PDTO.Time = purch.Date;
            PDTO.Total = purch.totalammount;


            var Purchases = from p in purch.List
                            select new Product()
                            {
                                ID = p.ProductId,
                                Name = p.Product.Name,
                                Price = p.Product.Price
                            };


            return PDTO;
        } */
    }
}