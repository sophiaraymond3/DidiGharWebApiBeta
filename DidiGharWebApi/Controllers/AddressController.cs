using DidiGharWebApi.Data;
using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using Newtonsoft.Json;

namespace DidiGharWebApi.Controllers
{
    [RoutePrefix("api/Address")]
    public class AddressController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: api/Address
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetCountry")]
        public List<Country> GetCountries()
        {
            return db.Countries.ToList();
        }

        [Route("GetState")]
        public List<State> GetStates(int id = 0)
        {
            return id == 0 ?db.States.ToList():db.States.Where(x => x.CountryId == id).ToList();
        }

        [Route("GetCity")]
        public List<City> GetCity(int id = 0)
        {
            return id == 0 ? db.Cities.ToList() : db.Cities.Where(x => x.StateId == id).ToList();
        }

        [Route("GetPincode")]
        public List<Pincode> GetPincode(int id = 0)
        {
            return id == 0 ? db.Pincodes.ToList() : db.Pincodes.Where(x => x.CityId == id).ToList();
        }

        [Route("GetAddressList")]
        public List<UserAddressResponse> GetAddressList(string username)
        {
            var address = db.AppUsers.Include(x =>x.UserAddresses).FirstOrDefault(x => x.UserName == username).UserAddresses;
            List<UserAddressResponse> userAddress = new List<UserAddressResponse>();
            foreach(var item in address)
            {
                userAddress.Add(new UserAddressResponse()
                {
                    Id=item.Id,
                    Address= item.Address,
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    City = item.City,
                    Country = item.Country,
                    State = item.State,
                    CreatedOnUTC = item.createdOnUtc.GetValueOrDefault(),
                    ModifiedOnUTC = item.ModifiedOnUtc.GetValueOrDefault(),
                    IsActive = item.IsActive.GetValueOrDefault(),
                    UserId = item.UserId,
                    Pincode = item.Pincode
                });
            }

            return userAddress ;  
        }

        // GET: api/Address/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Address
        [ResponseType(typeof(UserAddress))]
        public async Task<IHttpActionResult> PostAddress(UserAddress model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.UserId = db.AppUsers.FirstOrDefault(x => x.Email == model.Username).Id;
            db.UserAddresses.Add(model);
            await db.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
