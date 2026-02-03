namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovie : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies On");
            Sql("Insert into Movies (Id,Name,RelaseDate,DateAdded,NumberOfStock,GenreId) Values(1,'Hangrover','1999-01-01 00:00:00.000','1999-01-01 00:00:00.000',2,1)");
            Sql("Insert into Movies (Id,Name,RelaseDate,DateAdded,NumberOfStock,GenreId) Values(2,'THeStory','1999-01-01 00:00:00.000','1999-01-01 00:00:00.000',4,3)");
            Sql("Insert into Movies (Id,Name,RelaseDate,DateAdded,NumberOfStock,GenreId) Values(3,'Tatanic','1999-01-01 00:00:00.000','1999-01-01 00:00:00.000',6,2)");
            Sql("Insert into Movies (Id,Name,RelaseDate,DateAdded,NumberOfStock,GenreId) Values(4,'Charly','1999-01-01 00:00:00.000','1999-01-01 00:00:00.000',5,4)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }

        public override void Down()
        {
            Sql("Delete from Movies");
        }
    }
}
