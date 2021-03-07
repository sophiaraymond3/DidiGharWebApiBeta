namespace DidiGharWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        PhoneAreaCode = c.Int(),
                        PhoneNumber = c.Int(),
                        CreatedOnUtc = c.DateTime(),
                        ModifiedOnUtc = c.DateTime(),
                        Gender = c.Int(),
                        IsActive = c.Boolean(),
                        RoleId = c.Int(),
                        Picture = c.String(),
                        Gender1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender1_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.Gender1_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        PhoneAreaCode = c.Int(),
                        PhoneNumber = c.Int(),
                        Gender = c.Int(),
                        Address = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.Int(),
                        State = c.Int(),
                        Country = c.Int(),
                        Pincode = c.Int(),
                        createdOnUtc = c.DateTime(),
                        ModifiedOnUtc = c.DateTime(),
                        IsActive = c.Boolean(),
                        Picture = c.String(),
                        Pincode1_Id = c.Int(),
                        Country1_Id = c.Int(),
                        State1_Id = c.Int(),
                        City1_Id = c.Int(),
                        Gender1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pincodes", t => t.Pincode1_Id)
                .ForeignKey("dbo.Countries", t => t.Country1_Id)
                .ForeignKey("dbo.States", t => t.State1_Id)
                .ForeignKey("dbo.Cities", t => t.City1_Id)
                .ForeignKey("dbo.Genders", t => t.Gender1_Id)
                .Index(t => t.Pincode1_Id)
                .Index(t => t.Country1_Id)
                .Index(t => t.State1_Id)
                .Index(t => t.City1_Id)
                .Index(t => t.Gender1_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Pincodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(),
                        PinCode1 = c.Int(),
                        AreaName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Address = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.Int(),
                        State = c.Int(),
                        Country = c.Int(),
                        Pincode = c.Int(),
                        createdOnUtc = c.DateTime(),
                        ModifiedOnUtc = c.DateTime(),
                        IsActive = c.Boolean(),
                        City1_Id = c.Int(),
                        State1_Id = c.Int(),
                        Country1_Id = c.Int(),
                        Pincode1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City1_Id)
                .ForeignKey("dbo.States", t => t.State1_Id)
                .ForeignKey("dbo.Countries", t => t.Country1_Id)
                .ForeignKey("dbo.Pincodes", t => t.Pincode1_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.City1_Id)
                .Index(t => t.State1_Id)
                .Index(t => t.Country1_Id)
                .Index(t => t.Pincode1_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Requester = c.Int(),
                        AddressId = c.Int(),
                        TimeSlotsUtc = c.DateTime(),
                        RequestedOnUtc = c.DateTime(),
                        AssignedTo = c.Int(),
                        Status = c.Int(),
                        ClosedOnUtc = c.DateTime(),
                        RequestsStatus_Id = c.Int(),
                        ServiceProvider_Id = c.Int(),
                        User_Id = c.Int(),
                        UserAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestsStatus", t => t.RequestsStatus_Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProvider_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.UserAddresses", t => t.UserAddress_Id)
                .Index(t => t.RequestsStatus_Id)
                .Index(t => t.ServiceProvider_Id)
                .Index(t => t.User_Id)
                .Index(t => t.UserAddress_Id);
            
            CreateTable(
                "dbo.RequestMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(),
                        ServiceId = c.Int(),
                        SubServices = c.Int(),
                        Completed = c.Boolean(),
                        Reason = c.String(),
                        SubService_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.SubServices", t => t.SubService_Id)
                .Index(t => t.RequestId)
                .Index(t => t.ServiceId)
                .Index(t => t.SubService_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillsMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderID = c.Int(),
                        ServiceId = c.Int(),
                        SubServiceId = c.Int(),
                        IsActive = c.Boolean(),
                        ServiceProvider_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProvider_Id)
                .ForeignKey("dbo.SubServices", t => t.SubServiceId)
                .Index(t => t.ServiceId)
                .Index(t => t.SubServiceId)
                .Index(t => t.ServiceProvider_Id);
            
            CreateTable(
                "dbo.SubServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        ServiceId = c.Int(),
                        Cost = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.RequestsStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(),
                        Feedback = c.String(),
                        Rating = c.Int(),
                        CreatedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.RequestId)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "Gender1_Id", "dbo.Genders");
            DropForeignKey("dbo.ServiceProviders", "Gender1_Id", "dbo.Genders");
            DropForeignKey("dbo.ServiceProviders", "City1_Id", "dbo.Cities");
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFeedbacks", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "UserAddress_Id", "dbo.UserAddresses");
            DropForeignKey("dbo.Requests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Requests", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropForeignKey("dbo.Requests", "RequestsStatus_Id", "dbo.RequestsStatus");
            DropForeignKey("dbo.SkillsMaps", "SubServiceId", "dbo.SubServices");
            DropForeignKey("dbo.SubServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RequestMaps", "SubService_Id", "dbo.SubServices");
            DropForeignKey("dbo.SkillsMaps", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropForeignKey("dbo.SkillsMaps", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RequestMaps", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RequestMaps", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.UserAddresses", "Pincode1_Id", "dbo.Pincodes");
            DropForeignKey("dbo.UserAddresses", "Country1_Id", "dbo.Countries");
            DropForeignKey("dbo.UserAddresses", "State1_Id", "dbo.States");
            DropForeignKey("dbo.ServiceProviders", "State1_Id", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.ServiceProviders", "Country1_Id", "dbo.Countries");
            DropForeignKey("dbo.UserAddresses", "City1_Id", "dbo.Cities");
            DropForeignKey("dbo.ServiceProviders", "Pincode1_Id", "dbo.Pincodes");
            DropForeignKey("dbo.Pincodes", "CityId", "dbo.Cities");
            DropIndex("dbo.UserFeedbacks", new[] { "RequestId" });
            DropIndex("dbo.SubServices", new[] { "ServiceId" });
            DropIndex("dbo.SkillsMaps", new[] { "ServiceProvider_Id" });
            DropIndex("dbo.SkillsMaps", new[] { "SubServiceId" });
            DropIndex("dbo.SkillsMaps", new[] { "ServiceId" });
            DropIndex("dbo.RequestMaps", new[] { "SubService_Id" });
            DropIndex("dbo.RequestMaps", new[] { "ServiceId" });
            DropIndex("dbo.RequestMaps", new[] { "RequestId" });
            DropIndex("dbo.Requests", new[] { "UserAddress_Id" });
            DropIndex("dbo.Requests", new[] { "User_Id" });
            DropIndex("dbo.Requests", new[] { "ServiceProvider_Id" });
            DropIndex("dbo.Requests", new[] { "RequestsStatus_Id" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.UserAddresses", new[] { "Pincode1_Id" });
            DropIndex("dbo.UserAddresses", new[] { "Country1_Id" });
            DropIndex("dbo.UserAddresses", new[] { "State1_Id" });
            DropIndex("dbo.UserAddresses", new[] { "City1_Id" });
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropIndex("dbo.Pincodes", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.ServiceProviders", new[] { "Gender1_Id" });
            DropIndex("dbo.ServiceProviders", new[] { "City1_Id" });
            DropIndex("dbo.ServiceProviders", new[] { "State1_Id" });
            DropIndex("dbo.ServiceProviders", new[] { "Country1_Id" });
            DropIndex("dbo.ServiceProviders", new[] { "Pincode1_Id" });
            DropIndex("dbo.Users", new[] { "Gender1_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.RequestsStatus");
            DropTable("dbo.SubServices");
            DropTable("dbo.SkillsMaps");
            DropTable("dbo.Services");
            DropTable("dbo.RequestMaps");
            DropTable("dbo.Requests");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Pincodes");
            DropTable("dbo.Cities");
            DropTable("dbo.ServiceProviders");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
