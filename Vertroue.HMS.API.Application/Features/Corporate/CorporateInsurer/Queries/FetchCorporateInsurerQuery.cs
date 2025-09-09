using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries
{
    public class FetchCorporateInsurerQuery : IRequest<FetchCorporateInsurerResponse>
    {
        public int CorporateId { get; set; }
        public int UserLoginId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
