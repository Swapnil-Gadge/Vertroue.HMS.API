using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Commands
{
    public class AddCorporateRenewalCommand : IRequest<string>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string ServiceDesc { get; set; } = string.Empty;
        public string RenewalDate { get; set; } = string.Empty;
        public string ExpireDate { get; set; } = string.Empty;
        public int ServiceRenewalId { get; set; }
    }
}
