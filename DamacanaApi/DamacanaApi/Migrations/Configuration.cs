using DamacanaApi.Models;

namespace DamacanaApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DamacanaApi.Models.DamacanaApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DamacanaApi.Models.DamacanaApiContext";
        }

        protected override void Seed(DamacanaApi.Models.DamacanaApiContext context)
        {
            context.Products.AddOrUpdate(x => x.ID,

                new Product (){ ID=1,Name="Evian",Price=10},
                new Product (){ ID=2,Name="Hayat",Price=9} ,
                new Product (){ ID=3,Name="Nestle",Price=13}
             );

          
        }
    }
}
