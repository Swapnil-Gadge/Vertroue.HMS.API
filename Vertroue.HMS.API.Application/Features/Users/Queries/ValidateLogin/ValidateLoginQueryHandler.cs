using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Users.Model;

namespace Vertroue.HMS.API.Application.Features.Users.Queries.ValidateLogin
{
    public class ValidateLoginQueryHandler : IRequestHandler<ValidateLoginQuery, LoginResponseDto>
    {
        private readonly IUserMasterRepository _authRepository;

        public ValidateLoginQueryHandler(IUserMasterRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginResponseDto> Handle(ValidateLoginQuery request, CancellationToken cancellationToken)
        {
            return await _authRepository.ValidateLoginAsync(request.UserId, request.Password, request.UserType);
        }
    }
}
