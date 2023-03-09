using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;

namespace SendSmsAndReceive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendSmsController : TwilioController
    {

        string accountSid = "AC234da79e9ae41102506144a49286f276";
        string authToken = "75fdffd42ed103fd5e54ce20648ad16b";

        [HttpPost("SendText")]
        public ActionResult SendText(string phoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);

            //message
            var message=MessageResource.Create(      //MessageResource.create method of twilio to send the message 
                body:"Hi this is message from Twilio",  //body from twilio msg receive to the customer
                from:new Twilio.Types.PhoneNumber("+15075125944"),  //from twilio
                to:new Twilio.Types.PhoneNumber("+91"+phoneNumber)  //to customer
                );
            return StatusCode(200, new {message=message.Sid});
        }
    }
}
