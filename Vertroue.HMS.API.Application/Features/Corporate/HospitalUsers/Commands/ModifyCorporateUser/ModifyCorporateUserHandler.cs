using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    internal class ModifyCorporateUserHandler : IRequestHandler<ModifyCorporateUserCommand, string>
    {
        private readonly ICorporateRepository _repo;
        private readonly ILoggedInUserService _loggedInUserService;

        public ModifyCorporateUserHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repo = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<string> Handle(ModifyCorporateUserCommand request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repo.ModifyCorporateUserAsync(request);
        }
    }
}
