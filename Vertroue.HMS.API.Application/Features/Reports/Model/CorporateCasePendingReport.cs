namespace Vertroue.HMS.API.Application.Features.Reports.Model
{
    public class CorporateCasePendingReportDto
    {
        public int TblId { get; set; }
        public int CaseId { get; set; }
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public int TPAId { get; set; }
        public string TPAName { get; set; }
        public string PatientName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Relation { get; set; }
        public string AdmissionType { get; set; }
        public string DOA { get; set; }
        public string ExpectedDOD { get; set; }
        public int NoOfDays { get; set; }
        public string ActualDOD { get; set; }
        public decimal EstimatedAmount { get; set; }
        public string PreviousConsultationNotes { get; set; }
        public decimal ApprovalAmount { get; set; }
        public string ApprovalRemarks { get; set; }
        public decimal DeductionAmount { get; set; }
        public string DeductionRemarks { get; set; }
        public string CaseStatus { get; set; }
    }
}
