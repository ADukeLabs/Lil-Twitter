namespace Joker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datatype_ToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jokes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Jokes", "ApplicationUserId");
            RenameColumn(table: "dbo.Jokes", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Jokes", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jokes", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jokes", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Jokes", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Jokes", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Jokes", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jokes", "ApplicationUser_Id");
        }
    }
}
