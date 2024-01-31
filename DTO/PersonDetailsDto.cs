using CountryDropDownAPI.Models;

namespace CountryDropDownAPI.DTO
{
    public class PersonDetailsDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public Country? Country { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public State? State { get; set; }
        public string StateName { get; set; } = string.Empty;
        public District? District { get; set; }
        public string DistrictName { get; set; } = string.Empty;
        public City? City { get; set; }
        public string CityName { get; set; } = string.Empty;
       
    }
}
