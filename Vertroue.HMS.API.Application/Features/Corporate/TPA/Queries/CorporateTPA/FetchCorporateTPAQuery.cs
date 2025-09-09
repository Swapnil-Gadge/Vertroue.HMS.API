using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPA
{
    public class FetchCorporateTPAQuery : IRequest<FetchCorporateTPAResponse>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
