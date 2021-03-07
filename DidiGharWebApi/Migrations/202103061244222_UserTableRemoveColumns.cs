namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableRemoveColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "City", "dbo.Cities");
            DropForeignKey("dbo.Users", "Country", "dbo.Countries");
            DropForeignKey("dbo.Users", "Pincode", "dbo.Pincodes");
            DropForeignKey("dbo.Users", "State", "dbo.States");
            DropIndex("dbo.Users", new[] { "City" });
            DropIndex("dbo.Users", new[] { "Country" });
            DropIndex("dbo.Users", new[] { "State" });
            DropIndex("dbo.Users", new[] { "Pincode" });
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Pincode");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "Address1");
            DropColumn("dbo.Users", "Address2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address2", c => c.String());
            AddColumn("dbo.Users", "Address1", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Pincode", c => c.Int());
            AddColumn("dbo.Users", "State", c => c.Int());
            AddColumn("dbo.Users", "Country", c => c.Int());
            AddColumn("dbo.Users", "City", c => c.Int());
            CreateIndex("dbo.Users", "Pincode");
            CreateIndex("dbo.Users", "State");
            CreateIndex("dbo.Users", "Country");
            CreateIndex("dbo.Users", "City");
            AddForeignKey("dbo.Users", "State", "dbo.States", "Id");
            AddForeignKey("dbo.Users", "Pincode", "dbo.Pincodes", "Id");
            AddForeignKey("dbo.Users", "Country", "dbo.Countries", "Id");
            AddForeignKey("dbo.Users", "City", "dbo.Cities", "Id");
        }
    }
}
