using MediatR;

using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser
{
    internal class DeactivateCorporateUserHandler : IRequestHandler<DeactivateCorporateUserCommand, string>
    {
        private readonly ICorporateRepository _repo;

        public DeactivateCorporateUserHandler(ICorporateRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(DeactivateCorporateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeactivateCorporateUserAsync(request);
        }
    }
}
