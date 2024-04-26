using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimuladorExitoAPI.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Precision(10,2)]
        public decimal EstimatedRemuneration { get; set; } = 0;
        public Sectors Sector { get; set; } = Sectors.PUBLIC_PRIVATE;
        [StringLength(50)]
        public string InfoSource { get; set; } = string.Empty;
        public string PossibleWorkplaces { get; set; } = string.Empty;
        public int CarrerId { get; set; }

        public virtual Career Carrer { get; set; } = new Career();
    }
}
