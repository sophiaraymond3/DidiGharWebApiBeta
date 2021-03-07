namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableUserAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAddresses", "City");
            DropColumn("dbo.UserAddresses", "Pincode");
            DropColumn("dbo.UserAddresses", "Country");
            DropColumn("dbo.UserAddresses", "State");
            RenameColumn(table: "dbo.UserAddresses", name: "City1_Id", newName: "City");
            RenameColumn(table: "dbo.UserAddresses", name: "Pincode1_Id", newName: "Pincode");
            RenameColumn(table: "dbo.UserAddresses", name: "Country1_Id", newName: "Country");
            RenameColumn(table: "dbo.UserAddresses", name: "State1_Id", newName: "State");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_City1_Id", newName: "IX_City");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_State1_Id", newName: "IX_State");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_Country1_Id", newName: "IX_Country");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_Pincode1_Id", newName: "IX_Pincode");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserAddresses", name: "IX_Pincode", newName: "IX_Pincode1_Id");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_Country", newName: "IX_Country1_Id");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_State", newName: "IX_State1_Id");
            RenameIndex(table: "dbo.UserAddresses", name: "IX_City", newName: "IX_City1_Id");
            RenameColumn(table: "dbo.UserAddresses", name: "State", newName: "State1_Id");
            RenameColumn(table: "dbo.UserAddresses", name: "Country", newName: "Country1_Id");
            RenameColumn(table: "dbo.UserAddresses", name: "Pincode", newName: "Pincode1_Id");
            RenameColumn(table: "dbo.UserAddresses", name: "City", newName: "City1_Id");
            AddColumn("dbo.UserAddresses", "State", c => c.Int());
            AddColumn("dbo.UserAddresses", "Country", c => c.Int());
            AddColumn("dbo.UserAddresses", "Pincode", c => c.Int());
            AddColumn("dbo.UserAddresses", "City", c => c.Int());
        }
    }
}
