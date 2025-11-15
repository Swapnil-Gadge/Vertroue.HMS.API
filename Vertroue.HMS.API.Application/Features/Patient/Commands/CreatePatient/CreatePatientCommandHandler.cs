using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public CreatePatientCommandHandler(IPatientRepository patientRepository, ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.PatientDto.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            var patientDto = request.PatientDto;
            var patient = new Domain.Entities.Patient
            {
                AccidentCase = patientDto.AccidentCase,
                AccidentFirNumber = patientDto.AccidentFirNumber,
                AgeMonths = string.IsNullOrEmpty(patientDto.AgeMonths) ? null : Convert.ToInt32(patientDto.AgeMonths),
                AgeYears = string.IsNullOrEmpty(patientDto.AgeYears) ? null : Convert.ToInt32(patientDto.AgeYears),
                CompanyName = patientDto.CompanyName,
                ContactNumber = patientDto.ContactNumber,
                DateOfBirth = patientDto.DateOfBirth,
                CurrentlyWithOtherMedician = patientDto.CurrentlyWithOtherMedician == "Yes" ? true : false,
                EmployeeId = patientDto.EmployeeId,
                HasFamilyPhysician = patientDto.FamilyPhysician == "Yes" ? true : false,
                FamilyPhysicianContact = patientDto.FamilyPhysicianContact,
                AccidentInjuryDate = patientDto.AccidentInjuryDate,
                AccidentIsRta = patientDto.AccidentIsRta,
                AccidentReportedToPolice = patientDto.AccidentReportedToPolice,
                AdmissionDate = patientDto.AdmissionDate,
                AdmissionTime = patientDto.AdmissionTime,
                AdmissionType = patientDto.AdmissionType,
                AlcoholDrugAbuse = patientDto.AlcoholDrugAbuse,
                AlcoholDrugAbuseMonths = string.IsNullOrEmpty(patientDto.AlcoholDrugAbuseMonths) ? null : Convert.ToInt32(patientDto.AlcoholDrugAbuseMonths),
                AlcoholDrugAbuseYears = string.IsNullOrEmpty(patientDto.AlcoholDrugAbuseYears) ? null : Convert.ToInt32(patientDto.AlcoholDrugAbuseYears),
                AllInclusivePackageRs = patientDto.AllInclusivePackageRs,
                HospitalId = patientDto.HospitalId,
                IllnessNature = patientDto.IllnessNature,
                InsuranceCompanyId = patientDto.InsuranceCompanyId,
                InsuredCardNumber = patientDto.InsuredCardNumber,
                PatientName = patientDto.PatientName,
                PolicyNumber = patientDto.PolicyNumber,
                RelativeContactNumber = patientDto.RelativeContactNumber,
                Tpaid = patientDto.TpaId,
                AsthmaCopd = patientDto.AsthmaCopd,
                AsthmaCopdMonths = string.IsNullOrEmpty(patientDto.AsthmaCopdMonths) ? null : Convert.ToInt32(patientDto.AsthmaCopdMonths),
                AsthmaCopdYears = string.IsNullOrEmpty(patientDto.AsthmaCopdYears) ? null : Convert.ToInt32(patientDto.AsthmaCopdYears),
                Cancer = patientDto.Cancer,
                CancerMonths = string.IsNullOrEmpty(patientDto.CancerMonths) ? null : Convert.ToInt32(patientDto.CancerMonths),
                CancerYears = string.IsNullOrEmpty(patientDto.CancerYears) ? null : Convert.ToInt32(patientDto.CancerYears),
                Diabetes = patientDto.Diabetes,
                DiabetesMonths = string.IsNullOrEmpty(patientDto.DiabetesMonths) ? null : Convert.ToInt32(patientDto.DiabetesMonths),
                DiabetesYears = string.IsNullOrEmpty(patientDto.DiabetesYears) ? null : Convert.ToInt32(patientDto.DiabetesYears),
                Hypertension = patientDto.Hypertension,
                HypertensionMonths = string.IsNullOrEmpty(patientDto.HypertensionMonths) ? null : Convert.ToInt32(patientDto.HypertensionMonths),
                HypertensionYears = string.IsNullOrEmpty(patientDto.HypertensionYears) ? null : Convert.ToInt32(patientDto.HypertensionYears),
                ClaimStatus = patientDto.ClaimStatus,
                SubmitedDate = patientDto.SubmitedDate,
                ClinicalFindings = patientDto.ClinicalFindings,
                ConsultationCharges = patientDto.ConsultationCharges,
                DeliveryDate = patientDto.DeliveryDate,
                DischargeDate = null,
                DischargeTypeId = patientDto.DischargeTypeId,
                DrugAdministrationRoute = patientDto.DrugAdministrationRoute,
                ExpectedCost = patientDto.ExpectedCost,
                ExpectedInvestigationCost = patientDto.ExpectedInvestigationCost,
                ExpectedStayDays = string.IsNullOrEmpty(patientDto.ExpectedStayDays) ? null : Convert.ToInt32(patientDto.ExpectedStayDays),
                FamilyPhysicianName = patientDto.FamilyPhysicianName,
                FirstConsultationDate = patientDto.FirstConsultationDate,
                Gender = patientDto.Gender,
                HeartDisease = patientDto.HeartDisease,
                HeartDiseaseMonths = string.IsNullOrEmpty(patientDto.HeartDiseaseMonths) ? null : Convert.ToInt32(patientDto.HeartDiseaseMonths),
                HeartDiseaseYears = string.IsNullOrEmpty(patientDto.HeartDiseaseYears) ? null : Convert.ToInt32(patientDto.HeartDiseaseYears),
                HivStdAilment = patientDto.HivStdAilment,
                HivStdAilmentMonths = string.IsNullOrEmpty(patientDto.HivStdAilmentMonths) ? null : Convert.ToInt32(patientDto.HivStdAilmentMonths),
                HivStdAilmentYears = string.IsNullOrEmpty(patientDto.HivStdAilmentYears) ? null : Convert.ToInt32(patientDto.HivStdAilmentYears),
                Hyperlipidemia = patientDto.Hyperlipidemia,
                HyperlipidemiaMonths = string.IsNullOrEmpty(patientDto.HyperlipidemiaMonths) ? null : Convert.ToInt32(patientDto.HyperlipidemiaMonths),
                HyperlipidemiaYears = string.IsNullOrEmpty(patientDto.HyperlipidemiaYears) ? null : Convert.ToInt32(patientDto.HyperlipidemiaYears),
                Osteoarthritis = patientDto.Osteoarthritis,
                OsteoarthritisMonths = string.IsNullOrEmpty(patientDto.OsteoarthritisMonths) ? null : Convert.ToInt32(patientDto.OsteoarthritisMonths),
                Icd10PcsCode = patientDto.Icd10PcsCode,
                OsteoarthritisYears = string.IsNullOrEmpty(patientDto.OsteoarthritisYears) ? null : Convert.ToInt32(patientDto.OsteoarthritisYears),
                Icd11Code = patientDto.Icd11Code,
                IcuCharges = patientDto.IcuCharges,
                InjuryOccurrence = patientDto.InjuryOccurrence,
                OtherAilmentDetails = patientDto.OtherAilmentDetails,
                InvestigationDetails = patientDto.InvestigationDetails,
                MaternityCase = patientDto.MaternityCase,
                MaternityType = patientDto.MaternityType,
                MedicinesConsumables = patientDto.MedicinesConsumables,
                OtCharges = patientDto.OtCharges,
                OtherInsuranceCompany = patientDto.OtherInsuranceCompany,
                OtherTreatmentDetails = patientDto.OtherTreatmentDetails,
                PastHistoryAilment = patientDto.PastHistoryAilment,
                PerDayRoomRent = patientDto.PerDayRoomRent,
                PresentAilmentDuration = string.IsNullOrEmpty(patientDto.PresentAilmentDuration) ? null : Convert.ToInt32(patientDto.PresentAilmentDuration),
                ProvisionalDiagnosis = patientDto.ProvisionalDiagnosis,
                PatientId = patientDto.PatientId,
                RoomType = patientDto.RoomType,
                SubstanceAbuse = patientDto.SubstanceAbuse,
                SubstanceAbuseReports = patientDto.SubstanceAbuseReports,
                SurgicalDetails = patientDto.SurgicalDetails,
                TotalExpectedCost = patientDto.TotalExpectedCost,
                TpaclaimId = patientDto.TpaClaimId,
                TreatmentLine = patientDto.TreatmentLine,
                TreatingDoctorId = patientDto.TreatingDoctorId,
            };
            var result = await _patientRepository.AddPatientAsync(patient);
            await _patientRepository.UpdatePatientDocsFlag(patientDto.AddedDocIds, result.PatientId);
            return new PatientDto
            {
                PatientId = result.PatientId,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                LastUpdatedBy = result.LastUpdatedBy,
                LastUpdatedDate = result.LastUpdatedDate,
            };
        }
    }
}
