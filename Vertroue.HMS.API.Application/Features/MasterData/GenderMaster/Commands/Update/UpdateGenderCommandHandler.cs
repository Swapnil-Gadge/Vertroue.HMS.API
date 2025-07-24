using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Update
{
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateGenderCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageGenderAsync(request, 'U');
        }
    }
}