using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Update
{
    public class UpdateQMSCaseCommand : IRequest<string>
    {
        public int StatusId { get; set; }
        public int CaseId { get; set; }
        public string DOA { get; set; }
        public string DOD { get; set; }
        public string ClaimAmount { get; set; }
        public string ClaimDocPath { get; set; }
        public string StatusRemark { get; set; }
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public string UserType { get; set; }
        public int CorporateId { get; set; }
        public int CaseDetailsId { get; set; }
        public string ApprovedAmt { get; set; }
        public string ApprovalRemarks { get; set; }
    }
}
