using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Commands.Add
{
    public class AddGenderCommandHandler : IRequestHandler<AddGenderCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddGenderCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddGenderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageGenderAsync(request, 'I');
        }
    }
}