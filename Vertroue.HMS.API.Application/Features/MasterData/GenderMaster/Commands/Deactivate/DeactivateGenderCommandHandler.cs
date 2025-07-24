using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Deactivate
{
    public class DeactivateGenderCommandHandler : IRequestHandler<DeactivateGenderCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateGenderCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateGenderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageGenderAsync(request, 'D');
        }
    }
}