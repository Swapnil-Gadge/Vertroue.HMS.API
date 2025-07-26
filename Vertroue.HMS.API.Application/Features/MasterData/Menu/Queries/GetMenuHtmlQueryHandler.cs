using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.Menu.Model;
using Vertroue.HMS.API.Application.Features.Reports.Queries;

namespace Vertroue.HMS.API.Application.Features.MasterData.Menu.Queries
{
    public class GetMenuHtmlQueryHandler : IRequestHandler<GetMenuHtmlQuery, List<MenuHtmlDto>>
    {
        private readonly IMasterDataRepository _repo;

        public GetMenuHtmlQueryHandler(IMasterDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MenuHtmlDto>> Handle(GetMenuHtmlQuery request, CancellationToken cancellationToken)
        {
            return await _repo.FetchMenuHtmlAsync(request);
        }
    }
}
