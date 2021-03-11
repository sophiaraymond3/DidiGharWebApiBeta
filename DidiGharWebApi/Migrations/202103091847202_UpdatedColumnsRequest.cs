namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedColumnsRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "StartedOnUtc", c => c.DateTime());
            AddColumn("dbo.Requests", "EstimatedDuration", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Requests", "TotalCost", c => c.Long(nullable: false));
            DropColumn("dbo.Requests", "TimeSlotsUtc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "TimeSlotsUtc", c => c.DateTime());
            DropColumn("dbo.Requests", "TotalCost");
            DropColumn("dbo.Requests", "EstimatedDuration");
            DropColumn("dbo.Requests", "StartedOnUtc");
        }
    }
}
