using System.ComponentModel.DataAnnotations;

namespace CountryDropDownAPI.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int DistrictId { get; set; }
    }
}
