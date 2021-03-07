namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualRemove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RequestMaps", "SubServices");
            RenameColumn(table: "dbo.RequestMaps", name: "SubService_Id", newName: "SubServices");
            RenameIndex(table: "dbo.RequestMaps", name: "IX_SubService_Id", newName: "IX_SubServices");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RequestMaps", name: "IX_SubServices", newName: "IX_SubService_Id");
            RenameColumn(table: "dbo.RequestMaps", name: "SubServices", newName: "SubService_Id");
            AddColumn("dbo.RequestMaps", "SubServices", c => c.Int());
        }
    }
}
