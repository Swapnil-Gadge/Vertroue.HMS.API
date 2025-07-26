
using Vertroue.HMS.API.Application.Features.QMS.QMSControl.Model;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries
{
    public class FetchAllQMSControlsListResponse
    {
        public List<QMSInsurerDto> Insurers { get; set; } = new();
        public List<QMSTPADto> TPAs { get; set; } = new();
        public List<QMSRelationDto> Relations { get; set; } = new();
        public List<QMSGenderDto> Genders { get; set; } = new();
        public List<QMSIdentificationTypeDto> IdentificationTypes { get; set; } = new();
        public List<QMSAdmissionTypeDto> AdmissionTypes { get; set; } = new();
        public List<QMSStatusControlDto> Statuses { get; set; } = new();
        public List<QMSCaseTypeControlDto> CaseTypes { get; set; } = new();

        public List<QMSPatientDto> PatientList1 { get; set; } = new();
        public List<QMSDynamicDataDto> DynamicData1 { get; set; } = new();

        public List<QMSPatientDto> PatientList2 { get; set; } = new();
        public List<QMSDynamicDataDto> DynamicData2 { get; set; } = new();

        public List<QMSPatientDto> PatientList3 { get; set; } = new();
        public List<QMSDynamicDataDto> DynamicData3 { get; set; } = new();

        public List<QMSPatientDto> PatientList4 { get; set; } = new();
        public List<QMSDynamicDataDto> DynamicData4 { get; set; } = new();
    }

}
