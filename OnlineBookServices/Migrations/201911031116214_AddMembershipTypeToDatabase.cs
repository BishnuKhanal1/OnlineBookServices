namespace OnlineBookServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SignUpFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChargeRateOneMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChargeRateSixMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}
