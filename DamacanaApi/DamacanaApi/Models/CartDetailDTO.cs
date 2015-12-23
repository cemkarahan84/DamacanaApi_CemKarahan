using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaApi.Models
{
    public class CartDetailDTO
    {
        public int ID { get; set; }
        public int userId { get; set; }
        public virtual ICollection<Product> List { get; set; }
        public decimal Total { get; set; }
    }
}