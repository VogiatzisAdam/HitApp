namespace HitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO USERS (UserId,UserName,PassWord) VALUES(1,'Takis Stamatiou','12345')");
            Sql("INSERT INTO USERS (UserId,UserName,PassWord) VALUES(2,'Maria Stamatiou','54321')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM USERS WHERE UserId IN (1,2)");
        }
    }
}
