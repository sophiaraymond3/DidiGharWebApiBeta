namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubserviceRenameColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubServices", "Name", c => c.String());
            DropColumn("dbo.SubServices", "SubCategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubServices", "SubCategoryName", c => c.String());
            DropColumn("dbo.SubServices", "Name");
        }
    }
}
