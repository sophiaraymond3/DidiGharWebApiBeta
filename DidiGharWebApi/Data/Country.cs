using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Country
    {
        public Country()
        {
            this.ServiceProviders = new HashSet<ServiceProvider>();
            this.States = new HashSet<State>();
            this.UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ServiceProvider> ServiceProviders { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}