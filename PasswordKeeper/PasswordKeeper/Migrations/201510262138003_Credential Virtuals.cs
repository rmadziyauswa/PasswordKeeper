namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CredentialVirtuals : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Credentials", "CredentialTypeID");
            CreateIndex("dbo.Credentials", "HostID");
            AddForeignKey("dbo.Credentials", "CredentialTypeID", "dbo.CredentialTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Credentials", "HostID", "dbo.Hosts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credentials", "HostID", "dbo.Hosts");
            DropForeignKey("dbo.Credentials", "CredentialTypeID", "dbo.CredentialTypes");
            DropIndex("dbo.Credentials", new[] { "HostID" });
            DropIndex("dbo.Credentials", new[] { "CredentialTypeID" });
        }
    }
}
