using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimuladorExitoAPI.Models
{
    public class MilestonePosition
    {
        public int MilestoneId { get; set; }
        public int PositionId { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual Position Position { get; set; }
    }
}
