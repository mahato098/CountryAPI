namespace CountryDropDownAPI.DTO
{
    public class CountryListDto
    {
        public string CountryName { get; set; } = string.Empty;
        public List<StateDto>? States { get; set; }
      
    }
}
