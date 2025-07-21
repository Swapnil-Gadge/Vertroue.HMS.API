using Vertroue.HMS.API.Application.Features.Billing.PaidCases.Models;
using Vertroue.HMS.API.Application.Features.Billing.PendingCases.Models;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IBillingRepository
    {
        Task<List<PendingCaseDto>> GetPendingPaymentCasesAsync(int corporateId, int userId, string userType, string userRole);
        Task<List<PaidCaseDto>> GetPaidCasesAsync(int corporateId, int userId, string userType, string userRole);
    }

}
