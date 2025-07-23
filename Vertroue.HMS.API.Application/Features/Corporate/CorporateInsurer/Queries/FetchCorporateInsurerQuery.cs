using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries
{
    public record FetchCorporateInsurerQuery(
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole
) : IRequest<FetchCorporateInsurerResponse>;
}
