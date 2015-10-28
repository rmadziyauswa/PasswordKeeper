namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CredentialTypeFromPasswordKeeper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credentials", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credentials", "Name");
        }
    }
}
