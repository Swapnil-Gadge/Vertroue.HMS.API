namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Model
{
    public class QMSMainRecordDto
    {
        public int TblId { get; set; }
        public int CaseId { get; set; }
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public int TPAId { get; set; }
        public string TPAName { get; set; }
        public string PatientName { get; set; }
        public string DOA { get; set; }
        public string ActualDOD { get; set; }
        public decimal TotalApprovedAmount { get; set; }
        public string CaseFileSentDate { get; set; }
        public string PaymentStatus { get; set; }
        public int CaseDetailsId { get; set; }
    }

    public class QMSStatusDto
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }

    public class QMSCaseDetailsDto
    {
        public int TblId { get; set; }
        public int CaseId { get; set; }
        public int CorporateId { get; set; }
        public string CorporateName { get; set; }
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public int TPAId { get; set; }
        public string TPAName { get; set; }
        public int CaseDetailsId { get; set; }
        public string DOA { get; set; }
        public string ExpectedDOD { get; set; }
        public int NoOfDaysStay { get; set; }
        public string ActualDOD { get; set; }
        public decimal EstimatedAmount { get; set; }
    }

    public class QMSStatusTrackerDto
    {
        public int TblId { get; set; }
        public int CaseStatusTrackerId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusRemarks { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string DocumentLink { get; set; }
    }

    public class QMSCaseTypeDto
    {
        public string CaseTypeCode { get; set; }
        public string CaseTypeName { get; set; }
    }    
}
