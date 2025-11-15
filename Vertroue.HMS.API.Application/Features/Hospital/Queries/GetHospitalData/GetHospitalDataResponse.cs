using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetHospitalData
{
    public class GetHospitalDataResponse
    {
        public List<TreatmentDto> Treatments { get; set; } = new List<TreatmentDto>();

        public List<PackageDto> Packages { get; set; } = new List<PackageDto>();
    }
}
