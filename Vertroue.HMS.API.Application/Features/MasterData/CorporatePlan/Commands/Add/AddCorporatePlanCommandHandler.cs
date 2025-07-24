
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Commands.Add
{
    public class AddCorporatePlanCommandHandler : IRequestHandler<AddCorporatePlanCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddCorporatePlanCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddCorporatePlanCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageCorporatePlanAsync(request, 'I');
        }
    }
}
