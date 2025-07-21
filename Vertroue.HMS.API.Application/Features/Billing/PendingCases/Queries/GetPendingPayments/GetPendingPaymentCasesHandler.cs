using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Billing.PendingCases.Models;

namespace Vertroue.HMS.API.Application.Features.Billing.PendingCases.Queries.GetPendingPayments
{
    public class GetPendingPaymentCasesHandler : IRequestHandler<GetPendingPaymentCasesQuery, List<PendingCaseDto>>
    {
        private readonly IBillingRepository _repository;

        public GetPendingPaymentCasesHandler(IBillingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PendingCaseDto>> Handle(GetPendingPaymentCasesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPendingPaymentCasesAsync(request.CorporateId, request.UserId, request.UserType, request.UserRole);
        }
    }

}
