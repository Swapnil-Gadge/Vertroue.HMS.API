using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.DeactivateCorporateTPACommand
{
    public class DeactivateCorporateTPAHandler : IRequestHandler<DeactivateCorporateTPACommand, string>
    {
        private readonly ICorporateRepository _repository;

        public DeactivateCorporateTPAHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateCorporateTPACommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeactivateCorporateTPAAsync(request);
        }
    }
}
