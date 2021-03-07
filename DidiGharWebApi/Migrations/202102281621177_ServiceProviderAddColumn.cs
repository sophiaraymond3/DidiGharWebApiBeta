namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceProviderAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviders", "ServiceId", c => c.Int());
            CreateIndex("dbo.ServiceProviders", "ServiceId");
            AddForeignKey("dbo.ServiceProviders", "ServiceId", "dbo.Services", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceProviders", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceProviders", new[] { "ServiceId" });
            DropColumn("dbo.ServiceProviders", "ServiceId");
        }
    }
}
