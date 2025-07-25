using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.States.Model;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Model;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Zones.Model;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IMasterDataRepository
    {
        //Task<List<StateDto>> GetStatesAsync();
        //Task<List<ZoneDto>> GetZonesAsync();
        //Task<List<CityDto>> GetCitiesAsync(int stateId);

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
        Task<string> ManageInsurerAsync(object request, char action);
        Task<List<InsurerDto>> FetchInsurersAsync();
        Task<string> ManageRelationMasterAsync(dynamic data, char action);
        Task<List<RelationMasterDto>> FetchRelationMasterAsync();
        Task<string> ManageStateMasterAsync(object request, char action);
        Task<List<StateDto>> FetchStatesAsync();
        Task<string> ManageStatusMasterAsync(object request, char action);
        Task<List<StatusMasterDto>> FetchStatusMasterAsync(int userId);
        Task<string> ManageStatusProcessFlowAsync(object request, char action);
        Task<List<StatusProcessFlowDto>> FetchStatusProcessFlowAsync();
        Task<string> ManageTpaMasterAsync(object request, char action);
        Task<List<TpaMasterDto>> FetchTpaMasterAsync();
        Task<string> ManageUserRoleMasterAsync(object request, char action);
        Task<List<UserRoleDto>> FetchUserRoleMasterAsync();

        Task<string> ManageUserTypeAsync(object request, char action);
        Task<List<UserTypeDto>> FetchUserTypeAsync();

        Task<string> ManageZoneMasterAsync(object request, char action);
        Task<List<ZoneDto>> FetchZoneMasterAsync();
    }
}

