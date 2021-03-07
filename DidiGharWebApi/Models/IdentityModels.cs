using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DidiGharWebApi.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DidiGharWebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DidiGharConnection", throwIfV1Schema: false)
        {
        }

        public  DbSet<City> Cities { get; set; }
        public  DbSet<Country> Countries { get; set; }
        public  DbSet<Gender> Genders { get; set; }
        public  DbSet<Pincode> Pincodes { get; set; }
        public  DbSet<RequestMap> RequestMaps { get; set; }
        public  DbSet<Request> Requests { get; set; }
        public  DbSet<RequestsStatus> RequestsStatus { get; set; }
        public  DbSet<Role> AppUserRoles { get; set; }
        public  DbSet<ServiceProvider> ServiceProviders { get; set; }
        public  DbSet<Service> Services { get; set; }
        public  DbSet<SkillsMap> SkillsMaps { get; set; }
        public  DbSet<State> States { get; set; }
        public  DbSet<SubService> SubServices { get; set; }
        public  DbSet<UserAddress> UserAddresses { get; set; }
        public  DbSet<UserFeedback> UserFeedbacks { get; set; }
        public  DbSet<User> AppUsers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}