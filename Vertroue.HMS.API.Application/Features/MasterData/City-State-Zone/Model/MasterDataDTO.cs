namespace Vertroue.HMS.API.Application.Features.MasterData.Models
{
    public class StateDto
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
    public class ZoneDto
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
    }
}
