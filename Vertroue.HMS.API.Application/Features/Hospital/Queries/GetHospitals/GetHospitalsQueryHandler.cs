using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitals
{
    public class GetHospitalsQueryHandler : IRequestHandler<GetHospitalsQuery, List<HospitalDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetHospitalsQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<HospitalDto>> Handle(GetHospitalsQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.UserRole != Constant.UserRoles.ProviderAdmin)
                throw new UnauthorizedAccessException("Only Provider Admin users can access this resource.");

            var hospitals = await _hospitalRepository.ListAllAsync();
            return hospitals.Select(h => new HospitalDto
            {
                Address = h.Address,
                Email = h.Email,
                ContactNumber = h.ContactNumber,
                HospitalId = h.HospitalId,
                IsActive = h.IsActive,
                Name = h.Name,
                StateName = h.State != null ? h.State.Name : string.Empty,
                CityName = h.City != null ? h.City.Name : string.Empty,
                WebSite = h.WebSite,
                CityId = h.CityId,
                StateId = h.StateId,
                CreatedDate = h.CreatedDate,
                CreatedBy = h.CreatedBy,
                LastUpdatedBy = h.LastUpdatedBy,
                LastUpdatedDate = h.LastUpdatedDate
            }).ToList();
        }
    }
}
