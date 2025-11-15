using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Exceptions;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatient
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, PatientDto>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetPatientQueryHandler(IPatientRepository patientRepository,
            ILoggedInUserService loggedInUserService,
            IMapper mapper)
        {
            _patientRepository = patientRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException();

            var patient = await _patientRepository.GetPatientByIdAsync(request.PatientId);
            if (patient == null)
                throw new NotFoundException(nameof(PatientDto), request.PatientId);

            var claimflows = await _patientRepository.GetClaimFlowByPatientIdAsync(request.PatientId);
            var patientdocs = await _patientRepository.GetPatientDocsByPatientIdAsync(request.PatientId);
            var claimFlowDtos = _mapper.Map<List<ClaimFlowDto>>(claimflows);

            foreach (var claimFlowDto in claimFlowDtos)
            {
                var claimFlowDocs = await _patientRepository.GetClaimFlowDocsByClaimFlowIdAsync(claimFlowDto.ClaimFlowId);
                claimFlowDto.ClaimFlowDocs = _mapper.Map<List<ClaimFlowDocDto>>(claimFlowDocs);
            }

            var patientDocList = new List<PatientDocDto>();
            foreach (var doc in patientdocs)
            {
                patientDocList.Add(new PatientDocDto
                {
                    PatientId = doc.PatientId,
                    FileName = doc.DocName,
                    FileUrl = doc.DocUri,
                    DocumentType = doc.Title,
                    Id = doc.PatientDocId,
                    PatientDocId = doc.PatientDocId,
                    UploadProgress = 100
                });
            }

            var treatingDoctor = patient.TreatingDoctorDetails;
            var result = new PatientDto
            {
                AccidentCase = patient.AccidentCase,
                AccidentFirNumber = patient.AccidentFirNumber,
                AgeMonths = patient.AgeMonths.HasValue ? patient.AgeMonths.Value.ToString() : string.Empty,
                AgeYears = patient.AgeYears.HasValue ? patient.AgeYears.Value.ToString() : string.Empty,
                CompanyName = patient.CompanyName,
                ContactNumber = patient.ContactNumber,
                DateOfBirth = patient.DateOfBirth,
                CurrentlyWithOtherMedician = patient.CurrentlyWithOtherMedician.HasValue && patient.CurrentlyWithOtherMedician.Value ? "Yes" : "No",
                EmployeeId = patient.EmployeeId,
                FamilyPhysician = patient.HasFamilyPhysician.HasValue && patient.HasFamilyPhysician.Value ? "Yes" : "No",
                FamilyPhysicianContact = patient.FamilyPhysicianContact,
                AccidentInjuryDate = patient.AccidentInjuryDate,
                AccidentIsRta = patient.AccidentIsRta,
                AccidentReportedToPolice = patient.AccidentReportedToPolice,
                AdmissionDate = patient.AdmissionDate,
                AdmissionTime = patient.AdmissionTime,
                AdmissionType = patient.AdmissionType,
                AlcoholDrugAbuse = patient.AlcoholDrugAbuse,
                AlcoholDrugAbuseMonths = patient.AlcoholDrugAbuseMonths.HasValue ? patient.AlcoholDrugAbuseMonths.Value.ToString() : string.Empty,
                AlcoholDrugAbuseYears = patient.AlcoholDrugAbuseYears.HasValue ? patient.AlcoholDrugAbuseYears.Value.ToString() : string.Empty,
                AllInclusivePackageRs = patient.AllInclusivePackageRs,
                HospitalId = patient.HospitalId,
                IllnessNature = patient.IllnessNature,
                InsuranceCompanyId = patient.InsuranceCompanyId,
                InsuranceCompanyName = patient.InsuranceCompany != null ? patient.InsuranceCompany.Name : string.Empty,
                InsuranceCompFaxNumber = patient.InsuranceCompany != null ? patient.InsuranceCompany.FaxNumber : string.Empty,
                InsuranceCompPhoneNumber = patient.InsuranceCompany != null ? patient.InsuranceCompany.ContactNumber : string.Empty,
                InsuredCardNumber = patient.InsuredCardNumber,
                PatientName = patient.PatientName,
                PolicyNumber = patient.PolicyNumber,
                RelativeContactNumber = patient.RelativeContactNumber,
                TpaId = patient.Tpaid,
                TpaName = patient.Tpa != null ? patient.Tpa.Name : string.Empty,
                TpaFaxNumber = patient.Tpa != null ? patient.Tpa.FaxNumber : string.Empty,
                TpaPhoneNumber = patient.Tpa != null ? patient.Tpa.ContactNumber : string.Empty,
                AsthmaCopd = patient.AsthmaCopd,
                AsthmaCopdMonths = patient.AsthmaCopdMonths.HasValue ? patient.AsthmaCopdMonths.Value.ToString() : string.Empty,
                AsthmaCopdYears = patient.AsthmaCopdYears.HasValue ? patient.AsthmaCopdYears.Value.ToString() : string.Empty,
                Cancer = patient.Cancer,
                CancerMonths = patient.CancerMonths.HasValue ? patient.CancerMonths.Value.ToString() : string.Empty,
                CancerYears = patient.CancerYears.HasValue ? patient.CancerYears.Value.ToString() : string.Empty,
                Diabetes = patient.Diabetes,
                DiabetesMonths = patient.DiabetesMonths.HasValue ? patient.DiabetesMonths.Value.ToString() : string.Empty,
                DiabetesYears = patient.DiabetesYears.HasValue ? patient.DiabetesYears.Value.ToString() : string.Empty,
                Hypertension = patient.Hypertension,
                HypertensionMonths = patient.HypertensionMonths.HasValue ? patient.HypertensionMonths.Value.ToString() : string.Empty,
                HypertensionYears = patient.HypertensionYears.HasValue ? patient.HypertensionYears.Value.ToString() : string.Empty,
                ClaimStatus = patient.ClaimStatus,
                ClinicalFindings = patient.ClinicalFindings,
                ConsultationCharges = patient.ConsultationCharges,
                DeliveryDate = patient.DeliveryDate,
                DischargeDate = null,
                DischargeTypeId = patient.DischargeTypeId,
                DrugAdministrationRoute = patient.DrugAdministrationRoute,
                ExpectedCost = patient.ExpectedCost,
                ExpectedInvestigationCost = patient.ExpectedInvestigationCost,
                ExpectedStayDays = patient.ExpectedStayDays.HasValue ? patient.ExpectedStayDays.Value.ToString() : string.Empty,
                FamilyPhysicianName = patient.FamilyPhysicianName,
                FirstConsultationDate = patient.FirstConsultationDate,
                Gender = patient.Gender,
                HeartDisease = patient.HeartDisease,
                HeartDiseaseMonths = patient.HeartDiseaseMonths.HasValue ? patient.HeartDiseaseMonths.Value.ToString() : string.Empty,
                HeartDiseaseYears = patient.HeartDiseaseYears.HasValue ? patient.HeartDiseaseYears.Value.ToString() : string.Empty,
                HivStdAilment = patient.HivStdAilment,
                HivStdAilmentMonths = patient.HivStdAilmentMonths.HasValue ? patient.HivStdAilmentMonths.Value.ToString() : string.Empty,
                HivStdAilmentYears = patient.HivStdAilmentYears.HasValue ? patient.HivStdAilmentYears.Value.ToString() : string.Empty,
                Hyperlipidemia = patient.Hyperlipidemia,
                HyperlipidemiaMonths = patient.HyperlipidemiaMonths.HasValue ? patient.HyperlipidemiaMonths.Value.ToString() : string.Empty,
                HyperlipidemiaYears = patient.HyperlipidemiaYears.HasValue ? patient.HyperlipidemiaYears.Value.ToString() : string.Empty,
                Osteoarthritis = patient.Osteoarthritis,
                OsteoarthritisMonths = patient.OsteoarthritisMonths.HasValue ? patient.OsteoarthritisMonths.Value.ToString() : string.Empty,
                Icd10PcsCode = patient.Icd10PcsCode,
                OsteoarthritisYears = patient.OsteoarthritisYears.HasValue ? patient.OsteoarthritisYears.Value.ToString() : string.Empty,
                Icd11Code = patient.Icd11Code,
                IcuCharges = patient.IcuCharges,
                InjuryOccurrence = patient.InjuryOccurrence,
                OtherAilmentDetails = patient.OtherAilmentDetails,
                InvestigationDetails = patient.InvestigationDetails,
                MaternityCase = patient.MaternityCase,
                MaternityType = patient.MaternityType,
                MedicinesConsumables = patient.MedicinesConsumables,
                OtCharges = patient.OtCharges,
                OtherInsuranceCompany = patient.OtherInsuranceCompany,
                OtherTreatmentDetails = patient.OtherTreatmentDetails,
                PastHistoryAilment = patient.PastHistoryAilment,
                PerDayRoomRent = patient.PerDayRoomRent,
                PresentAilmentDuration = patient.PresentAilmentDuration.HasValue ? patient.PresentAilmentDuration.Value.ToString() : string.Empty,
                ProvisionalDiagnosis = patient.ProvisionalDiagnosis,
                PatientId = patient.PatientId,
                RoomType = patient.RoomType,
                SubstanceAbuse = patient.SubstanceAbuse,
                SubstanceAbuseReports = patient.SubstanceAbuseReports,
                SurgicalDetails = patient.SurgicalDetails,
                TotalExpectedCost = patient.TotalExpectedCost,
                TpaClaimId = patient.TpaclaimId,
                TreatmentLine = patient.TreatmentLine,
                SubmitedDate = patient.SubmitedDate,
                TreatingDoctorId = patient.TreatingDoctorId,
                TreatingDoctorContact = treatingDoctor != null ? treatingDoctor.ContactNumber : string.Empty,
                TreatingDoctorName = treatingDoctor != null ? treatingDoctor.DoctorName : string.Empty,
                TreatingDoctorNameDeclaration = treatingDoctor != null ? treatingDoctor.DoctorName : string.Empty,
                DoctorQualification = treatingDoctor != null ? treatingDoctor.Qualification : string.Empty,
                DoctorRegistrationNumber = treatingDoctor != null ? treatingDoctor.RegistrationNumber : string.Empty,
                ClaimFlows = claimFlowDtos,
                Documents = patientDocList
            };
            return result;
        }
    }
}
