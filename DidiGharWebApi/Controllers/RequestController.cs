using DidiGharWebApi.Data;
using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DidiGharWebApi.Controllers
{
    [RoutePrefix("api/Request")]
    public class RequestController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("GetUserAddress")]
        public List<UserAddress> GetUserAddress(int userId)
        {
            var address = db.UserAddresses.Where(x => x.UserId == userId).ToList();
            return address;
        }

        public List<DateTime> GetTimeSlots(Request request)
        {
            //Step 1: Fetch RequestednUtc and EstimatedDuration from Request Table. Calculate total Timespan .
            //- ReqeustednUtc : starting time of service ex - 10Am
            // estimatedDuration : duration of service ex - 2hrs
            // EndTime : 12PM

            //Step2: Add half an hour before and after the time span. Create updated Time Span list against partner Id

            List<UpdatedTimeSlots> UpdatedTime = new List<UpdatedTimeSlots>();
            var totalRequests = db.Requests.Where(x => x.Status != 0).ToList();
            foreach (var item in totalRequests)
            {
                UpdatedTime.Add(new UpdatedTimeSlots()
                {
                    StartTimeSlot = item.RequestedOnUtc.GetValueOrDefault().AddMinutes(-30),
                    EndTimeSlot = item.RequestedOnUtc.GetValueOrDefault().Add(item.EstimatedDuration).AddMinutes(30),
                    PartnerId = item.AssignedTo.GetValueOrDefault()
                });
            }

            //Step3: Fetch all partners against service Id available within the address serviceable parameter. 

            var partners = db.ServiceProviders.Where(x => x.ServiceId == request.RequestMaps.FirstOrDefault().ServiceId).ToList();

            //Step4: Create Time Span from 09:00 AM to 06:00 PM.

            DateTime startOfTheDay = DateTime.Now.StartOfDay();
            DateTime endOfTheDay = DateTime.Now.EndOfDay();

            //Step5: Check from Time Span list if all partners fetched are busy for each time span given.

            var partnersAvailable = partners.Any(x => !UpdatedTime.Select(y => y.PartnerId).ToList().Contains(x.Id));

            //Step6: Mark that time span as unavailable in the created Time Span.

            List<TimeSlotResponse> timeSlots = new List<TimeSlotResponse>();
            for (int i = 0; i <= 18; i++)
            {
                timeSlots.Add(new TimeSlotResponse()
                {
                    TimeSlot = startOfTheDay.AddMinutes(30),
                    Disabled=false
                });
            }

            if (!partnersAvailable)
            {
                
            }

            //Step7: Return available time slots for user to pick.

            return timeSlots;
        }

    }
}
