namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovie : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id ,Name) Values (1, 'Comdy')");
            Sql("Insert Into Genres (Id ,Name) Values (2, 'Action')");
            Sql("Insert Into Genres (Id ,Name) Values (3, 'Romancy')");
            Sql("Insert Into Genres (Id ,Name) Values (4, 'Family')");
        }
        
        public override void Down()
        {
            Sql("Delete from Genres");

        }
    }
}
