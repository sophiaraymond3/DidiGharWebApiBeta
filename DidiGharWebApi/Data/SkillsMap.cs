using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class SkillsMap
    {
        public int Id { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> SubServiceId { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public ServiceProvider ServiceProvider { get; set; }
        public Service Service { get; set; }
        public SubService SubService { get; set; }
    }
}