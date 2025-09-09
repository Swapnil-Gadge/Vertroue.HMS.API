using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.Renewal.Commands
{
    public class AddCorporateRenewalHandler : IRequestHandler<AddCorporateRenewalCommand, string>
    {
        private readonly ICorporateRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public AddCorporateRenewalHandler(ICorporateRepository repository, ILoggedInUserService loggedInUserService)
        {
            _repository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<string> Handle(AddCorporateRenewalCommand request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repository.AddCorporateRenewalAsync(request);
        }
    }
}
