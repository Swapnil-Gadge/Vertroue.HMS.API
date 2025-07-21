using Vertroue.HMS.API.Application.Features.PaidCases.Models;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IPaidCasesRepository
    {
        Task<List<PaidCaseDto>> GetPaidCasesAsync(int corporateId, int userId, string userType, string userRole);
    }
}
