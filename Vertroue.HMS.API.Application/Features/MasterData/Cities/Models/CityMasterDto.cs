namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;

public class CityMasterDto
{
    public int CityId { get; set; }
    public string? CityName { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public string? ActiveFlag { get; set; }
    public string? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }
}
