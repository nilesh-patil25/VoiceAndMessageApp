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
            try
            {
                TwilioClient.Init(accountSid, authToken);

                //message
                var message = MessageResource.Create(
                    body: "Hi this is a message from Twilio",
                    from: new Twilio.Types.PhoneNumber("+15075125944"),
                    to: new Twilio.Types.PhoneNumber("+91" + phoneNumber)
                );

                return StatusCode(200, new { message = message.Sid });
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return StatusCode(500, new { error = "An error occurred while sending the message." });
            }
        }

    }
}
