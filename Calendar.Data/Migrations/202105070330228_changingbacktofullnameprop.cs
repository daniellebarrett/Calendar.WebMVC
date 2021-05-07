namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingbacktofullnameprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "FullName", c => c.String());
            AddColumn("dbo.Client", "FullName", c => c.String());
            DropColumn("dbo.Appointment", "ClientInfo");
            DropColumn("dbo.Client", "ClientInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "ClientInfo", c => c.String());
            AddColumn("dbo.Appointment", "ClientInfo", c => c.String());
            DropColumn("dbo.Client", "FullName");
            DropColumn("dbo.Appointment", "FullName");
        }
    }
}
