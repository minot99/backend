using Microsoft.Identity.Client;
using SimuladorExitoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.DTO
{
    public class CareerDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string slug { get; set; } = string.Empty;
        public int facultyId { get; set; }
        public virtual FacultyDTO? faculty { get; set; }

        public CareerDTO()
        {
            
        }

        public CareerDTO(Career career)
        {
            id = career.Id;
            name = career.Name;
            description = career.Description;
            slug = career.Slug;
            facultyId = career.FacultyId;
            faculty = career.Faculty is not null ? new FacultyDTO(career.Faculty) : null;
        }
    }
}
