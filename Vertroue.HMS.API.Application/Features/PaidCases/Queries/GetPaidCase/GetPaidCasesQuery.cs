using MediatR;
using Vertroue.HMS.API.Application.Features.PaidCases.Models;

namespace Vertroue.HMS.API.Application.Features.PaidCases.Queries.GetPaidCase
{
    public record GetPaidCasesQuery(int CorporateId, int UserId, string UserType, string UserRole) : IRequest<List<PaidCaseDto>>;
}
