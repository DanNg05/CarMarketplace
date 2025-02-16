using CarMarketplace.Models;
using CarMarketplace.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMarketplace.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
        //public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        //{
        //    if (request == null || string.IsNullOrEmpty(request.UserEmail) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Message))
        //    {
        //        return BadRequest("Invalid email request.");
        //    }

        //    var result = await _emailService.SendEmailAsync(request.UserEmail, request.Subject, request.Message);

        //    if (result)
        //        return Ok(new { message = "Email sent successfully!" });
        //    else
        //        return StatusCode(500, new { message = "Failed to send email." });
        //}

        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserEmail) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("Invalid email request.");
            }

            var result = await _emailService.SendEmailsAsync(request.UserEmail, request.Subject, request.Message);

            if (result)
            {
                return Ok(new { message = "Email sent successfully!" });
            }
            else
            {
                return StatusCode(500, new { message = "Failed to send email." });
            }

        }
    }
}
