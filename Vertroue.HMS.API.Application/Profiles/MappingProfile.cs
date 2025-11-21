using AutoMapper;
using Vertroue.HMS.API.Application.Features.Categories.Commands.CreateCategory;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesList;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesListWithProducts;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlow;
using Vertroue.HMS.API.Application.Features.Patient.Commands.UpdateClaimFlow;
using Vertroue.HMS.API.Application.Models.Hospital;
using Vertroue.HMS.API.Application.Models.Master;
using Vertroue.HMS.API.Application.Models.Patient;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Product, CategoryProductDto>().ReverseMap();
            
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryProductListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<InsuranceCompany, InsurerDto>().ReverseMap();
            CreateMap<Tpa, TpaMasterDto>().ReverseMap();

            CreateMap<InsuranceCompany, InsuranceCompanyDto>().ReverseMap();
            CreateMap<Tpa, TpaDto>().ReverseMap();

            CreateMap<CitiesMaster, CityDto>().ReverseMap();
            CreateMap<StatesMaster, StateDto>().ReverseMap();
            CreateMap<AdmissionType, AdmissionTypeDto>().ReverseMap();
            CreateMap<ClaimStatusMaster, ClaimStatusDto>().ReverseMap();
            CreateMap<DischargeType, DischargeTypeDto>().ReverseMap();
            CreateMap<LineOfTreatment, LineOfTreatmentDto>().ReverseMap();
            CreateMap<MedicalHistoriesMaster, MedicalHistoryMasterDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<EmpanelledInsuranceCompany, EmpanelledInsuranceCompanyDto>().ReverseMap();
            CreateMap<EmpanelledTpa, EmpanelledTpaDto>().ReverseMap();
            CreateMap<Hospital, HospitalDto>().ReverseMap();
            CreateMap<DoctorsMaster, DoctorDto>().ReverseMap();
            CreateMap<TreatmentsMaster, TreatmentDto>().ReverseMap();
            CreateMap<PackagesMaster, PackageDto>().ReverseMap();
            CreateMap<ClaimFlow, ClaimFlowDto>();
            CreateMap<ClaimFlowDoc, ClaimFlowDocDto>().ReverseMap();
            CreateMap<CreateClaimFlowCommand, ClaimFlow>();
            CreateMap<UpdateClaimFlowCommand, ClaimFlow>();
            CreateMap<Icd10cmcode, ICD10CMCodeDto>().ReverseMap();
            CreateMap<Icd10pcscode, ICD10PCSCodeDto>().ReverseMap();
        }
    }
}
