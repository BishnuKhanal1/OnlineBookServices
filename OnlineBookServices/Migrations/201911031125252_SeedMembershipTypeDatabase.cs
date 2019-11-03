namespace OnlineBookServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[MembershipTypes](Name, SignUpFee, ChargeRateSixMonth, ChargeRateOneMonth, SellingPrice) VALUES ('Pay Per Rental', 0, 50, 25, 95)" );
            Sql("INSERT INTO [dbo].[MembershipTypes](Name, SignUpFee, ChargeRateSixMonth, ChargeRateOneMonth, SellingPrice) VALUES ('Member', 150, 20, 10, 90)");
            Sql("INSERT INTO [dbo].[MembershipTypes](Name, SignUpFee, ChargeRateSixMonth, ChargeRateOneMonth, SellingPrice) VALUES ('SuperAdmin', 0, 0, 0, 90)");
            Sql("INSERT INTO [dbo].[MembershipTypes](Name, SignUpFee, ChargeRateSixMonth, ChargeRateOneMonth, SellingPrice) VALUES ('Purchasing Customer', 0, 0, 0, 100)");

        }

        public override void Down()
        {
        }
    }
}
