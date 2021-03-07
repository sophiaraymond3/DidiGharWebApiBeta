using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class UserFeedback
    {
        public int Id { get; set; }
        public Nullable<int> RequestId { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Request Request { get; set; }
    }
}