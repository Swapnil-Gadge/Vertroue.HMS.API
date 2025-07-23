using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPA
{
    public record FetchCorporateTPAQuery(
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole
    ) : IRequest<FetchCorporateTPAResponse>;
}
