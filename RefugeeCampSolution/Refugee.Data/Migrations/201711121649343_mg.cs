namespace Refugee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "AdminID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Partners", "AdminID");
            AddForeignKey("dbo.Partners", "AdminID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partners", "AdminID", "dbo.AspNetUsers");
            DropIndex("dbo.Partners", new[] { "AdminID" });
            DropColumn("dbo.Partners", "AdminID");
        }
    }
}
