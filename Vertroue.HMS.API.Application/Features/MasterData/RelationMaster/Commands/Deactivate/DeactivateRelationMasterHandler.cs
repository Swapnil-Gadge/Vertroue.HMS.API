using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Deactivate
{
    public class DeactivateRelationMasterHandler : IRequestHandler<DeactivateRelationMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateRelationMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateRelationMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageRelationMasterAsync(request, 'D');
        }
    }
}
