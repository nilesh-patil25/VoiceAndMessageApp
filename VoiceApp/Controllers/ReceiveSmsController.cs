using Microsoft.AspNetCore.Mvc;
using SendSmsAndReceive.Models;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace SendSmsAndReceive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiveSmsController : TwilioController
    {
        [HttpPost("SendReply")]
        public TwiMLResult SendReply([FromForm] TwilioSms request)
         {
            var response = new MessagingResponse();//send automatic response to person whois texting us
            response.Message("This is me replying from the API");
            return TwiML(response);
        }
    }
}
