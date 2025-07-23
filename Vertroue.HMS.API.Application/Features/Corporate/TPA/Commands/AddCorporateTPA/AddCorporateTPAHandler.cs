using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.AddCorporateTPA
{
    public class AddCorporateTPAHandler : IRequestHandler<AddCorporateTPACommand, string>
    {
        private readonly ICorporateRepository _repository;

        public AddCorporateTPAHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporateTPACommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddCorporateTPAAsync(request);
        }
    }
}
