using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries
{
    public class GetCorporatePendingFileSentQueryHandler : IRequestHandler<GetCorporatePendingFileSentQuery, GetCorporatePendingFileSentResponse>
    {
        private readonly IQMSDataRepository _repository;

        public GetCorporatePendingFileSentQueryHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCorporatePendingFileSentResponse> Handle(GetCorporatePendingFileSentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchCorporatePendingFileSentAsync(request.CorporateId, request.UserId, request.UserType, request.UserRole);
        }
    }
}
