namespace CountryDropDownAPI.DTO
{
    public class DistrictCityDto
    {
        public string DistrictName { get; set; } = string.Empty;
        public List<CityDto>? Cities { get; set; }
    }
}
