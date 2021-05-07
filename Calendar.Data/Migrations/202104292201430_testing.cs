namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointment", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Bill", "ClientId", "dbo.Client");
            DropIndex("dbo.Appointment", new[] { "ClientId" });
            DropIndex("dbo.Bill", new[] { "ClientId" });
            AlterColumn("dbo.Appointment", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bill", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointment", "ClientId");
            CreateIndex("dbo.Bill", "ClientId");
            AddForeignKey("dbo.Appointment", "ClientId", "dbo.Client", "ClientID", cascadeDelete: true);
            AddForeignKey("dbo.Bill", "ClientId", "dbo.Client", "ClientID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bill", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Appointment", "ClientId", "dbo.Client");
            DropIndex("dbo.Bill", new[] { "ClientId" });
            DropIndex("dbo.Appointment", new[] { "ClientId" });
            AlterColumn("dbo.Bill", "ClientId", c => c.Int());
            AlterColumn("dbo.Appointment", "ClientId", c => c.Int());
            CreateIndex("dbo.Bill", "ClientId");
            CreateIndex("dbo.Appointment", "ClientId");
            AddForeignKey("dbo.Bill", "ClientId", "dbo.Client", "ClientID");
            AddForeignKey("dbo.Appointment", "ClientId", "dbo.Client", "ClientID");
        }
    }
}
