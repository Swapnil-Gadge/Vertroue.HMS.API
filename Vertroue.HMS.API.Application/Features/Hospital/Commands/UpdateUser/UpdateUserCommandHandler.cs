using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public UpdateUserCommandHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to create user for this hospital.");

            return await _hospitalRepository.AddUpdateHospitalUser(request);
        }
    }
}
