namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNameToMeberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes set Name = 'PayAsYouGo' Where Id = 1");
            Sql("Update MemberShipTypes set Name = 'Monthly' Where Id = 2");
            Sql("Update MemberShipTypes set Name = 'Quartly' Where Id = 3");
            Sql("Update MemberShipTypes set Name = 'Yearly' Where Id = 4");
        }
        
        public override void Down()
        {
            Sql("delete Name from MemberShipTypes where id =1");
            Sql("delete Name from MemberShipTypes where id =2");
            Sql("delete Name from MemberShipTypes where id =3");
            Sql("delete Name from MemberShipTypes where id =4");
        }
    }
}
