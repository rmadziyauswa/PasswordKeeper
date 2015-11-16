namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionOfUserEmailToCredentials : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "UserEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "UserEmail");
        }
    }
}
