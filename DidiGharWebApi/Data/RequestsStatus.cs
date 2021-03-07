using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class RequestsStatus
    {
        public RequestsStatus()
        {
            this.Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}