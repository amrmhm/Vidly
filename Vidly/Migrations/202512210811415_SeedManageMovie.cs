namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedManageMovie : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e5a1a6f-b298-42ed-a997-6f737df8438e', N'guest@vidly.com', 0, N'AFPZJ+dZOWcRPcIdbrQUhu0Us/0/ycdpRAuGTsvd8TGOH09UbKbBz0ZNG/mK006DZA==', N'93d3b19a-4e75-4629-9ef3-5e5ed3272102', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'51fe153b-4d64-448a-b6be-69f92c563fdc', N'admin@vidly.com', 0, N'AN/FGrwZerW60XoIuBaHwHCto4kiFhVEP8hlRjb0vrxO1AEllDIdJQY7dBuuDn5dJA==', N'a7eafc62-4374-42ac-ba2d-ee4d7241ffdf', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'48e2ea89-b119-4c3a-a571-a71507ca1477', N'CanManageMovie')

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'51fe153b-4d64-448a-b6be-69f92c563fdc', N'48e2ea89-b119-4c3a-a571-a71507ca1477')


");
        }
        
        public override void Down()
        {
            Sql(@"Delete From [dbo].[AspNetUsers] ;

Delete From [dbo].[AspNetRoles] Where Id ='48e2ea89-b119-4c3a-a571-a71507ca1477' ;
Delete From [dbo].[AspNetUserRoles] Where UserId = '51fe153b-4d64-448a-b6be-69f92c563fdc'"); ;
        }
    }
}
