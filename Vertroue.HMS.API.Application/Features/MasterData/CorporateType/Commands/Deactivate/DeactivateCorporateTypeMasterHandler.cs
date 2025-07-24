using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Commands.Deactivate
{
    public class DeactivateCorporateTypeMasterHandler : IRequestHandler<DeactivateCorporateTypeMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateCorporateTypeMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateCorporateTypeMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporateTypeAsync(request, 'D');
        }
    }
}