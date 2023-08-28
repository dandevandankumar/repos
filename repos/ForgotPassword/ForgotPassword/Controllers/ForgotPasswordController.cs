using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ForgotPasswordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForgotPasswordController : ControllerBase
    {
        private static Dictionary<string, string> usersDb = new Dictionary<string, string>
        {
            { "user1@example.com", "user1password" }
            // Add more users as needed
        };

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordRequest request)
        {
            if (usersDb.ContainsKey(request.Email))
            {
                string resetCode = GenerateResetCode();
                SendResetEmail(request.Email, resetCode);

                return Ok(new { Message = "Reset instructions sent to your email." });
            }
            else
            {
                return NotFound(new { Error = "Email not found in the database." });
            }
        }

        private string GenerateResetCode()
        {
            // Generate a random reset code
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        private void SendResetEmail(string email, string resetCode)
        {
            // Replace with your email sending logic
            using (SmtpClient smtpClient = new SmtpClient("smtp.example.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("your_email@example.com", "your_email_password");
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("your_email@example.com"),
                    Subject = "Password Reset Instructions",
                    Body = $"Your password reset code is: {resetCode}"
                };
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
            }
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }
}
