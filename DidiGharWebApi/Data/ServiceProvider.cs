using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {
            this.Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Nullable<int> PhoneAreaCode { get; set; }
        public Nullable<int> PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        
        public Nullable<System.DateTime> createdOnUtc { get; set; }
        public Nullable<System.DateTime> ModifiedOnUtc { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Picture { get; set; }
        
        [ForeignKey("Users")]
        public string UserCrerdsId { get; set; }

        [ForeignKey("Cities")]
        public Nullable<int> City { get; set; }

        [ForeignKey("Countries")]
        public Nullable<int> Country { get; set; }

        [ForeignKey("Genders")]
        public Nullable<int> Gender { get; set; }

        [ForeignKey("Pincodes")]
        public Nullable<int> Pincode { get; set; }
        public ICollection<Request> Requests { get; set; }

        [ForeignKey("States")]
        public Nullable<int> State { get; set; }

        [ForeignKey("service")]
        public Nullable<int> ServiceId { get; set; }

        public Service service { get; set; }
        public ApplicationUser Users { get; set; }
        public City Cities { get; set; }
        public State States { get; set; }
        public Pincode Pincodes { get; set; }
        public Gender Genders { get; set; }
        public Country Countries { get; set; }
    }
}