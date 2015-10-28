namespace PasswordKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordKeeperBaseClassNameAddition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HostTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HostTypes", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
