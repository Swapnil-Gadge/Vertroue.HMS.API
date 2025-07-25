using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;

public class GetTpaMasterQuery : IRequest<List<TpaMasterDto>> { }
