using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries
{
    public class GetPaymentReceivedQuery : IRequest<FetchPaymentReceivedResponse>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
