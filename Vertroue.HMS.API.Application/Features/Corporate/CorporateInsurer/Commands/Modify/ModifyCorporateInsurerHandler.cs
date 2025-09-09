using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify
{
    public class ModifyCorporateInsurerHandler : IRequestHandler<ModifyCorporateInsurerCommand, string>
    {
        private readonly ICorporateRepository _repository;
        private readonly ILoggedInUserService _loggedInUserService;

        public ModifyCorporateInsurerHandler(ICorporateRepository repository, ILoggedInUserService loggedInUserService)
        {
            _repository = repository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<string> Handle(ModifyCorporateInsurerCommand request, CancellationToken cancellationToken)
        {
            request.CorporateId = _loggedInUserService.CorporateId;
            request.UserId = _loggedInUserService.UserLoginId;
            request.UserType = _loggedInUserService.UserType;
            request.UserRole = _loggedInUserService.UserRole;
            return await _repository.ModifyCorporateInsurerAsync(request);
        }
    }
}
