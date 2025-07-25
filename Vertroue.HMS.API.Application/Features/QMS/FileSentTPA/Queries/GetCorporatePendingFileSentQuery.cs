using MediatR;

namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries
{
    public class GetCorporatePendingFileSentQuery : IRequest<GetCorporatePendingFileSentResponse>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
