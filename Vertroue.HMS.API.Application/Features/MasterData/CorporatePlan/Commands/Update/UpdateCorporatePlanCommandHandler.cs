
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Update
{
    public class UpdateCorporatePlanCommandHandler : IRequestHandler<UpdateCorporatePlanCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateCorporatePlanCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateCorporatePlanCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporatePlanAsync(request, 'U');
        }
    }
}
