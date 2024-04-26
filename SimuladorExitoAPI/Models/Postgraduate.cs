using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.Models
{
    public class Postgraduate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public PostLevels PostLevel { get; set; }
        public int CareerId { get; set; }

        public virtual Career Career { get; set; }

    }
}
