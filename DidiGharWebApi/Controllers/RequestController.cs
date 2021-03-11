using DidiGharWebApi.Data;
using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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

        [Route("GetTimeSlots")]
        public List<TimeSlotResponse> GetTimeSlots(int serviceId)
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

            var partners = db.ServiceProviders.Where(x => x.ServiceId == serviceId).ToList();

            //Step4: Create Time Span from 09:00 AM to 06:00 PM.

            DateTime startOfTheDay = DateTime.Now.StartOfDay();
            DateTime endOfTheDay = DateTime.Now.EndOfDay();

            //Step5: Check from Time Span list if all partners fetched are busy for each time span given.

            var partnersAvailable = partners.Any(x => !UpdatedTime.Select(y => y.PartnerId).ToList().Contains(x.Id));

            //Step6: Mark that time span as unavailable in the created Time Span.
            var intervalTimeSlot = startOfTheDay;
            List<TimeSlotResponse> timeSlots = new List<TimeSlotResponse>();
            for (int i = 0; i <= 18; i++)
            {
                timeSlots.Add(new TimeSlotResponse()
                {
                    TimeSlot = intervalTimeSlot,
                    Disabled = false
                });
                intervalTimeSlot = intervalTimeSlot.AddMinutes(30);
            }

            if (!partnersAvailable)
            {
                //list of appointment to and from

                //for each appointment check if all partners have appointment

                //if everyone is busy then disable time slot

                //else timeslot available to be picked

                foreach (var appointmemt in UpdatedTime)
                {
                    var slotFree = UpdatedTime.Any(x => x.EndTimeSlot < appointmemt.StartTimeSlot || x.StartTimeSlot > appointmemt.EndTimeSlot);
                    if (!slotFree)
                    {
                        timeSlots.Where(x => x.TimeSlot.TimeOfDay >= appointmemt.StartTimeSlot.TimeOfDay && x.TimeSlot.TimeOfDay <= appointmemt.EndTimeSlot.TimeOfDay).ToList().ForEach(f=>f.Disabled=true);
                    }
                }
            }

            //Step7: Return available time slots for user to pick.

            return timeSlots;
        }

        [ResponseType(typeof(RequestMap))]
        public async Task<IHttpActionResult> PostRequest(Request model)
        {
            model.AssignedTo = null;
            db.Requests.Add(model);
            db.SaveChanges();
            return Ok();
        }

        //public List<ServiceProvider> GetProviderAvailable(DateTime pickedTimeSlot, int pincode,int serviceId)
        //{
        //    var pickedSlot = DateTime.Now;
        //    //Getting the nearest partners available to the requester pincode
        //    var providers = db.ServiceProviders.Where(x => x.ServiceId == serviceId && x.Pincode == pincode).Select(x => x.Id).ToList();

        //    int assignedTo = 0;
        //    //Providers with 0 request with nearest pincode
        //    var blankProviders = db.Requests.Any(x => providers.Contains(x.Id));
        //    if(blankProviders)
        //    {
        //        assignedTo = db.Requests.Where(x => x.AssignedTo == providers;
        //    }
        //    else
        //    {

        //    }
        //}

    }
}
