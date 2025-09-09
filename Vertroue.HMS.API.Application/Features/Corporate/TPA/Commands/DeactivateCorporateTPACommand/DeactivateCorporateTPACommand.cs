using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.DeactivateCorporateTPACommand
{
    public class DeactivateCorporateTPACommand : IRequest<string>
    {
        public int CorporateTPAId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
    }

}
