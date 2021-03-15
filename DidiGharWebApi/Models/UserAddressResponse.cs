using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Models
{
    public class UserAddressResponse
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? City { get; set; }
        public int? State { get; set; }
        public int? Country { get; set; }
        public int? Pincode { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public Nullable<DateTime> ModifiedOnUTC { get; set; }
        public bool IsActive { get; set; }
    }
}