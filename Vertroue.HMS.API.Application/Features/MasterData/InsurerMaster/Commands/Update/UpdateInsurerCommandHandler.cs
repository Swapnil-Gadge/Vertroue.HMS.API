
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Commands.Update
{
    public class UpdateInsurerCommandHandler : IRequestHandler<UpdateInsurerCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateInsurerCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateInsurerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageInsurerAsync(request, 'U');
        }
    }
}
