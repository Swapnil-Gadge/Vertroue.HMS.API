using MediatR;
using Vertroue.HMS.API.Application.Features.Billing.PendingCases.Models;

namespace Vertroue.HMS.API.Application.Features.Billing.PendingCases.Queries.GetPendingPayments
{
    public record GetPendingPaymentCasesQuery(int CorporateId, int UserId, string UserType, string UserRole) : IRequest<List<PendingCaseDto>>;
}
