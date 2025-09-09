using MediatR;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Queries
{
    public class FetchCorporateMOUQuery : IRequest<List<CorporateMouDto>>
    {
        public int CorporateId { get; set; }
        public int UserLoginId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }

}
