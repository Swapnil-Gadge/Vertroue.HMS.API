using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Add
{
    public class AddCorporateInsurerHandler : IRequestHandler<AddCorporateInsurerCommand, string>
    {
        private readonly ICorporateRepository _repository;

        public AddCorporateInsurerHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddCorporateInsurerAsync(request);
        }
    }
}
