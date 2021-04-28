namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointment", "AppointmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointment", "AppointmentDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
