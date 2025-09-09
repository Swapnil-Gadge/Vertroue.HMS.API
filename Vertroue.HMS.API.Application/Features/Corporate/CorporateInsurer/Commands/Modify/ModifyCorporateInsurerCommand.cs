using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify
{
    public class ModifyCorporateInsurerCommand : IRequest<string>
    {
        public int CorporateInsurerId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string EmpanneledDate { get; set; } = string.Empty;
        public string PortalLink { get; set; } = string.Empty;
        public string PortalUserId { get; set; } = string.Empty;
        public string PortalPassword { get; set; } = string.Empty;
    }
}
