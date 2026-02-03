namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNumberofAvalible : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies set NumberAvalibable = NumberOfStock");
        }
        
        public override void Down()
        {
            Sql("delete NumberAvalibable from Movies");

        }
    }
}
