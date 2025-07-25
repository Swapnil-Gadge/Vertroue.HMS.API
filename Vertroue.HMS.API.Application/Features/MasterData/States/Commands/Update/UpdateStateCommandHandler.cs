using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.States.Commands.Update
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateStateCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStateMasterAsync(request, 'U');
        }
    }
}
