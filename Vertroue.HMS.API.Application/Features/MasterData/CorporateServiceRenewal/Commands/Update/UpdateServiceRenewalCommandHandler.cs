using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Update
{
    public class UpdateServiceRenewalCommandHandler : IRequestHandler<UpdateServiceRenewalCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public UpdateServiceRenewalCommandHandler(IMasterDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(UpdateServiceRenewalCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageServiceRenewalAsync(
                request.ServiceRenewalId,
                request.ServiceRenewalName,
                request.ServiceRenewalDesc,
                request.UserId,
                "U"
            );
        }
    }
}