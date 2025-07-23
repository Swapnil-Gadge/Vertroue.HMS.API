using MediatR;

using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    internal class ModifyCorporateUserHandler : IRequestHandler<ModifyCorporateUserCommand, string>
    {
        private readonly ICorporateRepository _repo;

        public ModifyCorporateUserHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(ModifyCorporateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repo.ModifyCorporateUserAsync(request);
        }
    }
}
