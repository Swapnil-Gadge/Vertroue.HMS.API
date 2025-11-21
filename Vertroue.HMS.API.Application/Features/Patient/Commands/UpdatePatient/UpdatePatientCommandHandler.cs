using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Patient;
using Vertroue.HMS.API.Application.Contracts.Infrastructure;
using Vertroue.HMS.API.Application.Models.Mail;
using Vertroue.HMS.API.Application.Shared;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UpdatePatientCommandHandler(
            IPatientRepository patientRepository, 
            ILoggedInUserService loggedInUserService,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _emailService = emailService;
            _loggedInUserService = loggedInUserService;
            _patientRepository = patientRepository;
            _configuration = configuration;
        }

        public async Task<PatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.PatientDto.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            var existingPatient = await _patientRepository.GetPatientByIdAsync(request.PatientDto.PatientId, true);
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
                AadharId = patientDto.AadharId,
                AccidentMLC = patientDto.AccidentMLC,
                AccidentSelfDeclaration = patientDto.AccidentSelfDeclaration,
                UniqueId = patientDto.UniqueId,
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
                CreatedBy = existingPatient.CreatedBy,
                CreatedDate = existingPatient.CreatedDate,
            };
            var result = await _patientRepository.UpdatePatientAsync(patient);

            if (patientDto.ClaimStatusChanged.HasValue 
                && patientDto.ClaimStatusChanged.Value)
            {
                var emailRequest = new Email
                {
                    From = _configuration.GetSection(Constant.ClaimManagementEmail).Value!,
                    To = _configuration.GetSection(Constant.VertroueEmailID).Value!.Split(";").ToList(),
                    Subject = "Patient Claim Status Updated",
                    Body = GenerateEmailBody(patientDto)
                };
                await _emailService.SendEmail(emailRequest);
            }
            return new PatientDto
            {
                PatientId = result.PatientId,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                LastUpdatedBy = result.LastUpdatedBy,
                LastUpdatedDate = result.LastUpdatedDate,
            };
        }

        public string GenerateEmailBody(PatientDto patientDto)
        {
            string message = $"<p>The claim status for patient <b>{patientDto.PatientName}</b> for Hospital <b>{patientDto.HospitalName}</b> (ID: {patientDto.PatientId}) has been updated to <b>{patientDto.ClaimStatus}</b>.</p>";
            var supportRequestText = new StringBuilder();
            supportRequestText.Append(@"<!DOCTYPE html>
            <html>
            <body>
            <div>");
            supportRequestText.Append("Hello Team,");
            supportRequestText.AppendLine("<br/>");
            supportRequestText.AppendLine(message);
            supportRequestText.AppendLine($"<p><a href=\"{_configuration.GetSection(Constant.AppLink).Value}/patients/{patientDto.PatientId}\" target =\"_blank\"><span data-offset-key=\"aftaq-1-0\"><span data-text=\"true\">Click here</a> to navigate to patient record for more details</p>");
            supportRequestText.AppendLine("Best wishes,<br/>");
            supportRequestText.AppendLine("Support Team");
            supportRequestText.AppendLine("</div></body></html>");
            return supportRequestText.ToString();
        }
    }
}
