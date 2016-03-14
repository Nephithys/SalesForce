namespace LandScaping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "UserID", c => c.String());
            AddColumn("dbo.Jobs", "applicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "applicationUser_Id");
            AddForeignKey("dbo.Jobs", "applicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "applicationUser_Id" });
            DropColumn("dbo.Jobs", "applicationUser_Id");
            DropColumn("dbo.Jobs", "UserID");
        }
    }
}
