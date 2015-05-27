namespace Joker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOnToMany : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Jokes", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Jokes", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Jokes", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Jokes", name: "ApplicationUser_Id", newName: "ApplicationUserId");
        }
    }
}
