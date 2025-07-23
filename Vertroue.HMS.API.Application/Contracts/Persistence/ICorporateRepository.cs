using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Add;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.AddInsurerRates;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser;
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
        Task<string> AddCorporateUserAsync(AddCorporateUserCommand request);
        Task<string> ModifyCorporateUserAsync(ModifyCorporateUserCommand request);
        Task<string> DeactivateCorporateUserAsync(DeactivateCorporateUserCommand request);
        Task<FetchCorporateInsurerResponse> FetchCorporateInsurersAsync(int corporateId, int userId, string userType, string userRole);
        Task<List<CorporateInsurerRateDto>> FetchCorporateInsurerRatesAsync(int corporateInsurerId,int corporateId,int userId,string userType,string userRole);
        Task<string> ModifyCorporateInsurerAsync(ModifyCorporateInsurerCommand command);
        Task<string> AddCorporateInsurerAsync(AddCorporateInsurerCommand command);
        Task<string> DeactivateCorporateInsurerAsync(int corporateInsurerId, int corporateId, int userId, string userType, string userRole);
        Task<string> AddCorporateInsurerRateAsync(AddCorporateInsurerRateCommand command);
    }
}
