using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Commands
{
    public class AddCorporateRenewalHandler : IRequestHandler<AddCorporateRenewalCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public AddCorporateRenewalHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporateRenewalCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddCorporateRenewalAsync(request);
        }
    }
}
