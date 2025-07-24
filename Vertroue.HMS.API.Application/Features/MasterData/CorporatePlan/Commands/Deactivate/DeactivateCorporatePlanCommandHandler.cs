
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Deactivate
{
    public class DeactivateCorporatePlanCommandHandler : IRequestHandler<DeactivateCorporatePlanCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateCorporatePlanCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeactivateCorporatePlanCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporatePlanAsync(request, 'D');
        }
    }
}
