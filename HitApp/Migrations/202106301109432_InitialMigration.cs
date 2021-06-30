namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.KindsOfSuppliers",
                c => new
                    {
                        KindsOfSupplierId = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KindsOfSupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KindsOfSupplierId = c.Int(nullable: false),
                        TIN = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CountryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.KindsOfSuppliers", t => t.KindsOfSupplierId, cascadeDelete: true)
                .Index(t => t.KindsOfSupplierId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "KindsOfSupplierId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.KindsOfSuppliers");
            DropTable("dbo.Countries");
        }
    }
}
