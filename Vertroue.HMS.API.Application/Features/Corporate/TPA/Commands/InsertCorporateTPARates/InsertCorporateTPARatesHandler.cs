using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.InsertCorporateTPARates
{
    public class InsertCorporateTPARatesHandler : IRequestHandler<InsertCorporateTPARatesCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public InsertCorporateTPARatesHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(InsertCorporateTPARatesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.InsertCorporateTPARatesAsync(request);
        }
    }
}
