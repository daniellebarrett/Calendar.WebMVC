namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttorneyReg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Address", c => c.String(nullable: false));
        }
    }
}
