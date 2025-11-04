using MediatR;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<GetContactsResponse>
    {
        public int HospitalId { get; set; }

        public int? EmpanelledInsCompId { get; set; }

        public int? EmpanelledTpaId { get; set; }

        public int? ContactId { get; set;} 
    }
}
