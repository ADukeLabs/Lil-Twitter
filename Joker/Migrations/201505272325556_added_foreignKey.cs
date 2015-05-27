namespace Joker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_foreignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jokes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jokes", "ApplicationUser_Id");
            AddForeignKey("dbo.Jokes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jokes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Jokes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Jokes", "ApplicationUser_Id");
        }
    }
}
