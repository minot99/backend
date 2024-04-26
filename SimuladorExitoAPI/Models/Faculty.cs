using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Career> Careers { get; set; } = new List<Career>();
    }
}
