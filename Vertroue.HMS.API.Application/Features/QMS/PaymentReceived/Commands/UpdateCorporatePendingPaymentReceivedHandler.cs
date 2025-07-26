using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Commands
{
    public class UpdateCorporatePendingPaymentReceivedHandler : IRequestHandler<UpdateCorporatePendingPaymentReceivedCommand, string>
    {
        private readonly IQMSDataRepository _repository;

        public UpdateCorporatePendingPaymentReceivedHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateCorporatePendingPaymentReceivedCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateCorporatePendingPaymentReceivedAsync(request);
        }
    }
}
