using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Commands.Add
{
    public class AddAdmissionTypeHandler : IRequestHandler<AddAdmissionTypeCommand, string>
    {
        private readonly IMasterDataRepository _repository;

        public AddAdmissionTypeHandler(IMasterDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddAdmissionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ManageAdmissionTypeAsync(request, 'I');
        }
    }
}