using MediatR;
namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPARates
{
    public record FetchCorporateTPARatesQuery(
        int CorporateTPAId,
        int CorporateId,
        int UserId,
        string UserType,
        string UserRole
    ) : IRequest<List<CorporateTPARateDto>>;
}
