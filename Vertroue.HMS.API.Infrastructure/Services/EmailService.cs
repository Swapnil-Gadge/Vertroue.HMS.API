using Vertroue.HMS.API.Application.Contracts.Infrastructure;
using Vertroue.HMS.API.Application.Models.Mail;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }
        public IConfiguration _configuration { get; }

        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger, IConfiguration configuration)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(Email email)
        {
            try
            {
                string apiKey = _configuration.GetSection(Constant.EmailAPIKey).Value;
                var options = new SendGridClientOptions
                {
                    ApiKey = apiKey,
                };
                var client = new SendGridClient(options);

                var from = new EmailAddress(email.From);

                var to = new List<EmailAddress>();
                email.To.ForEach(recipient =>
                {
                    to.Add(new EmailAddress(recipient));
                });

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, email.Subject, email.Body, email.Body);
                var response = await client.SendEmailAsync(msg);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"EmailService SendEmail Error: {ex.InnerException?.Message ?? ex.Message}");
                return false;
            }            
        }
    }
}
