namespace OnlineBookServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookServiceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        BookId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        ScheduledEndDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        AdditionalCharge = c.Double(),
                        RentalPrice = c.Double(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        RentalDuration = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookServices");
        }
    }
}
