using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DamacanaApi.Models
{
    public class Purchase
    {       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int userId { get; set; }
        public decimal totalammount { get; set; }
        public virtual ICollection<Purchase_Product> List { get; set; }

        public DateTime Date { get; set; }
    }
}