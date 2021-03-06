﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DamacanaApi.Models
{
    public class DamacanaApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DamacanaApiContext() : base("name=DamacanaApiContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<DamacanaApi.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<DamacanaApi.Models.Cart> Carts { get; set; }
        public System.Data.Entity.DbSet<DamacanaApi.Models.Cart_Product> CartProducts { get; set; }
        public System.Data.Entity.DbSet<DamacanaApi.Models.Purchase> Purchases { get; set; }
        public System.Data.Entity.DbSet<DamacanaApi.Models.Purchase_Product> PurchasesProducts { get; set; }
        
    
    }

    
}
