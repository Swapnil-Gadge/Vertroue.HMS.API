using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries
{
    public class FetchAllQMSControlsListQuery : IRequest<FetchAllQMSControlsListResponse>
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public int CorporateId { get; set; }
    }
}
