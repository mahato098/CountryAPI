using CountryDropDownAPI.Models;

namespace CountryDropDownAPI.DTO
{
    public class CountryStateDto
    {
        public string CountryName { get; set; } = string.Empty;
        public List<StateDto>? States { get; set; }
        //public List<StateDistrictDto>? stateDistrictDtos { get; set; }
    }
}
