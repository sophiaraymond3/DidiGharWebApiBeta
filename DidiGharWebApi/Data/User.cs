using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class User
    {
        public User()
        {
            this.Requests = new HashSet<Request>();
            this.UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Nullable<int> PhoneAreaCode { get; set; }
        public Nullable<Int64> PhoneNumber { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> ModifiedOnUtc { get; set; }
        
        [ForeignKey("Genders")]
        public Nullable<int> Gender { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [ForeignKey("Role")]
        public Nullable<int> RoleId { get; set; }
        public string Picture { get; set; }

        [ForeignKey("Users")]
        public string UserCrerdsId { get; set; }
        
        public  Gender Genders { get; set; }
        public  ICollection<Request> Requests { get; set; }
        public Role Role { get; set; }
        public  ICollection<UserAddress> UserAddresses { get; set; }
        public ApplicationUser Users { get; set; }
    }
}