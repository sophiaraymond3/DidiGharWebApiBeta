namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SErviceColumnUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubServices", "Plan", c => c.String());
            AddColumn("dbo.SubServices", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.SubServices", "SubCategoryName", c => c.String());
            DropColumn("dbo.SubServices", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubServices", "Name", c => c.String());
            DropColumn("dbo.SubServices", "SubCategoryName");
            DropColumn("dbo.SubServices", "Duration");
            DropColumn("dbo.SubServices", "Plan");
        }
    }
}
