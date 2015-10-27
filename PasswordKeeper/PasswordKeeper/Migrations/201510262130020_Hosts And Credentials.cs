namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostsAndCredentials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CredentialTypeID = c.Int(nullable: false),
                        HostID = c.Int(nullable: false),
                        Password = c.String(),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CredentialTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HostTypeID = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HostTypes", t => t.HostTypeID, cascadeDelete: true)
                .Index(t => t.HostTypeID);
            
            CreateTable(
                "dbo.HostTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hosts", "HostTypeID", "dbo.HostTypes");
            DropIndex("dbo.Hosts", new[] { "HostTypeID" });
            DropTable("dbo.HostTypes");
            DropTable("dbo.Hosts");
            DropTable("dbo.CredentialTypes");
            DropTable("dbo.Credentials");
        }
    }
}
