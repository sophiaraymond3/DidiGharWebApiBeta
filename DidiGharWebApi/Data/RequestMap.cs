using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class RequestMap
    {
        public int Id { get; set; }

        [ForeignKey("Request")]
        public Nullable<int> RequestId { get; set; }
        [ForeignKey("Service")]
        public Nullable<int> ServiceId { get; set; }
        [ForeignKey("SubService")]
        public Nullable<int> SubServices { get; set; }
        public Nullable<bool> Completed { get; set; }
        public string Reason { get; set; }

        public Request Request { get; set; }
        public Service Service { get; set; }
        public SubService SubService { get; set; }
    }
}