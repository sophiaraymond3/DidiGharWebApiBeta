namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pincode_UpdateColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pincodes", "PinCode", c => c.Int());
            DropColumn("dbo.Pincodes", "PinCode1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pincodes", "PinCode1", c => c.Int());
            DropColumn("dbo.Pincodes", "PinCode");
        }
    }
}
