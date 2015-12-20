using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamacanaApi.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int userId { get; set; }
        public decimal totalammount { get; set; }
        public virtual List<Product> List { get; set; }

        public DateTime Date { get; set; }
    }
}