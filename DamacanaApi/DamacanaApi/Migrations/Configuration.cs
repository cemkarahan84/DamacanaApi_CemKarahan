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

                new Product (){ ID=new Guid(),Name="test",Price=10}
                 
                
             );
        }
    }
}
