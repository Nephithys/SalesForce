namespace LandScaping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Service = c.String(),
                        Rate = c.Double(nullable: false),
                        Acre = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Comments = c.String(),
                        client_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.client_ID)
                .Index(t => t.client_ID);
            
            AddColumn("dbo.Clients", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "client_ID", "dbo.Clients");
            DropIndex("dbo.Jobs", new[] { "client_ID" });
            DropColumn("dbo.Clients", "UserID");
            DropTable("dbo.Jobs");
        }
    }
}
