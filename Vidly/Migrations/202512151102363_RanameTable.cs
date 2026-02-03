namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RanameTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "SignUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "PayAsYouGo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "PayAsYouGo", c => c.Short(nullable: false));
            DropColumn("dbo.MemberShipTypes", "SignUpFree");
        }
    }
}
