namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers");
            DropPrimaryKey("dbo.Countries");
            DropPrimaryKey("dbo.KindsOfSuppliers");
            AlterColumn("dbo.Countries", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.KindsOfSuppliers", "KindsOfSupplierId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Countries", "CountryId");
            AddPrimaryKey("dbo.KindsOfSuppliers", "KindsOfSupplierId");
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers", "KindsOfSupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers");
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropPrimaryKey("dbo.KindsOfSuppliers");
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.KindsOfSuppliers", "KindsOfSupplierId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Countries", "CountryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.KindsOfSuppliers", "KindsOfSupplierId");
            AddPrimaryKey("dbo.Countries", "CountryId");
            AddForeignKey("dbo.Suppliers", "KindsOfSupplierId", "dbo.KindsOfSuppliers", "KindsOfSupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
