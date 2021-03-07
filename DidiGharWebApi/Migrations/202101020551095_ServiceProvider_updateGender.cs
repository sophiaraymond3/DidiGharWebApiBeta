namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServiceProvider_updateGender : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ServiceProviders", name: "Gender1_Id", newName: "Gender_Id");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Gender1_Id", newName: "IX_Gender_Id");
            AddColumn("dbo.ServiceProviders", "Genders", c => c.Int());
            DropColumn("dbo.ServiceProviders", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProviders", "Gender", c => c.Int());
            DropColumn("dbo.ServiceProviders", "Genders");
            RenameIndex(table: "dbo.ServiceProviders", name: "IX_Gender_Id", newName: "IX_Gender1_Id");
            RenameColumn(table: "dbo.ServiceProviders", name: "Gender_Id", newName: "Gender1_Id");
        }
    }
}
