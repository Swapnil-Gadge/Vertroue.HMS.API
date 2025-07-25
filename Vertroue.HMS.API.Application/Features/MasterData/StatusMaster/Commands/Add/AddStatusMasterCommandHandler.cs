using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Add
{
    public class AddStatusMasterCommandHandler : IRequestHandler<AddStatusMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddStatusMasterCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddStatusMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusMasterAsync(request, 'I');
        }
    }
}
