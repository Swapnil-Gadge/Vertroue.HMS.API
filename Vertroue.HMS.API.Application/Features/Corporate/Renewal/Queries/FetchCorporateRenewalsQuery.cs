using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries
{
    public class FetchCorporateRenewalsQuery : IRequest<FetchCorporateRenewalsResponse>
    {
        public int CorporateId { get; set; }
        public int UserLoginId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
