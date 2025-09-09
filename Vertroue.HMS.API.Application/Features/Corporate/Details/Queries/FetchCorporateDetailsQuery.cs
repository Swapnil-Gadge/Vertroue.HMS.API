using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.Details.Queries
{
    public class FetchCorporateDetailsQuery : IRequest<FetchCorporateDetailsResponse>
    {
        public int ParentCorporateId { get; set; }
        public int? CorporateId { get; set; }
        public int? UserLoginId { get; set; }
        public string? UserType { get; set; }
        public string? UserRole { get; set; }
    }
}
