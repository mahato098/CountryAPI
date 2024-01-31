namespace CountryDropDownAPI.DTO
{
    public class DistrictCityOnlyDto
    {
        public string DistrictName { get; set; } = string.Empty;
        public List<CityDto>? Cities { get; set; }
        //public List<DistrictCityDto>? DCityDto { get; set; }
    }
}
