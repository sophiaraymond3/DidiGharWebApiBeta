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
        public List<TimeSlotResponse> GetTimeSlots(int serviceId,int cityId)
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

            var partners = db.ServiceProviders.Where(x => x.ServiceId == serviceId && x.City == cityId).ToList();

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
            model.AssignedTo = await GetProviderAvailable(model.RequestedOnUtc.GetValueOrDefault(), model.EstimatedDuration, model.UserAddress.pincode.PinCode.GetValueOrDefault(), model.RequestMaps.FirstOrDefault().ServiceId.GetValueOrDefault(),model.UserAddress.City.GetValueOrDefault());
            db.Requests.Add(model);
            db.SaveChanges();
            return Ok();
        }

        public Task<int> GetProviderAvailable(DateTime pickedTimeSlot, TimeSpan duration, int pincode, int serviceId,int cityId)
        {
            int assignedTo = 0;
            var endTimeSlot = pickedTimeSlot.Add(duration);
            //Getting the nearest partners available to the requester pincode
            var providers = db.ServiceProviders.Where(x => x.ServiceId == serviceId && x.Pincode == pincode && 
                            x.Requests.Any(y=> y.RequestedOnUtc.GetValueOrDefault().TimeOfDay > endTimeSlot.TimeOfDay && 
                            y.RequestedOnUtc.GetValueOrDefault().Add(y.EstimatedDuration) < pickedTimeSlot)).ToList();

            if (providers?.Count>0)
            {
                var ratings = db.UserFeedbacks.Where(x => providers.Select(p => p.Id).Contains(x.Request.ServiceProvider.Id)).ToList();
                var orderedRatings = ratings.GroupBy(x => x.Request.AssignedTo).OrderByDescending(O => O.Sum(s => s.Rating));
                assignedTo = orderedRatings.FirstOrDefault().Select(x => x.Request.AssignedTo.GetValueOrDefault()).FirstOrDefault();
            }
            else
            {
                var otherProviders = db.ServiceProviders.Where(x => x.City == cityId && x.ServiceId == serviceId && x.Pincode != pincode).ToList();
                var getRandomProviders = otherProviders.Where(x=>x.Requests.Any(y => y.RequestedOnUtc.GetValueOrDefault().TimeOfDay > endTimeSlot.TimeOfDay &&
                            y.RequestedOnUtc.GetValueOrDefault().Add(y.EstimatedDuration) < pickedTimeSlot)).ToList();
                
                if (getRandomProviders?.Count > 0)
                {
                    var ratings = db.UserFeedbacks.Where(x => getRandomProviders.Select(p => p.Id).Contains(x.Request.ServiceProvider.Id)).ToList();
                    var orderedRatings = ratings.GroupBy(x => x.Request.AssignedTo).OrderByDescending(O => O.Sum(s => s.Rating));
                    assignedTo = orderedRatings.FirstOrDefault().Select(x => x.Request.AssignedTo.GetValueOrDefault()).FirstOrDefault();
                }
                else
                {
                    //To Do:Send Manual Email for operation and management
                }
                //To Do : Expand Search using lattitute longitude based on closest pincode
            }
            return Task.FromResult(assignedTo);
        }

    }
}
