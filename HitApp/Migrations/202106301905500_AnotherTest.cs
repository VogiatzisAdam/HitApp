namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherTest : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Suppliers", "KindsOfSupplierId");
            CreateIndex("dbo.Suppliers", "CountryId");
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers", "KindsOfSupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "KindsOfSupplierId" });
        }
    }
}
