using Vertroue.HMS.API.Application.Contracts.Infrastructure;
using Vertroue.HMS.API.Application.Models.Mail;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Vertroue.HMS.API.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            //Send email logic;

            return false;
        }
    }
}
