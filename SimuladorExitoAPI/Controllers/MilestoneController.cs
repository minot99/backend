using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorExitoAPI.DTO;
using SimuladorExitoAPI.Exceptions;
using SimuladorExitoAPI.Models;

namespace SimuladorExitoAPI.Controllers
{
    [Route("api/milestones")]
    [ApiController]
    public class MilestoneController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<MilestoneDTO> GetMilestones()
        {
            using (var context = new SimuladorDbContext())
            {
                var milestones = context.Milestones.ToList();
                return milestones.Select(c => new MilestoneDTO(c)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public MilestoneDTO GetMilestone(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                return new MilestoneDTO(milestone);
            }
        }

        [HttpPost]
        [Route("")]
        public MilestoneDTO PostMilestone(MilestoneDTO milestoneDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                Milestone milestone = new()
                {
                    Name = milestoneDTO.name,
                    Description = milestoneDTO.description,
                    ElapsedYears = milestoneDTO.elapsedYears,
                    Cycle = milestoneDTO.cycle,
                    Context = milestoneDTO.context,
                    Year = milestoneDTO.year,
                    Time = milestoneDTO.time,
                    CareerId = milestoneDTO.careerId
                };
                context.Milestones.Add(milestone);
                context.SaveChanges();
                return new MilestoneDTO(milestone);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public MilestoneDTO PutMilestone(int id, MilestoneDTO milestoneDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                milestone.Name = milestoneDTO.name;
                milestone.Description = milestoneDTO.description;
                milestone.ElapsedYears = milestoneDTO.elapsedYears;
                milestone.Cycle = milestoneDTO.cycle;
                milestone.Context = milestoneDTO.context;
                milestone.Year = milestoneDTO.year;
                milestone.Time = milestoneDTO.time;
                milestone.CareerId = milestoneDTO.careerId;
                context.SaveChanges();
                return new MilestoneDTO(milestone);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteMilestone(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                context.Milestones.Remove(milestone);
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("{id}/postgraduates")]
        public List<PostgraduateDTO> GetMilestonesPostgraduates(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                var postgraduates = milestone.Postgraduates.ToList();
                return postgraduates.Select(p => new PostgraduateDTO(p)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}/positions")]
        public List<PositionDTO> GetMilestonePositions(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                var positions = milestone.Positions.ToList();
                return positions.Select(p => new PositionDTO(p)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}/milestones")]
        public List<MilestoneDTO> GetCareerMilestones(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                var milestones = career.Milestones.ToList();
                return milestones.Select(m => new MilestoneDTO(m)).ToList();
            }
        }

        [HttpPut]
        [Route("{id}/positions")]
        public List<PositionDTO> PutMilestonePositions(int id, List<PositionDTO> positionsDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                var newPositions = positionsDTO.Select(p => p.id).ToArray();
                var positions = context.Positions.Where(p => newPositions.Contains(p.Id)).ToList();
                milestone.Positions.Clear();
                milestone.Positions = positions;
                context.SaveChanges();
                return positions.Select(p => new PositionDTO(p)).ToList();
            }
        }

        [HttpPut]
        [Route("{id}/postgraduates")]
        public List<PostgraduateDTO> PutMilestonePostgraduate(int id, List<PostgraduateDTO> postgraduatesDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var milestone = context.Milestones.Find(id) ?? throw new NotFoundException(id);
                var newPostgrauates = postgraduatesDTO.Select(p => p.id).ToArray();
                var postgraduates = context.Postgraduates.Where(p => newPostgrauates.Contains(p.Id)).ToList();
                milestone.Postgraduates.Clear();
                milestone.Postgraduates = postgraduates;
                context.SaveChanges();
                return postgraduates.Select(p => new PostgraduateDTO(p)).ToList();
            }
        }
    }
}
