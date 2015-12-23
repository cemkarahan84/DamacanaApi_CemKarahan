using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaApi.Models
{
    public class Cart_Product
    {
       
            public int Id { get; set; }

          
            
            public int Amount { get; set; }
           


            
           
            public int ProductId { get; set; }
            public virtual Product Product { get; set; }

            
            public int CartId { get; set; }
           // public virtual Cart Cart { get; set; }


        
    }
}