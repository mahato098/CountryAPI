namespace CountryDropDownAPI.DTO
{
    public class StateDistrictDto
    {
        public string StateName { get; set; } = string.Empty;
        public List<DistrictDto>? Districts { get; set; }
        //public List<DistrictCityOnlyDto>? DistrictCity { get; set; }
    }
}
