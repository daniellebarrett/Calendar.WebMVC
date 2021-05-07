namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedclientinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "ClientInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "ClientInfo");
        }
    }
}
