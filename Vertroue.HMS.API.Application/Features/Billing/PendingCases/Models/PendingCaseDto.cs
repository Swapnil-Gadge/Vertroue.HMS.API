namespace Vertroue.HMS.API.Application.Features.Billing.PendingCases.Models
{
    public class PendingCaseDto
    {
        public int CaseId { get; set; }
        public string PatientName { get; set; }
        public decimal PendingAmount { get; set; }
        public string Status { get; set; }
    }
}
