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

    }
}
