using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Pincode
    {
        public Pincode()
        {
            this.ServiceProviders = new HashSet<ServiceProvider>();
            this.UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }

        [ForeignKey("Cities")]
        public Nullable<int> CityId { get; set; }
        public Nullable<int> PinCode { get; set; }
        public string AreaName { get; set; }

        public  City Cities { get; set; }
        public ICollection<ServiceProvider> ServiceProviders { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}