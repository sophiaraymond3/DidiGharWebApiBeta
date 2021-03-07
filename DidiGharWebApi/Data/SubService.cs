using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class SubService
    {
        public SubService()
        {
            this.RequestMaps = new HashSet<RequestMap>();
            this.SkillsMaps = new HashSet<SkillsMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Cost { get; set; }
        public long Duration { get; set; }
        public string Plan { get; set; }
        public Nullable<bool> IsActive { get; set; }
        

        [ForeignKey("Service")]
        public Nullable<int> ServiceId { get; set; }

        public ICollection<RequestMap> RequestMaps { get; set; }
        public Service Service { get; set; }
        public ICollection<SkillsMap> SkillsMaps { get; set; }
    }
}