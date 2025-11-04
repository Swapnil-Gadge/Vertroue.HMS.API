
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Update
{
    public class UpdateInsurerCommandHandler : IRequestHandler<UpdateInsurerCommand, bool>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateInsurerCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddUpdateInsuranceCompany(request);
        }
    }
}
