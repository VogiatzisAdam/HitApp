namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAgainLookupAndAgainandAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers");
            DropIndex("dbo.Suppliers", new[] { "KindsOfSupplierId" });
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Suppliers", "CountryId");
            CreateIndex("dbo.Suppliers", "KindsOfSupplierId");
            AddForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers", "KindsOfSupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
