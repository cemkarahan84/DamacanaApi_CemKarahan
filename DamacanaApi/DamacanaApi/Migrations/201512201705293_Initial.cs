namespace DamacanaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cart_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carts", t => t.Cart_ID)
                .Index(t => t.Cart_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_ID", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
