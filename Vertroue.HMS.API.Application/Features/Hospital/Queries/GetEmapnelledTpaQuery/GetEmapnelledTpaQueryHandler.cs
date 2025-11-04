using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetEmapnelledTpaQuery
{
    public class GetEmapnelledTpaQueryHandler : IRequestHandler<GetEmapnelledTpaQuery, List<EmpanelledTpaDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetEmapnelledTpaQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<EmpanelledTpaDto>> Handle(GetEmapnelledTpaQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            var result = await _hospitalRepository.GetEmpanelledTpas(request.HospitalId, request.EmpanelledTpaId);
            var empanelledTpas = new List<EmpanelledTpaDto>();
            foreach (var item in result)
            {
                empanelledTpas.Add(new EmpanelledTpaDto
                {
                    EmpanelledTpaId = item.EmpanelledTpaId,
                    TpaId = item.Tpaid,
                    TpaName = item?.Tpa.Name ?? string.Empty,
                    UserName = item.UserName,
                    PassWord = item.PassWord,
                    HospitalId = item.HospitalId,
                    Portal = item.Portal,
                    EmpanelledDate = item.EmpanelledDate,
                    IsActive = item.IsActive,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    LastUpdatedBy = item.LastUpdatedBy,
                    LastUpdatedDate = item.LastUpdatedDate
                });
            }
            return empanelledTpas;
        }
    }
}
