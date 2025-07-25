using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Commands.Add
{
    public class AddRelationMasterHandler : IRequestHandler<AddRelationMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddRelationMasterHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddRelationMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageRelationMasterAsync(request, 'I');
        }
    }
}
