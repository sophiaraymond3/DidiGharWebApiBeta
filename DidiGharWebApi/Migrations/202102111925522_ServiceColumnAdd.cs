namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceColumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Image");
        }
    }
}
