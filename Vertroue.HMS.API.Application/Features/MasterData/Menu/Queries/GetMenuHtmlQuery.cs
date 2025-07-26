using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.Menu.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.Menu.Queries
{
    public class GetMenuHtmlQuery : IRequest<List<MenuHtmlDto>>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
