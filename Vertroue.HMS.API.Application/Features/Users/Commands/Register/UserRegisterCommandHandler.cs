using MediatR;
using Microsoft.AspNetCore.Identity;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Responses;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Register
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, BaseResponse>
    {
        private readonly IUserMasterRepository _userMasterRepository;
        public UserRegisterCommandHandler(IUserMasterRepository userMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
        }

        public async Task<BaseResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var passwordHasher = new PasswordHasher<UserHashed>();
                var user = new UserHashed
                {
                    UserName = request.UserName,
                };

                var userMaster = await _userMasterRepository.GetUserDetails(request.UserName);

                if (userMaster == null)
                    throw new ArgumentNullException(nameof(userMaster));

                userMaster.UserPassword = passwordHasher.HashPassword(user, request.Password);
                _userMasterRepository.UpdateAsync(userMaster);
                
                return new BaseResponse
                {
                    Message = "User registration in successful!!!",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    Success = false
                };
            }            
        }
    }
}
