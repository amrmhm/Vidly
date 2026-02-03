namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MemberShipTypes(Id ,SignUpFree ,DurationInMonth ,DiscountRate) Values (1, 0 ,0 ,0)");
            Sql("Insert Into MemberShipTypes(Id ,SignUpFree ,DurationInMonth ,DiscountRate) Values (2, 30 ,3 ,10)");
            Sql("Insert Into MemberShipTypes(Id ,SignUpFree ,DurationInMonth ,DiscountRate) Values (3, 90 ,6 ,15)");
            Sql("Insert Into MemberShipTypes(Id ,SignUpFree ,DurationInMonth ,DiscountRate) Values (4, 300 ,12 ,30)");
        }
        
        public override void Down()
        {
            Sql("Delete from MemberShipTypes");
        }
    }
}
