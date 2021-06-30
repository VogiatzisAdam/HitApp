namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCountryAndKindsOfSupplier : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO COUNTRIES (Name) VALUES ('Greece')");
            Sql("INSERT INTO COUNTRIES (Name) VALUES ('China')");
            Sql("INSERT INTO COUNTRIES (Name) VALUES ('Russia')");
            Sql("INSERT INTO COUNTRIES (Name) VALUES ('India')");
            Sql("INSERT INTO COUNTRIES (Name) VALUES ('Brazil')");
            Sql("INSERT INTO KINDSOFSUPPLIERS (Heading) VALUES ('Food-Supplier')");
            Sql("INSERT INTO KINDSOFSUPPLIERS (Heading) VALUES ('Merchandise-Supplier')");
            Sql("INSERT INTO KINDSOFSUPPLIERS (Heading) VALUES ('Service-Supplier')");
            
        }
        
        public override void Down()
        {
            Sql("DELETE FROM COUNTRIES WHERE CountryId IN (1,2,3,4,5)");
            Sql("DELETE FROM KINDSOFSUPPLIERS WHERE KindsOfSupplierId IN (1,2,3)");
        }
    }
}
