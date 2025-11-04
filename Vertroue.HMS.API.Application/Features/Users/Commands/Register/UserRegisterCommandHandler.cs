using MediatR;
using Microsoft.AspNetCore.Identity;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Responses;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Register
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, BaseResponse>
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public UserRegisterCommandHandler(IUserMasterRepository userMasterRepository, ILoggedInUserService loggedInUserService)
        {
            _userMasterRepository = userMasterRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<BaseResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_loggedInUserService.UserRole != Constant.UserRoles.ProviderAdmin)
                    throw new UnauthorizedAccessException("Only PROVIDER ADMIN can create new users.");

                var passwordHasher = new PasswordHasher<UserHashed>();
                var user = new UserHashed
                {
                    UserName = request.UserName,
                };

                var userMaster = await _userMasterRepository.GetUserDetails(request.UserName);

                if (userMaster == null)
                    throw new ArgumentNullException(nameof(userMaster));

                userMaster.Password = passwordHasher.HashPassword(user, request.Password);
                _userMasterRepository.UpdateUser(userMaster);
                
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
