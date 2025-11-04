using Vertroue.HMS.API.Application.Models.Hospital;
using Vertroue.HMS.API.Application.Models.Master;

namespace Vertroue.HMS.API.Application.Features.MasterData.MasterData.Queries.GetMasterData
{
    public class GetMasterDataQueryResponse
    {
        public List<CityDto> Cities { get; set; }

        public List<StateDto> States { get; set; }

        public List<AdmissionTypeDto> AdmissionTypes { get; set; }

        public List<ClaimStatusDto> ClaimStatuses { get; set; }

        public List<DischargeTypeDto> DischargeTypes { get; set; }

        public List<LineOfTreatmentDto> LineOfTreatments { get; set; }

        public List<MedicalHistoryMasterDto> MedicalHistoryMasters { get; set; }

        public List<RoomTypeDto> RoomTypes { get; set; }

        public List<TpaDto> Tpas { get; set; }

        public List<InsuranceCompanyDto> InsuranceCompanies { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
    }
}
