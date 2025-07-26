using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Model;

namespace Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries
{
    public class FetchPaymentReceivedResponse
    {
        public List<PaymentReceivedCaseDto> PendingPayments { get; set; }
        public List<PaymentReceivedStatusDto> Statuses { get; set; }
        public List<PaymentReceivedEstimationDto> Estimations { get; set; }
        public List<PaymentReceivedTrackerDto> Trackers { get; set; }
        public List<PaymentReceivedCaseTypeDto> CaseTypes { get; set; }
    }
}
