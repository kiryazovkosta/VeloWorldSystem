using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;
using VeloWorldSystem.GpxProcessing;
using VeloWorldSystem.Services.Libraries.Contracts;

namespace VeloWorldSystem.Web.Controllers
{
    public class TestController : BaseController
    {
        private readonly IGpxService gpxService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IConfiguration configuration;

        public TestController(
            IGpxService gpxServiceParam,
            ICloudinaryService cloudinaryServiceParam,
            IConfiguration configParam )
        {
            this.gpxService = gpxServiceParam ?? throw new ArgumentNullException(nameof(gpxService));
            this.cloudinaryService = cloudinaryServiceParam ?? throw new ArgumentNullException(nameof(cloudinaryService));
            this.configuration = configParam ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet]
        public IActionResult Gpx()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Gpx(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var xml = await reader.ReadToEndAsync();
                var gpx = await this.gpxService.Get(xml);
                return View("ViewGpx", gpx);
            }
        }

        [HttpGet]
        public IActionResult Image()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Image(IFormFile file)
        {
            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploudAsync(file);
            }
            catch (Exception exception)
            {
                imageUrl = exception.Message;
            }

            return View("ViewImage", imageUrl);
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View("Pinokio");
        }

        public IActionResult SendEmail()
        {
            var apiKey = this.configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("kosta.kiryazov@gmail.com", "Kosta"),
                Subject = "Sending with Twilio SendGrid is Fun",
                PlainTextContent = "and easy to do anywhere, especially with C#"
            };
            msg.AddTo(new EmailAddress("kosta.kiryazov@gmail.com", "Koce"));
            // var response = await client.SendEmailAsync(msg);

            // A success status code means SendGrid received the email request and will process it.
            // Errors can still occur when SendGrid tries to send the email. 
            // If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
            string message = "test"; // = response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!";
            return View("SendEmail", message);
        }
    }
}
