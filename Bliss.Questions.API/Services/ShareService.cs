using System.Threading.Tasks;
using Bliss.Questions.API.Interfaces;
using Bliss.Questions.API.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Bliss.Questions.API.Services
{
    public class ShareService : IShareService
    {

        private readonly ISendgridSettings _sendgridSettings;

        public ShareService(IOptions<SendgridSettings> sendgridSettings) 
        {
            _sendgridSettings = sendgridSettings.Value;
        }

        public async Task<Response> Share(string content, string email)
        {
            var client = new SendGridClient(_sendgridSettings.ApiKey);
            var from = new EmailAddress("questions@blissapplications.com", "Bliss Questions");
            var subject = "Bliss Applications (Answer the question!)";
            var to = new EmailAddress(email);
            var htmlContent = $"<strong>{content}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}