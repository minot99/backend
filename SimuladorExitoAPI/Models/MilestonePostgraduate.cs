namespace SimuladorExitoAPI.Models
{
    public class MilestonePostgraduate
    {
        public int MilestoneId { get; set; }
        public int PostgraduateId { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual Postgraduate Postgraduate { get; set; }
    }
}
