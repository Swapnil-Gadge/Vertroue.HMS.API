using MediatR;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlow
{
    public class CreateClaimFlowCommand : IRequest<ClaimFlowDto>
    {
        public int ClaimFlowId { get; set; }

        public int HospitalId { get; set; }

        public int PatientId { get; set; }

        public string? Stage { get; set; }

        public int? ClaimId { get; set; }

        public DateTime? SubmittedDate { get; set; }

        public decimal? ApprovedAmount { get; set; }

        public decimal? ClaimPatientPayableAmount { get; set; }

        public decimal? FinalSettlementAmount { get; set; }

        public int? TreatmentId { get; set; }

        public int? TreatmentMasterId { get; set; }

        public string? DeathCause { get; set; }

        public string? TreatmentName { get; set; }

        public DateTime? DischargeDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public TimeSpan? DischargeTime { get; set; }

        public TimeSpan? DeathTime { get; set; }

        public string? PackageName { get; set; }

        public decimal? TPAPayablePercent { get; set; }

        public int? PackageMasterId { get; set; }

        public bool? IsEnhancement { get; set; }

        public string? TreatmentDescription { get; set; }

        public decimal? EstimatedAmount { get; set; }

        public decimal? TreatmentPatientPayableAmount { get; set; }

        public int? ResponseId { get; set; }

        public int? TparesponseCodeId { get; set; }

        public string? ResponseNotes { get; set; }

        public string? QueryCode { get; set; }

        public string? ResponseType { get; set; }

        public string? ResponseDocName { get; set; }

        public string? ResponseDocument { get; set; }

        public string? TpaApprovalReference { get; set; }

        public string? DischargeType { get; set; }

        public decimal? AmountCouldNotRecovered { get; set; }

        public string? ReceiptNumber { get; set; }

        public DateTime? SettlementDate { get; set; }

        public int? FileFlowId { get; set; }

        public string? FileFlowStatus { get; set; }

        public DateTime? FileFlowDateUpdated { get; set; }

        public List<int> ClaimFlowDocIds { get; set; }
    }
}
