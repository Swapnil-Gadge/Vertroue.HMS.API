using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.InsertCorporateTPARates
{
    public record InsertCorporateTPARatesCommand(
    int CorporateTPAId,
    int CorporateId,
    int UserId,
    string UserType,
    string UserRole,
    string RateFromDate,
    string RateToDate,
    string DocumentLink,
    string RateRemarks
) : IRequest<string>;
}
