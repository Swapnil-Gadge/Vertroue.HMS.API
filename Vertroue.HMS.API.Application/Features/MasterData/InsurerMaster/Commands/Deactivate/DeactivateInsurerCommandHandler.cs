
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Deactivate
{
    public class DeactivateInsurerCommandHandler : IRequestHandler<DeactivateInsurerCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateInsurerCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageInsurerAsync(request, 'D');
        }
    }
}
