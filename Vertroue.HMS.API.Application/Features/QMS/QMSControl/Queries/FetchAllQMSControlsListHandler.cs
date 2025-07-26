using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries
{
    public class FetchAllQMSControlsListHandler : IRequestHandler<FetchAllQMSControlsListQuery, FetchAllQMSControlsListResponse>
    {
        private readonly IQMSDataRepository _repository;

        public FetchAllQMSControlsListHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<FetchAllQMSControlsListResponse> Handle(FetchAllQMSControlsListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FetchAllQMSControlsListAsync(request.UserId, request.UserType, request.UserRole, request.CorporateId);
        }
    }
}
