namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEmailToHost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hosts", "UserEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hosts", "UserEmail");
        }
    }
}
