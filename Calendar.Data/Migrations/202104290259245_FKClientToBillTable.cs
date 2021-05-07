namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKClientToBillTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "ClientId", c => c.Int());
            CreateIndex("dbo.Bill", "ClientId");
            AddForeignKey("dbo.Bill", "ClientId", "dbo.Client", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bill", "ClientId", "dbo.Client");
            DropIndex("dbo.Bill", new[] { "ClientId" });
            DropColumn("dbo.Bill", "ClientId");
        }
    }
}
