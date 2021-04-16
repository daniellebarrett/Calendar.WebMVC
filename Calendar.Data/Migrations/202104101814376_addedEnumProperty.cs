namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEnumProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "TypeOfAppointment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointment", "TypeOfAppointment");
        }
    }
}
