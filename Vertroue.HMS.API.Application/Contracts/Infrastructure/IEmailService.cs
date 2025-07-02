using Vertroue.HMS.API.Application.Models.Mail;
using System.Threading.Tasks;

namespace Vertroue.HMS.API.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
