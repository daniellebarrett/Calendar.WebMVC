namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offsetagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointment", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointment", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointment", "EndTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Appointment", "StartTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
