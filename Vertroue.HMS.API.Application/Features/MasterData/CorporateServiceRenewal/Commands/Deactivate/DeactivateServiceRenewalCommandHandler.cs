using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Deactivate
{
    public class DeactivateServiceRenewalCommandHandler : IRequestHandler<DeactivateServiceRenewalCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public DeactivateServiceRenewalCommandHandler(IMasterDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(DeactivateServiceRenewalCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageServiceRenewalAsync(
                request.ServiceRenewalId,
                request.ServiceRenewalName,
                request.ServiceRenewalDesc,
                request.UserId,
                "D"
            );
        }
    }
}