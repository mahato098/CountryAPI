using CountryDropDownAPI.Models;

namespace CountryDropDownAPI.DTO
{
    public class UpdatePersonDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
    }
}
