using EmailMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost("send")]
        public async Task<IActionResult> PostAsync([FromBody] EmailRequestModel request)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("karabomotshosa@gmail.com", "lmeckqkqgowlhaxt"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("karabomotshosa@gmail.com", "Your Name"),
                Subject = request.Subject,
                Body = request.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(request.To);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);

                return Ok(new EmailResponseModel
                {
                    Status = "Success",
                    Message = "Email sent successfully.",
                    EmailId = "1234567890"
                });
            }
            catch (SmtpException ex) when (ex.StatusCode == SmtpStatusCode.Ok)
            {
                // Handle success - This block won't typically be executed for status 200 in .NET
                return Ok(new EmailResponseModel
                {
                    Status = "Success",
                    Message = "Email sent successfully.",
                    EmailId = "1234567890"
                });
            }
            catch (SmtpException ex) when (ex.StatusCode == SmtpStatusCode.GeneralFailure)
            {
                // Handle network/general failures - often map to 500
                return BadRequest(new EmailResponseModel
                {
                    Status = "Internal Server Error",
                    Message = "An error occurred while sending the email",
                    EmailId = "1234567890"
                });
            }
            catch (SmtpException ex) when (ex.StatusCode == SmtpStatusCode.ClientNotPermitted ||
                                            ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst)
            {
                // Handle client errors - often map to 400
                return BadRequest(new EmailResponseModel
                {
                    Status = "Bad Request",
                    Message = "Invalid request parameters",
                    EmailId = "1234567890"
                });
            }
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
