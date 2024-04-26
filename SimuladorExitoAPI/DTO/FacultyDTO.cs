using SimuladorExitoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.DTO
{
    public class FacultyDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;

        public FacultyDTO()
        {
                
        }

        public FacultyDTO(Faculty faculty)
        {
            id = faculty.Id;
            name = faculty.Name;
        }
    }
}
