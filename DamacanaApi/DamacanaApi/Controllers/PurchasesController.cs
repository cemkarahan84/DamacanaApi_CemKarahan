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


        // GET: api/Purchases/
        [ResponseType(typeof(PurchaseDTO))]
        [HttpGet]
        public IQueryable<PurchaseDTO> GetPurchases()
        {
            var Purch = from p in db.Purchases
                        select new PurchaseDTO()
                        {
                            Date = p.Date,
                            ID = p.ID,
                            totalammount = p.totalammount

                        };
            return Purch;
        }

        //Get api/Purchases/{P_ID}
        [ResponseType(typeof(PurchasesDetailDTO))][HttpGet]
        public PurchasesDetailDTO PurchaseDetail(int P_ID)
        {

            Purchase purch = db.Purchases.Find(P_ID);
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


            PDTO.List = Purchases.ToList();
            return PDTO;
        }

        /********************************/

        // POST: api/Purchases/{CID}
        [HttpPost]
        public void POST(int CID)
        {
            Cart cart = db.Carts.Find(CID); //recherche cart

            Purchase purchases = new Purchase();// new purchase
            purchases.Date = DateTime.Now;


            purchases.totalammount = cart.Total;

            purchases.List = new List<Purchase_Product>();//new list purchase

            foreach (Cart_Product cp in cart.List)
            {
                Purchase_Product PP = new Purchase_Product();

                PP.CartId = cp.CartId;
                PP.ProductId = cp.ProductId;
                PP.PurchaseId = purchases.ID;
                PP.Product = cp.Product;
                purchases.List.Add(PP);
                db.PurchasesProducts.Add(PP);

            }



            db.Purchases.Add(purchases);


            db.SaveChanges();



        }
    }
}