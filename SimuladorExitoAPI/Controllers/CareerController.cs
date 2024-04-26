using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorExitoAPI.DTO;
using SimuladorExitoAPI.Exceptions;
using SimuladorExitoAPI.Models;
using System.Collections.Immutable;

namespace SimuladorExitoAPI.Controllers
{
    [Route("api/careers")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<CareerDTO> GetCareers()
        {
            using(var context = new SimuladorDbContext())
            {
                var careers = context.Careers.ToList();
                return careers.Select(c => new CareerDTO(c)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public CareerDTO GetCareer(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                return new CareerDTO(career);
            }
        }

        [HttpPost]
        [Route("")]
        public CareerDTO PostCareer(CareerDTO careerDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                Career career = new()
                {
                    Name = careerDTO.name,
                    Description = careerDTO.description,
                    Slug = careerDTO.slug,
                    FacultyId = careerDTO.facultyId
                };
                context.Careers.Add(career);
                context.SaveChanges();
                return new CareerDTO(career);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public CareerDTO PutCareer(int id, CareerDTO careerDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                career.Name = careerDTO.name;
                career.Description = careerDTO.description;
                career.Slug = careerDTO.slug;
                career.FacultyId = careerDTO.facultyId;
                context.SaveChanges();
                return new CareerDTO(career);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCareer(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                context.Careers.Remove(career);
                context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("{id}/postgraduates")]
        public List<PostgraduateDTO> GetCareerPostgraduates(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                var postgraduates = career.Postgraduates.ToList();
                return postgraduates.Select(p => new PostgraduateDTO(p)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}/positions")]
        public List<PositionDTO> GetCareerPositions(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var career = context.Careers.Find(id) ?? throw new NotFoundException(id);
                var positions = career.Positions.ToList();
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
    }
}
