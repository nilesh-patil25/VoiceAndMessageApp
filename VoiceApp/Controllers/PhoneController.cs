using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;
using Twilio.AspNet.Core;



using System.Security.Cryptography.Xml;


using Twilio.TwiML.Voice;

namespace SendSmsAndReceive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : TwilioController
    {
        [HttpPost("makecall")]
        public TwiMLResult MakeCall()
        {
            try
            {
                var accountSid = "AC234da79e9ae41102506144a49286f276";
                var authToken = "75fdffd42ed103fd5e54ce20648ad16b";
                var phoneNumber = "+15075125944";

                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("8888111923");
                var from = new PhoneNumber(phoneNumber);

                var call1 = CallResource.Create(
                    twiml: new Twilio.Types.Twiml("<Response>\r\n  <Say voice=\"alice\">Thanks for trying our documentation. Enjoy!</Say>\r\n  <Play>https://demo.twilio.com/docs/classic.mp3</Play>\r\n</Response>"),
                    from: new Twilio.Types.PhoneNumber(phoneNumber),
                    to: new Twilio.Types.PhoneNumber("+918888111923")
                );

                var responseString = new MessagingResponse();
                var response = responseString.Message(call1.Sid);

                return TwiML(response);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"An error occurred: {ex.Message}");

                // You might want to return an error TwiML or a custom response in case of an exception
                var errorResponse = new MessagingResponse();
                var errorMessage = errorResponse.Message("An error occurred while making the call.");
                return TwiML(errorMessage);
            }
        }


        // This code will not run beacase of region issue of usa
        [HttpPost]
        public TwiMLResult ReceiveCall()
        {
            try
            {
                var response = new VoiceResponse();
                response.Say("Hi, we are from Twilio"); // Sending the response
                return TwiML(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new VoiceResponse();
                errorResponse.Say("An error occurred while processing the call. Please try again later.");
                return TwiML(errorResponse);
            }
        }


    }
}
