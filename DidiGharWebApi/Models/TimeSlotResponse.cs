using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DidiGharWebApi.Models
{
    public class TimeSlotResponse
    {
        public DateTime TimeSlot { get; set; }
        public bool Disabled { get; set; }
    }
}