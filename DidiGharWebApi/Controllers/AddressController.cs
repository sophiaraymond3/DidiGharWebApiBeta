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
        public List<UserAddress> GetAddressList(string username)
        {
            var address = db.AppUsers.Include(x =>x.UserAddresses).FirstOrDefault(x => x.UserName == username).UserAddresses;

            return address.ToList();  
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
