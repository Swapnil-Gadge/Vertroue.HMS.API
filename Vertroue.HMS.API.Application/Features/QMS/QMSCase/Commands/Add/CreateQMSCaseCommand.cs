using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Add
{
    public class CreateQMSCaseCommand : IRequest<string>
    {
        public string AabhaNo { get; set; }
        public int IdentityficationType { get; set; }
        public string Indentification { get; set; }
        public int Insurer { get; set; }
        public int Tpa { get; set; }
        public string PatientName { get; set; }
        public string PolicyHolderName { get; set; }
        public int Gender { get; set; }
        public int AddmissionType { get; set; }
        public int Relation { get; set; }
        public string FilePath { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string StatusRemarks { get; set; }
        public int UserId { get; set; }
        public int CorporateId { get; set; }
        public string PrevConsulNote { get; set; }
        public string PolicyNo { get; set; }
        public string CaseType { get; set; }
        public string UserRole { get; set; }
        public string UserType { get; set; }
    }
}
