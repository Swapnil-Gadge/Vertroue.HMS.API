using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Queries
{
    public class GetTpaDetailsQueryHandler : IRequestHandler<GetTpaDetailsQuery, TpaMasterDto>
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;

        public GetTpaDetailsQueryHandler(IMasterDataRepository masterDataRepository, IMapper mapper)
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
        }

        public async Task<TpaMasterDto> Handle(GetTpaDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TpaMasterDto>(await _masterDataRepository.GetTpaAsync(request.TpaId));
        }
    }
}
