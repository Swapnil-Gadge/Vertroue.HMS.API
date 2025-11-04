using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetRenewals
{
    public class GetRenewalsQueryHandler : IRequestHandler<GetRenewalsQuery, List<RenewalDto>>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetRenewalsQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<List<RenewalDto>> Handle(GetRenewalsQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to perform this action.");

            var list = await _hospitalRepository.GetRenewalsForHospital(request.HospitalId, request.RenewalId);
            var renewals = new List<RenewalDto>();
            foreach (var item in list)
            {
                renewals.Add(new RenewalDto
                {
                    RenewalId = item.RenewalId,
                    HospitalId = item.HospitalId,    
                    DocName = item.RenewalDocs.FirstOrDefault()?.DocName,
                    DocUri = item.RenewalDocs.FirstOrDefault()?.DocUri,
                    Title = item.Title,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    LastUpdatedBy = item.LastUpdatedBy,
                    LastUpdatedDate = item.LastUpdatedDate,
                    ExpireDate = item.ExpireDate,
                    RenewalDate = item.RenewalDate,
                    //Documents = item.RenewalDocs?.Select(d => new RenewalDocDto
                    //{
                    //    RenewalDocId = d.RenewalDocId,
                    //    DocName = d.DocName,
                    //    DocUri = d.DocUri
                    //}).ToList()
                });             
            }
            return renewals;
        }
    }
}
