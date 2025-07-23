using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify
{
    public class ModifyCorporateInsurerHandler : IRequestHandler<ModifyCorporateInsurerCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public ModifyCorporateInsurerHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ModifyCorporateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ModifyCorporateInsurerAsync(request);
        }
    }
}
