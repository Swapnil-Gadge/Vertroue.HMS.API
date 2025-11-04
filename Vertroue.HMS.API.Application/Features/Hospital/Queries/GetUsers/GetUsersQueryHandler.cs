using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetUsersQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to create user for this hospital.");

            var result = await _hospitalRepository.GetHospitalUsers(request.HospitalId, request.UserId);
            var users = result.Select(u => new UserDto
            {
                UserId = u.UserId,
                UserLoginId = u.UserLoginId,                
                Name = u.Name,
                Email = u.Email,
                ContactNumber = u.ContactNumber,
                UserRoleId = u.UserRoleId,
                UserRole = u.UserRole?.Name,
                IsActive = u.IsActive,
                HospitalId = u.HospitalId,
                CreatedBy = u.CreatedBy,
                CreatedDate = u.CreatedDate,
                LastUpdatedBy = u.LastUpdatedBy,
                LastUpdatedDate = u.LastUpdatedDate
            }).ToList();
            return users;
        }
    }
}
