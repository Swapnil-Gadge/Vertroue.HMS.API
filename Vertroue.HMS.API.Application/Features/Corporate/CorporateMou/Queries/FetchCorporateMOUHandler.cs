using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Queries
{
   public class FetchCorporateMOUHandler : IRequestHandler<FetchCorporateMOUQuery, List<CorporateMouDto>>
    {
        private readonly ICorporateRepository _repository;

        public FetchCorporateMOUHandler(ICorporateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CorporateMouDto>> Handle(FetchCorporateMOUQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporateMOUAsync(               
                request.CorporateId,
                request.UserId,
                request.UserType,
                request.UserRole);
        }
    }
}
