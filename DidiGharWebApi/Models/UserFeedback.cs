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
    
    public partial class UserFeedback
    {
        public int Id { get; set; }
        public Nullable<int> RequestId { get; set; }
        public string Feedback { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    
        public virtual Request Request { get; set; }
    }
}
