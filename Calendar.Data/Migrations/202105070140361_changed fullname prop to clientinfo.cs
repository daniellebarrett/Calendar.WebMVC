namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedfullnameproptoclientinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "ClientInfo", c => c.String());
            DropColumn("dbo.Client", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "FullName", c => c.String());
            DropColumn("dbo.Client", "ClientInfo");
        }
    }
}
