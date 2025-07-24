using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Models;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IMasterDataRepository
    {
        Task<List<StateDto>> GetStatesAsync();
        Task<List<ZoneDto>> GetZonesAsync();
        Task<List<CityDto>> GetCitiesAsync(int stateId);

        Task<string> ManageCorporateTypeAsync(object command, char action);
        Task<List<CorporateTypeMasterDto>> FetchCorporateTypeAsync();
        Task<string> ManageAdmissionTypeAsync(object command, char action);
        Task<List<AdmissionTypeMasterDto>> FetchAdmissionTypeAsync();
        Task<string> ManageCityAsync(object command, char action);
        Task<List<CityMasterDto>> FetchCitiesAsync();
        Task<string> ManageCorporatePlanAsync(object command, char action);
        Task<List<CorporatePlanDto>> FetchCorporatePlansAsync();
        Task<string> ManageServiceRenewalAsync(int? id, string name, string desc, int userId, string action);
        Task<List<CorporateServiceRenewalDto>> FetchServiceRenewalsAsync();
        Task<string> ManageDocumentTypeAsync(int? id, string name, string desc, string owner, int userId, string action);
        Task<List<DocumentTypeDto>> FetchDocumentTypesAsync();
        Task<string> ManageGenderAsync(object command, char action);
        Task<List<GenderDto>> FetchGendersAsync();
        Task<string> ManageIdentificationTypeAsync(object command, char action);
        Task<List<IdentificationTypeDto>> FetchIdentificationTypesAsync();
    }
}

