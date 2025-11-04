using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmpanelledInsuranceCompanyQuery
{
    public class GetEmpanelledInsuranceCompanyQueryHandler : IRequestHandler<GetEmpanelledInsuranceCompanyQuery, List<EmpanelledInsuranceCompanyDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetEmpanelledInsuranceCompanyQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<EmpanelledInsuranceCompanyDto>> Handle(GetEmpanelledInsuranceCompanyQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            var resul = await _hospitalRepository.GetEmpanelledInsuranceCompanies(request.HospitalId, request.EmpanelledInsuranceCompanyId);
            var empanelledInsuranceCompanyDtos = new List<EmpanelledInsuranceCompanyDto>();
            foreach (var item in resul)
            {
                empanelledInsuranceCompanyDtos.Add(new EmpanelledInsuranceCompanyDto
                {
                    EmpanelledInsCompId = item.EmpanelledInsCompId,
                    HospitalId = item.HospitalId,
                    InsuranceCompanyId = item.InsuranceCompanyId,
                    InsuranceCompanyName = item.InsuranceCompany?.Name ?? string.Empty,
                    Portal = item.Portal,
                    UserName = item.UserName,
                    PassWord = item.PassWord,
                    IsActive = item.IsActive,
                    EmpanelledDate = item.EmpanelledDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    LastUpdatedBy = item.LastUpdatedBy,
                    LastUpdatedDate = item.LastUpdatedDate
                });
            }

            return empanelledInsuranceCompanyDtos;
        }
    }
}
