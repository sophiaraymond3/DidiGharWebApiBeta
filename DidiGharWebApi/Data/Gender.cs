using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Gender
    {
        public Gender()
        {
            this.ServiceProviders = new HashSet<ServiceProvider>();
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}