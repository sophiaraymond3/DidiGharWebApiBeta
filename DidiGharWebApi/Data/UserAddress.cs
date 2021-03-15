using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class UserAddress
    {
        public UserAddress()
        {
            this.Requests = new HashSet<Request>();
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public Nullable<int> UserId { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [ForeignKey("city")]
        public Nullable<int> City { get; set; }
        [ForeignKey("state")]
        public Nullable<int> State { get; set; }
        [ForeignKey("country")]
        public Nullable<int> Country { get; set; }
        [ForeignKey("pincode")]
        public Nullable<int> Pincode { get; set; }
        public Nullable<System.DateTime> createdOnUtc { get; set; }
        public Nullable<System.DateTime> ModifiedOnUtc { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public City city { get; set; }
        public Country country { get; set; }
        public Pincode pincode { get; set; }
        public ICollection<Request> Requests { get; set; }
        public State state { get; set; }
        public User User { get; set; }
        
        [NotMapped]
        public string Username { get; set; }
    }
}