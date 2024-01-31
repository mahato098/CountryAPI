namespace CountryDropDownAPI.DTO
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set;} = string.Empty;
        //public string FullName { get { return string.Format("0", "1", FirstName, LastName);} }
        public DateTime JoinDate { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        //public CountryDto? Countries { get; set; }
    }

}
