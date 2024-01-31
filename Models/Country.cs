using System.ComponentModel.DataAnnotations;

namespace CountryDropDownAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public virtual ICollection<State>? States { get; set; }
    }
}
