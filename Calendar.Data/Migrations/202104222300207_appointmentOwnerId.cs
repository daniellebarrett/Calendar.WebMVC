namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appointmentOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "OwnerID");
        }
    }
}
