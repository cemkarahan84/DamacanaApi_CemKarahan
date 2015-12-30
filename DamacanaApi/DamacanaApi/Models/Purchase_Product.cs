using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaApi.Models
{
    public class Purchase_Product
    {
        public int Id { get; set; }


       

        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CartId { get; set; }
        public int PurchaseId { get; set; }

    }
}