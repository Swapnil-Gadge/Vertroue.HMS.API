using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.DeactivateCorporateTPACommand
{
    public class DeactivateCorporateTPAHandler : IRequestHandler<DeactivateCorporateTPACommand, string>
    {
        private readonly ICorporateRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public DeactivateCorporateTPAHandler(ICorporateRepository repository, ILoggedInUserService loggedInUserService)
        {
            _repository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<string> Handle(DeactivateCorporateTPACommand request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repository.DeactivateCorporateTPAAsync(request);
        }
    }
}
