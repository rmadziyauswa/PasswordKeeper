namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsToHostTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostTypes", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.HostTypes", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostTypes", "Description", c => c.String());
            AlterColumn("dbo.HostTypes", "Name", c => c.String());
        }
    }
}
