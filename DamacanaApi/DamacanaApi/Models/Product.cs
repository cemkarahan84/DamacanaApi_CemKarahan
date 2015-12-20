using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DamacanaApi.Models
{
    public class Product
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }



   
}