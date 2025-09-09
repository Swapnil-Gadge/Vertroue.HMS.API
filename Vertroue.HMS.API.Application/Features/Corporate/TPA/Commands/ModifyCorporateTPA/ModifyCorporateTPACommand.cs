using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.ModifyCorporateTPA
{
    public class ModifyCorporateTPACommand : IRequest<string>
    {
        public int CorporateTPAId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public string EmpanneledDate { get; set; }
        public string PortalLink { get; set; }
        public string PortalUserId { get; set; }
        public string PortalPassword { get; set; }
    }

}
