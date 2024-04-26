using Microsoft.EntityFrameworkCore;
using SimuladorExitoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.DTO
{
    public class MilestoneDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string cycle { get; set; } = string.Empty;
        public int elapsedYears { get; set; }
        public int year { get; set; }
        public decimal time { get; set; }
        public string context { get; set; } = string.Empty;
        public int careerId { get; set; }

        public virtual CareerDTO? career { get; set; } = new();

        public List<PositionDTO>? positions { get; set; } = new();

        public List<PostgraduateDTO>? postgraduates { get; set; } = new();

        public MilestoneDTO()
        {
            
        }

        public MilestoneDTO(Milestone milestone)
        {
            id = milestone.Id;
            name = milestone.Name;
            description = milestone.Description;
            cycle = milestone.Cycle;
            elapsedYears = milestone.ElapsedYears;
            year = milestone.Year;
            time = milestone.Time;
            context = milestone.Context;
            careerId = milestone.CareerId;
            career = careerId > 0?new CareerDTO(milestone.Career): null;
            positions = milestone.Positions.Select(p => new PositionDTO(p)).ToList();
            postgraduates = milestone.Postgraduates.Select(p => new PostgraduateDTO(p)).ToList();
        }
    }
}
