using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Update
{
    public class UpdateCorporateTypeMasterHandler : IRequestHandler<UpdateCorporateTypeMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateCorporateTypeMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateCorporateTypeMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporateTypeAsync(request, 'U');
        }
    }
}