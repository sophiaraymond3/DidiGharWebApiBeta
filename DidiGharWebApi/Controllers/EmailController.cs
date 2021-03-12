using DidiGharWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace DidiGharWebApi.Controllers
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        [Route("SendEmail")]
        public async Task<IHttpActionResult> SendEmail(EmailContent model)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@didighar.in");

            message.To.Add(new MailAddress(model.To));

            message.Subject = model.Subject;
            message.Body = model.Body;

            SmtpClient client = new SmtpClient();
            client.Send(message);
            return Ok();
        }
    }
}
