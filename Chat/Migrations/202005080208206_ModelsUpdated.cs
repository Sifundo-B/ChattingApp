namespace Chat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Replies", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.Replies", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            CreateIndex("dbo.Replies", "UserId");
            AddForeignKey("dbo.Replies", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "UserId" });
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Replies", "UserId");
            DropColumn("dbo.Replies", "CreatedOn");
            DropColumn("dbo.Comments", "CreatedOn");
        }
    }
}
