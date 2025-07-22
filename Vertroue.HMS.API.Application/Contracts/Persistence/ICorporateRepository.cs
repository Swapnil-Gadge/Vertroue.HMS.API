using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.List.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface ICorporateRepository
    {
        Task<FetchParentCorporateResponse> GetParentCorporateWithDetailsAsync(int userId, string userType, string userRole);
        Task<SaveParentCorporateResponse> SaveParentCorporateAsync(SaveParentCorporateCommand request);
        Task<FetchCorporateDetailsResponse> FetchCorporateDetailsAsync(FetchCorporateDetailsQuery request);
        Task<FetchCorporateResponse> FetchCorporateListAsync(FetchCorporateListQuery request);
        Task<List<CorporateUserDto>> FetchCorporateUsersAsync(FetchCorporateUsersQuery request);
    }
}
