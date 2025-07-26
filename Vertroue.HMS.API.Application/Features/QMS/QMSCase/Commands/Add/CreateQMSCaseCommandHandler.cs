using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Add
{
    public class CreateQMSCaseCommandHandler : IRequestHandler<CreateQMSCaseCommand, string>
    {
        private readonly IQMSDataRepository _repository;

        public CreateQMSCaseCommandHandler(IQMSDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateQMSCaseCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateQMSCaseAsync(request);
        }
    }
}
