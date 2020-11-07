namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET DOB = CAST('1998-04-18' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
