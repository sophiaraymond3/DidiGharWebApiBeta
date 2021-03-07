//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DidiGharWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            this.RequestMaps = new HashSet<RequestMap>();
            this.UserFeedbacks = new HashSet<UserFeedback>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Requester { get; set; }
        public Nullable<int> AddressId { get; set; }
        public Nullable<System.DateTime> TimeSlotsUtc { get; set; }
        public Nullable<System.DateTime> RequestedOnUtc { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> ClosedOnUtc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestMap> RequestMaps { get; set; }
        public virtual UserAddress UserAddress { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual User User { get; set; }
        public virtual RequestsStatu RequestsStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserFeedback> UserFeedbacks { get; set; }
    }
}
