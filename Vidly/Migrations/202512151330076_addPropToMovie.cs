namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RelaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberOfStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberOfStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "RelaseDate");
        }
    }
}
