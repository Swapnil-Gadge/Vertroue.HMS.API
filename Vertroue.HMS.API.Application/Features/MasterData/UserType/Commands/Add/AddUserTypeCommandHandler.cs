using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.UserType.Commands.Add
{
    public class AddUserTypeCommandHandler : IRequestHandler<AddUserTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddUserTypeCommandHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddUserTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageUserTypeAsync(request, 'I');
        }
    }
}
