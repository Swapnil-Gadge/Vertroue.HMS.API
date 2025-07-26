using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Update
{
    public class UpdateQMSCaseCommandHandler : IRequestHandler<UpdateQMSCaseCommand, string>
    {
        private readonly IQMSDataRepository _repository;

        public UpdateQMSCaseCommandHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(UpdateQMSCaseCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateQMSCaseDetailsAsync(request);
        }
    }
}
