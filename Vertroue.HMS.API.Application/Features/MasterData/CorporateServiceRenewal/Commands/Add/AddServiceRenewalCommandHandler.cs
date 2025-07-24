using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Commands.Add
{
    public class AddServiceRenewalCommandHandler : IRequestHandler<AddServiceRenewalCommand, string>
    {
        private readonly IMasterDataRepository _repo;

        public AddServiceRenewalCommandHandler(IMasterDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(AddServiceRenewalCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ManageServiceRenewalAsync(
                request.ServiceRenewalId,
                request.ServiceRenewalName,
                request.ServiceRenewalDesc,
                request.UserId,
                "I"
            );
        }
    }
}