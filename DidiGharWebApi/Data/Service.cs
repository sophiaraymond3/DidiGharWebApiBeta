using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Service
    {
        public Service()
        {
            this.RequestMaps = new HashSet<RequestMap>();
            this.SkillsMaps = new HashSet<SkillsMap>();
            this.SubServices = new HashSet<SubService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public ICollection<RequestMap> RequestMaps { get; set; }
        public ICollection<SkillsMap> SkillsMaps { get; set; }
        public ICollection<SubService> SubServices { get; set; }
    }
}