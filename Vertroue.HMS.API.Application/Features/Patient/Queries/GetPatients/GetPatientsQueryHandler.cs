using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Patient;

namespace Vertroue.HMS.API.Application.Features.Patient.Queries.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, List<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetPatientsQueryHandler(IPatientRepository patientRepository,
            ILoggedInUserService loggedInUserService,
            IMapper mapper)
        {
            _patientRepository = patientRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException();

            var patients = await _patientRepository.GetPatientsByHospitalIdAsync(request.HospitalId);
            var patientList = new List<PatientDto>();
            foreach (var patient in patients)
            {
                var patientDto = new PatientDto
                {
                    PatientId = patient.PatientId,
                    PatientName = patient.PatientName,
                    ClaimStatus = patient.ClaimStatus,
                    HospitalId = patient.HospitalId,
                    InsuranceCompanyName = patient.InsuranceCompany != null ? patient.InsuranceCompany.Name : string.Empty,
                    TpaName = patient.Tpa != null ? patient.Tpa.Name : string.Empty,
                    AdmissionDate = patient.AdmissionDate,
                    PolicyNumber = patient.PolicyNumber,
                    ContactNumber = patient.ContactNumber,
                    RelativeContactNumber = patient.RelativeContactNumber,
                    InsuredCardNumber = patient.InsuredCardNumber,
                    DateOfBirth = patient.DateOfBirth,
                    AgeYears = patient.AgeYears.HasValue ? patient.AgeYears.Value.ToString() : string.Empty,
                    AgeMonths = patient.AgeMonths.HasValue ? patient.AgeMonths.Value.ToString() : string.Empty,
                    TpaClaimId = patient.TpaclaimId,
                    Gender = patient.Gender,
                    CreatedBy = patient.CreatedBy,
                    CreatedDate = patient.CreatedDate,
                    LastUpdatedBy = patient.LastUpdatedBy,
                    LastUpdatedDate = patient.LastUpdatedDate
                };
                patientList.Add(patientDto);
            }
            return patientList;
        }
    }
}
