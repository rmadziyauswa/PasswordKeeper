namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatemodifiedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credentials", "DateModified", c => c.DateTime());
            AlterColumn("dbo.CredentialTypes", "DateModified", c => c.DateTime());
            AlterColumn("dbo.Hosts", "DateModified", c => c.DateTime());
            AlterColumn("dbo.HostTypes", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostTypes", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Hosts", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CredentialTypes", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Credentials", "DateModified", c => c.DateTime(nullable: false));
        }
    }
}
