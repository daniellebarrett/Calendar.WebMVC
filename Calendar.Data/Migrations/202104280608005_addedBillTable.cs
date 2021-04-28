namespace Calendar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBillTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        BillingID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        BillStatus = c.Boolean(nullable: false),
                        BillAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BillingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bill");
        }
    }
}
