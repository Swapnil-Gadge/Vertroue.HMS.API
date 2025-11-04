using MediatR;
using Microsoft.AspNetCore.Identity;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Users.Commands.Register;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public CreateUserCommandHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to create user for this hospital.");

            var passwordHasher = new PasswordHasher<UserHashed>();
            var user = new UserHashed
            {
                UserName = request.UserLoginId,
            };
            request.Password = passwordHasher.HashPassword(user, request.Password);

            return await _hospitalRepository.AddUpdateHospitalUser(request);
        }
    }
}
