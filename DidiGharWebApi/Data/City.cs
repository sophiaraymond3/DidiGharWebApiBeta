using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class City
    {
        public City()
        {
            this.Pincodes = new HashSet<Pincode>();
            this.ServiceProviders = new HashSet<ServiceProvider>();
            this.UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }

        [ForeignKey("State")]
        public Nullable<int> StateId { get; set; }
        public string Name { get; set; }

        public  State State { get; set; }
        public  ICollection<Pincode> Pincodes { get; set; }
        public  ICollection<ServiceProvider> ServiceProviders { get; set; }
        public  ICollection<UserAddress> UserAddresses { get; set; }
    }
}