using DidiGharWebApi.Data;
using DidiGharWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DidiGharWebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public User Post(User value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("Services")]
        public async Task<List<Service>> GetServices()
        {
            var serviceList = db.Services.ToList();
            return serviceList;
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
