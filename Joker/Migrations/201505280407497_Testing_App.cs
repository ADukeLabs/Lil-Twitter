namespace Joker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing_App : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jokes", "JokeTitle", c => c.String(nullable: false, maxLength: 140));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jokes", "JokeTitle", c => c.String());
        }
    }
}
