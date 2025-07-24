using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Update
{
    public class UpdateAdmissionTypeHandler : IRequestHandler<UpdateAdmissionTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public UpdateAdmissionTypeHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateAdmissionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageAdmissionTypeAsync(request, 'U');
        }
    }
}