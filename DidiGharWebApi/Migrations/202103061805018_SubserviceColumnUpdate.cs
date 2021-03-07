namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubserviceColumnUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubServices", "Duration", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubServices", "Duration", c => c.Int(nullable: false));
        }
    }
}
