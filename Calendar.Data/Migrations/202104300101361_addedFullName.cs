namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "FullName");
        }
    }
}
