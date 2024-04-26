using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimuladorExitoAPI.Models
{
    public class Career
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [StringLength(150)]
        public string Slug { get; set; } = string.Empty;
        
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Postgraduate> Postgraduates { get; set; }

        public virtual ICollection<Position> Positions { get; set; }

        public virtual ICollection<Milestone> Milestones { get; set; }
    }
}
