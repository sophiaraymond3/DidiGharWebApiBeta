namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Gender");
            RenameColumn(table: "dbo.Users", name: "Gender1_Id", newName: "Gender");
            RenameIndex(table: "dbo.Users", name: "IX_Gender1_Id", newName: "IX_Gender");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_Gender", newName: "IX_Gender1_Id");
            RenameColumn(table: "dbo.Users", name: "Gender", newName: "Gender1_Id");
            AddColumn("dbo.Users", "Gender", c => c.Int());
        }
    }
}
