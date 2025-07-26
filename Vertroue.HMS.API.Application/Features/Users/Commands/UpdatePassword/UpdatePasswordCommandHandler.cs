using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        private readonly IUserMasterRepository _repository;

        public UpdatePasswordCommandHandler(IUserMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdatePasswordAsync(request.UserId, request.OldPassword, request.NewPassword);
        }
    }
}
