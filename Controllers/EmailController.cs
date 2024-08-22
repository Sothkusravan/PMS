using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharma.Interface;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [HttpPost("SendApprovalByEmail")]
        public async Task<IActionResult> SendApprovalByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                await _emailService.SendApprovalByEmail(name, recipientEmail, password);
                return Ok("Mentor password email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending mentor password email: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
         [HttpPost("DoctorByEmail")]
        public async Task<IActionResult> DoctorByEmail(string name, string recipientEmail, string password)
        {
            try
            {
                await _emailService.DoctorByEmail(name, recipientEmail, password);
                return Ok("Mentor password email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending mentor password email: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("PharmacistByEmail")]
        public async Task<IActionResult> PharmacistByEmail(string name, string recipientEmail)
        {
            try
            {
                await _emailService.PharmacistByEmail(name, recipientEmail);
                return Ok("Mentor password email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending mentor password email: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("SalesManByEmail")]
        public async Task<IActionResult> SalesManByEmail(string name, string recipientEmail)
        {
            try
            {
                await _emailService.SalesManByEmail(name, recipientEmail);
                return Ok("Mentor password email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending mentor password email: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
