using System.ComponentModel.DataAnnotations;

namespace CountryDropDownAPI.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
        public int DistrictId { get; set; }
        public District? District { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
