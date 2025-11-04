
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Add
{
    public class AddInsurerCommandHandler : IRequestHandler<AddInsurerCommand, bool>
    {
        private readonly IMasterDataRepository _repository;

        public AddInsurerCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(AddInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddUpdateInsuranceCompany(request);
        }
    }
}
