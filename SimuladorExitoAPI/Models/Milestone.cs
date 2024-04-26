using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.Models
{
    public class Milestone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Description { get; set; } = string.Empty;
        [StringLength(5)]
        public string Cycle { get; set; } = string.Empty;
        public int ElapsedYears { get; set; }
        public int Year { get; set; }
        [Precision(5,2)]
        public decimal Time { get; set; }
        [StringLength(150)]
        public string Context { get; set; } = string.Empty;
        public int CareerId { get; set; }

        public virtual Career Career { get; set; }

        public virtual ICollection<Position> Positions { get; set; }

        public virtual ICollection<Postgraduate> Postgraduates { get; set; } 
    }
}
