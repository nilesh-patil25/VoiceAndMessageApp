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
        public TwiMLResult makecall()
        {
            var accountsid = "AC234da79e9ae41102506144a49286f276"; //we are setting the account credentials
            var authtoken = "75fdffd42ed103fd5e54ce20648ad16b";
            var phonenumber = "+15075125944";//twilio phone number


            TwilioClient.Init(accountsid, authtoken);//Initialize twilio to twilio library
            var to = new PhoneNumber("8888111923");    //to customer number
            var from = new PhoneNumber("phonenumber"); // from a twilio number

            var call1 = CallResource.Create(    //here we are making the call from twilio using createResource.create method         
                 twiml: new Twilio.Types.Twiml("<Response>\r\n  <Say voice=\"alice\">Thanks for trying our documentation. Enjoy!</Say>\r\n  <Play>https://demo.twilio.com/docs/classic.mp3</Play>\r\n</Response>"),//here we are setting the response

                  from: new Twilio.Types.PhoneNumber("+15075125944"),  //making a call
                  to: new Twilio.Types.PhoneNumber("+918888111923")
                    );
            var responseString = new MessagingResponse();


            var response = responseString.Message(call1.Sid); //unique string to identify call resource

            return TwiML(response);
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
