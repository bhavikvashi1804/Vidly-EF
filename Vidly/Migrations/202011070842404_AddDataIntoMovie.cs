namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataIntoMovie : DbMigration
    {
        public override void Up()
        {
           
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ( '3 Idiots',3,2019-10-10, 2019-10-10,5)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ( 'Race',1,2019-10-10, 2019-10-10,10)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ( 'Toy story',3,2019-10-10, 2019-10-10,15)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ( 'Raaz',1,2019-10-10, 2019-10-10,7)");
        }
        
        public override void Down()
        {
        }
    }
}
