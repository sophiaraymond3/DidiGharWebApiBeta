namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserCrerdsId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "UserCrerdsId");
            AddForeignKey("dbo.Users", "UserCrerdsId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserCrerdsId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserCrerdsId" });
            DropColumn("dbo.Users", "UserCrerdsId");
        }
    }
}
