using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Update
{
    public class UpdateStatusMasterCommandHandler : IRequestHandler<UpdateStatusMasterCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateStatusMasterCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateStatusMasterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageStatusMasterAsync(request, 'U');
        }
    }
}
