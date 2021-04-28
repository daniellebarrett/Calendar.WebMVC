namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkeyClientAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "ClientId", c => c.Int());
            CreateIndex("dbo.Appointment", "ClientId");
            AddForeignKey("dbo.Appointment", "ClientId", "dbo.Client", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "ClientId", "dbo.Client");
            DropIndex("dbo.Appointment", new[] { "ClientId" });
            DropColumn("dbo.Appointment", "ClientId");
        }
    }
}
