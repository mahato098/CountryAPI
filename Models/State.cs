using System.ComponentModel.DataAnnotations;

namespace CountryDropDownAPI.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public virtual ICollection<District>? Districts { get; set; }
    }
}
