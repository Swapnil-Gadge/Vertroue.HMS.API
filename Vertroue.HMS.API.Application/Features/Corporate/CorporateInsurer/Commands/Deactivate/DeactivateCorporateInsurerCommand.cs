using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Deactivate
{
    public class DeactivateCorporateInsurerCommand : IRequest<string>
    {
        public int CorporateInsurerId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }

}
