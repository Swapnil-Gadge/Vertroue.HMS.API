using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Add
{
    public class AddCorporateTypeMasterHandler : IRequestHandler<AddCorporateTypeMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddCorporateTypeMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporateTypeMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporateTypeAsync(request, 'I');
        }
    }
}