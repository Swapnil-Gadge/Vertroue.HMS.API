
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Deactivate
{
    public class DeactivateInsurerCommandHandler : IRequestHandler<DeactivateInsurerCommand, bool>
    {
        private readonly IMasterDataRepository _repository;

        public DeactivateInsurerCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeactivateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DisableInsuranceCompany(request.InsuranceCompanyId);
        }
    }
}
