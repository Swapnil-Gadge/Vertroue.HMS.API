using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Update
{
    public class UpdateRelationMasterHandler : IRequestHandler<UpdateRelationMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateRelationMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateRelationMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageRelationMasterAsync(request, 'U');
        }
    }
}
