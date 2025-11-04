using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetDoctorsQuery
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, List<DoctorDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetDoctorsQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            var result = await _hospitalRepository.GetDoctors(request.HospitalId, request.DoctorId);
            var doctors = new List<DoctorDto>();
            result.ForEach(d =>
            {
                var doctor = new DoctorDto
                {
                    DoctorId = d.DoctorId,
                    HospitalId = d.HospitalId,
                    DoctorName = d.DoctorName,
                    ContactNumber = d.ContactNumber,
                    Qualification = d.Qualification,
                    RegistrationNumber = d.RegistrationNumber,
                    IsVisitingDoctor = d.IsVisitingDoctor,
                    IsActive = d.IsActive,
                    CreatedBy = d.CreatedBy,
                    CreatedDate = d.CreatedDate,
                    LastUpdatedBy = d.LastUpdatedBy,
                    LastUpdatedDate = d.LastUpdatedDate
                };
                doctors.Add(doctor);
            });
            return doctors;
        }
    }
}
