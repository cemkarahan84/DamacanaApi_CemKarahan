namespace DamacanaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        totalammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Purchase_Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchase_Product", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Cart_Product", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchase_Product", new[] { "PurchaseId" });
            DropIndex("dbo.Purchase_Product", new[] { "ProductId" });
            DropIndex("dbo.Cart_Product", new[] { "CartId" });
            DropIndex("dbo.Cart_Product", new[] { "ProductId" });
            DropTable("dbo.Purchase_Product");
            DropTable("dbo.Purchases");
            DropTable("dbo.Carts");
            DropTable("dbo.Products");
            DropTable("dbo.Cart_Product");
        }
    }
}
