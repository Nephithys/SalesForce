namespace LandScaping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        AreaCode = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectSheets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Comments = c.String(),
                        client_ID = c.Int(),
                        service_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.client_ID)
                .ForeignKey("dbo.Services", t => t.service_ID)
                .Index(t => t.client_ID)
                .Index(t => t.service_ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Service = c.String(),
                        Rate = c.Double(nullable: false),
                        Acre = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectSheets", "service_ID", "dbo.Services");
            DropForeignKey("dbo.ProjectSheets", "client_ID", "dbo.Clients");
            DropIndex("dbo.ProjectSheets", new[] { "service_ID" });
            DropIndex("dbo.ProjectSheets", new[] { "client_ID" });
            DropTable("dbo.Services");
            DropTable("dbo.ProjectSheets");
            DropTable("dbo.Clients");
        }
    }
}
