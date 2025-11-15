using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitalData
{
    public class GetHospitalDataQueryHandler : IRequestHandler<GetHospitalDataQuery, GetHospitalDataResponse>
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetHospitalDataQueryHandler(IMasterDataRepository masterDataRepository, 
            IMapper mapper, 
            ILoggedInUserService loggedInUserService)
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<GetHospitalDataResponse> Handle(GetHospitalDataQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("User is not authorized to perform this operation.");

            var treatments = await _masterDataRepository.FetchTreatments();
            var packages = await _masterDataRepository.FetPackagesForHospital(request.HospitalId);
            return new GetHospitalDataResponse
            {
                Treatments = _mapper.Map<List<TreatmentDto>>(treatments),
                Packages = _mapper.Map<List<PackageDto>>(packages)
            };        
        }
    }
}
