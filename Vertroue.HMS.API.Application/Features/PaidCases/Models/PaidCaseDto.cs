namespace Vertroue.HMS.API.Application.Features.PaidCases.Models
{
    public class PaidCaseDto
    {
        public int CaseId { get; set; }
        public string PatientName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
