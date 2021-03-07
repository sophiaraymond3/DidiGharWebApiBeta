namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "Requester");
            DropColumn("dbo.Requests", "AssignedTo");
            DropColumn("dbo.Requests", "AddressId");
            DropColumn("dbo.Requests", "Status");
            RenameColumn(table: "dbo.Requests", name: "User_Id", newName: "Requester");
            RenameColumn(table: "dbo.Requests", name: "ServiceProvider_Id", newName: "AssignedTo");
            RenameColumn(table: "dbo.Requests", name: "UserAddress_Id", newName: "AddressId");
            RenameColumn(table: "dbo.Requests", name: "RequestsStatus_Id", newName: "Status");
            RenameIndex(table: "dbo.Requests", name: "IX_User_Id", newName: "IX_Requester");
            RenameIndex(table: "dbo.Requests", name: "IX_UserAddress_Id", newName: "IX_AddressId");
            RenameIndex(table: "dbo.Requests", name: "IX_ServiceProvider_Id", newName: "IX_AssignedTo");
            RenameIndex(table: "dbo.Requests", name: "IX_RequestsStatus_Id", newName: "IX_Status");
            AddColumn("dbo.Users", "City", c => c.Int());
            AddColumn("dbo.Users", "Country", c => c.Int());
            AddColumn("dbo.Users", "State", c => c.Int());
            AddColumn("dbo.Users", "Pincode", c => c.Int());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Address1", c => c.String());
            AddColumn("dbo.Users", "Address2", c => c.String());
            CreateIndex("dbo.Users", "City");
            CreateIndex("dbo.Users", "Country");
            CreateIndex("dbo.Users", "State");
            CreateIndex("dbo.Users", "Pincode");
            AddForeignKey("dbo.Users", "City", "dbo.Cities", "Id");
            AddForeignKey("dbo.Users", "Country", "dbo.Countries", "Id");
            AddForeignKey("dbo.Users", "Pincode", "dbo.Pincodes", "Id");
            AddForeignKey("dbo.Users", "State", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "State", "dbo.States");
            DropForeignKey("dbo.Users", "Pincode", "dbo.Pincodes");
            DropForeignKey("dbo.Users", "Country", "dbo.Countries");
            DropForeignKey("dbo.Users", "City", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Pincode" });
            DropIndex("dbo.Users", new[] { "State" });
            DropIndex("dbo.Users", new[] { "Country" });
            DropIndex("dbo.Users", new[] { "City" });
            DropColumn("dbo.Users", "Address2");
            DropColumn("dbo.Users", "Address1");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "Pincode");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "City");
            RenameIndex(table: "dbo.Requests", name: "IX_Status", newName: "IX_RequestsStatus_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_AssignedTo", newName: "IX_ServiceProvider_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_AddressId", newName: "IX_UserAddress_Id");
            RenameIndex(table: "dbo.Requests", name: "IX_Requester", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Requests", name: "Status", newName: "RequestsStatus_Id");
            RenameColumn(table: "dbo.Requests", name: "AddressId", newName: "UserAddress_Id");
            RenameColumn(table: "dbo.Requests", name: "AssignedTo", newName: "ServiceProvider_Id");
            RenameColumn(table: "dbo.Requests", name: "Requester", newName: "User_Id");
            AddColumn("dbo.Requests", "Status", c => c.Int());
            AddColumn("dbo.Requests", "AddressId", c => c.Int());
            AddColumn("dbo.Requests", "AssignedTo", c => c.Int());
            AddColumn("dbo.Requests", "Requester", c => c.Int());
        }
    }
}
