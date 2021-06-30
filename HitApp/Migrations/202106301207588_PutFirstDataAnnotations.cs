namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutFirstDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.KindsOfSuppliers", "Heading", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Suppliers", "TIN", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Suppliers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Suppliers", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Suppliers", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
            AlterColumn("dbo.Suppliers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Suppliers", "TIN", c => c.String());
            AlterColumn("dbo.Suppliers", "Name", c => c.String());
            AlterColumn("dbo.KindsOfSuppliers", "Heading", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
        }
    }
}
