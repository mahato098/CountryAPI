using System.ComponentModel.DataAnnotations;

namespace CountryDropDownAPI.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; } = string.Empty;
        public int StateId { get; set; }
        public State? State { get; set; }
        public virtual ICollection<City>? Cities { get; set; } 
    }
}
