namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        PlacementId = c.Int(nullable: false),
                        StudentName = c.String(),
                        Company = c.String(),
                        PlacementYear = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);


            Sql("Insert into Students values (1,'Bhavik','CTS','2020')");
            Sql("Insert into Students values (2,'Tejoy','TCS','2021')");
            Sql("Insert into Students values (3,'Raj','Cap','2020')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
