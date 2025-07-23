using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser
{
    public class AddCorporateUserHandler : IRequestHandler<AddCorporateUserCommand, string>
    {
        private readonly ICorporateRepository _repo;

        public AddCorporateUserHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(AddCorporateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repo.AddCorporateUserAsync(request);
        }
    }
}
