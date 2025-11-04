using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospital
{
    public class GetHospitalQueryHandler : IRequestHandler<GetHospitalQuery, HospitalDto>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetHospitalQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<HospitalDto> Handle(GetHospitalQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.HospitalId != request.HospitalId 
                && _loggedInUserService.UserRole != Constant.UserRoles.ProviderAdmin)
                throw new UnauthorizedAccessException("You are not authorized to access this resource.");

            var hospital = await _hospitalRepository.GetHospitalDetailsByIdAsync(request.HospitalId);
            return new HospitalDto
            {
                Address = hospital.Address,
                Email = hospital.Email,
                ContactNumber = hospital.ContactNumber,
                HospitalId = hospital.HospitalId,
                IsActive = hospital.IsActive,
                Name = hospital.Name,
                StateName = hospital.State != null ? hospital.State.Name : string.Empty,
                CityName = hospital.City != null ? hospital.City.Name : string.Empty,
                WebSite = hospital.WebSite,
                CityId = hospital.CityId,
                StateId = hospital.StateId,
                CreatedBy = hospital.CreatedBy,
                CreatedDate = hospital.CreatedDate,
                LastUpdatedBy = hospital.LastUpdatedBy,
                LastUpdatedDate = hospital.LastUpdatedDate
            };
        }
    }
}
