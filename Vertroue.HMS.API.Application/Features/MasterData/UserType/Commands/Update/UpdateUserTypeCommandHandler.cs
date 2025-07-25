using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Update
{
    public class UpdateUserTypeCommandHandler : IRequestHandler<UpdateUserTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateUserTypeCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateUserTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserTypeAsync(request, 'U');
        }
    }
}
