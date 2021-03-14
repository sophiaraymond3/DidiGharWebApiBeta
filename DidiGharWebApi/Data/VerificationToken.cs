using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Data
{
    public class VerificationToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}