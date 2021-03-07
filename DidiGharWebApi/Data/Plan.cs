using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Prince { get; set; }
        public int SubserviceId { get; set; }

    }
}