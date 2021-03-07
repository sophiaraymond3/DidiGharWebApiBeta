using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class Request
    {
        public Request()
        {
            this.RequestMaps = new HashSet<RequestMap>();
            this.UserFeedbacks = new HashSet<UserFeedback>();
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public Nullable<int> Requester { get; set; }

        [ForeignKey("UserAddress")]
        public Nullable<int> AddressId { get; set; }
        public Nullable<System.DateTime> StartedOnUtc { get; set; }
        public Nullable<System.DateTime> RequestedOnUtc { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public long TotalCost { get; set; }

        [ForeignKey("ServiceProvider")]
        public Nullable<int> AssignedTo { get; set; }
        
        [ForeignKey("RequestsStatus")]
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> ClosedOnUtc { get; set; }

        public  ICollection<RequestMap> RequestMaps { get; set; }
        public  UserAddress UserAddress { get; set; }
        public  ServiceProvider ServiceProvider { get; set; }
        public  User User { get; set; }
        public  RequestsStatus RequestsStatus { get; set; }
        public  ICollection<UserFeedback> UserFeedbacks { get; set; }
    }
}