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
            try
            {
                var response = new MessagingResponse();
                response.Message("This is me replying from the API");
                return TwiML(response);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate for your application.
                // You can also return a different response indicating that an error occurred.
                var errorResponse = new MessagingResponse();
                errorResponse.Message("An error occurred while processing the request. Please try again later.");
                return TwiML(errorResponse);
            }
        }

    }
}
