namespace OnlineBookServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpellingUpdateToUsersPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            DropColumn("dbo.AspNetUsers", "PhoneName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PhoneName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
