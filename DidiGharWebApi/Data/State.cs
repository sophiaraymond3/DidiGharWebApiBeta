using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class State
    {
        public State()
        {
            this.Cities = new HashSet<City>();
            this.ServiceProviders = new HashSet<ServiceProvider>();
            this.UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Name { get; set; }

        public  ICollection<City> Cities { get; set; }
        public  Country Country { get; set; }
        public  ICollection<ServiceProvider> ServiceProviders { get; set; }
        public  ICollection<UserAddress> UserAddresses { get; set; }
    }
}