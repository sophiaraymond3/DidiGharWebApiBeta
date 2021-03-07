namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceProvider_addColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviders", "UserCrerdsId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ServiceProviders", "UserCrerdsId");
            AddForeignKey("dbo.ServiceProviders", "UserCrerdsId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProviders", "UserCrerdsId", "dbo.AspNetUsers");
            DropIndex("dbo.ServiceProviders", new[] { "UserCrerdsId" });
            DropColumn("dbo.ServiceProviders", "UserCrerdsId");
        }
    }
}
