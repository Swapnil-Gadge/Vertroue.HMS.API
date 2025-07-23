using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.ModifyCorporateTPA
{
    public class ModifyCorporateTPAHandler : IRequestHandler<ModifyCorporateTPACommand, string>
    {
        private readonly ICorporateRepository _repository;

        public ModifyCorporateTPAHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ModifyCorporateTPACommand request, CancellationToken cancellationToken)
        {
            return await _repository.ModifyCorporateTPAAsync(request);
        }
    }
}
