using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Models
{
    public class UpdatedTimeSlots
    {
        public DateTime StartTimeSlot { get; set; }
        public DateTime EndTimeSlot { get; set; }
        public int PartnerId { get; set; }
    }
}