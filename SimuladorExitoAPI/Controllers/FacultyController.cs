using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladorExitoAPI.DTO;
using SimuladorExitoAPI.Exceptions;
using SimuladorExitoAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace SimuladorExitoAPI.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    public class FacultyController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public List<FacultyDTO> GetFaculties()
        {
            using (SimuladorDbContext context = new())
            {
                var faculties = context.Faculties.ToList();
                return faculties.Select(faculty => new FacultyDTO(faculty)).ToList();
            }
        }
        [HttpGet]
        [Route("{id}")]
        public FacultyDTO GetFaculty(int id)
        {
            using (SimuladorDbContext context = new())
            {
                var faculty = context.Faculties.Find(id) ?? throw new NotFoundException(id);
                return new FacultyDTO(faculty);
            }
        }

        [HttpPost]
        [Route("")]
        public FacultyDTO PostFaculty(FacultyDTO facultyDTO)
        {
            using (SimuladorDbContext context = new())
            {
                Faculty faculty = new()
                {
                    Name = facultyDTO.name
                };
                context.Faculties.Add(faculty);
                context.SaveChanges();
                return new FacultyDTO(faculty);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public FacultyDTO PutFaculty(int id, FacultyDTO facultyDTO)
        {
            using (SimuladorDbContext context = new())
            {
                var faculty = context.Faculties.Find(id) ?? throw new NotFoundException(id);
                faculty.Name = facultyDTO.name;
                context.SaveChanges();
                return new FacultyDTO(faculty);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteFaculty(int id, FacultyDTO facultyDTO)
        {
            using (SimuladorDbContext context = new())
            {
                var faculty = context.Faculties.Find(id) ?? throw new NotFoundException(id);
                context.Remove(faculty);
                context.SaveChanges();
            }
        }
        [HttpGet]
        [Route("{id}/careers")]
        public List<CareerDTO> GetFacultyCareers(int id)
        {
            using (SimuladorDbContext context = new())
            {
                var faculty = context.Faculties.Find(id) ?? throw new NotFoundException(id);
                return faculty.Careers.Select(c => new CareerDTO(c)).ToList();
            }
        }
    }
}
