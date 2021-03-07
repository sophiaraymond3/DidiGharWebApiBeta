using System;

namespace DidiGharWebApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int PhoneAreaCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string Picture { get; set; }
    }
}