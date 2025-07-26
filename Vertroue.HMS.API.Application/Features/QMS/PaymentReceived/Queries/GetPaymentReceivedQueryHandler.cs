using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries
{
    public class GetPaymentReceivedQueryHandler : IRequestHandler<GetPaymentReceivedQuery, FetchPaymentReceivedResponse>
    {
        private readonly IQMSDataRepository _repository;

        public GetPaymentReceivedQueryHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<FetchPaymentReceivedResponse> Handle(GetPaymentReceivedQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporatePendingPaymentReceivedAsync(request);
        }
    }
}
