using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Commands
{
    public class UpdateCorporatePendingPaymentReceivedCommand : IRequest<string>
    {
        public int CorporateId { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public string Urtno { get; set; }
        public string PayReceivedAmount { get; set; }
        public string TdsAmount { get; set; }
        public string TdsPercentage { get; set; }
        public string TdsReceivedDate { get; set; }
        public string PaymentRemarks { get; set; }
        public int StatusId { get; set; }
        public string StatusRemark { get; set; }
    }
}
