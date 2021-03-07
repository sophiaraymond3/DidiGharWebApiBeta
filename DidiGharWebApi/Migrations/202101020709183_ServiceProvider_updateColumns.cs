namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceProvider_updateColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceProviders", "City");
            DropColumn("dbo.ServiceProviders", "Pincode");
            DropColumn("dbo.ServiceProviders", "Country");
            DropColumn("dbo.ServiceProviders", "State");
            RenameColumn(table: "dbo.ServiceProviders", name: "Gender_Id", newName: "Gender");
            RenameColumn(table: "dbo.ServiceProviders", name: "City1_Id", newName: "City");
            RenameColumn(table: "dbo.ServiceProviders", name: "Pincode1_Id", newName: "Pincode");
            RenameColumn(table: "dbo.ServiceProviders", name: "Country1_Id", newName: "Country");
            RenameColumn(table: "dbo.ServiceProviders", name: "State1_Id", newName: "State");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_City1_Id", newName: "IX_City");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Country1_Id", newName: "IX_Country");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Gender_Id", newName: "IX_Gender");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Pincode1_Id", newName: "IX_Pincode");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_State1_Id", newName: "IX_State");
            DropColumn("dbo.ServiceProviders", "Genders");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProviders", "Genders", c => c.Int());
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_State", newName: "IX_State1_Id");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Pincode", newName: "IX_Pincode1_Id");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Gender", newName: "IX_Gender_Id");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Country", newName: "IX_Country1_Id");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_City", newName: "IX_City1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "State", newName: "State1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "Country", newName: "Country1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "Pincode", newName: "Pincode1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "City", newName: "City1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "Gender", newName: "Gender_Id");
            AddColumn("dbo.ServiceProviders", "State", c => c.Int());
            AddColumn("dbo.ServiceProviders", "Country", c => c.Int());
            AddColumn("dbo.ServiceProviders", "Pincode", c => c.Int());
            AddColumn("dbo.ServiceProviders", "City", c => c.Int());
        }
    }
}
