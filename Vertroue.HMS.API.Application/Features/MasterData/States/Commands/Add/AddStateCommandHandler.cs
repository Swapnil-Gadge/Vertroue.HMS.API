using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Add
{
    public class AddStateCommandHandler : IRequestHandler<AddStateCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddStateCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddStateCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStateMasterAsync(request, 'I');
        }
    }
}
