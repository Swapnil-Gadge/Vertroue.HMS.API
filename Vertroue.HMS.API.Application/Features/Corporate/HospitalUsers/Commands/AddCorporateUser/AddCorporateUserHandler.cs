using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser
{
    public class AddCorporateUserHandler : IRequestHandler<AddCorporateUserCommand, string>
    {
        private readonly ICorporateRepository _repo;
        private readonly ILoggedInUserService _loggedInUserService;

        public AddCorporateUserHandler(ICorporateRepository repo, ILoggedInUserService loggedInUserService)
        {
            _repo = repo;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<string> Handle(AddCorporateUserCommand request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repo.AddCorporateUserAsync(request);
        }
    }
}
