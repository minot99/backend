using SimuladorExitoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.DTO
{
    public class PostgraduateDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string postLevel { get; set; } = string.Empty;
        public int careerId { get; set; }
        public CareerDTO? career { get; set; }

        public PostgraduateDTO()
        {
            
        }

        public PostgraduateDTO(Postgraduate postgraduate)
        {
            id = postgraduate.Id;
            name = postgraduate.Name;
            postLevel = postgraduate.PostLevel.ToString();
            careerId = postgraduate.CareerId;
            career = postgraduate.Career is not null ? new CareerDTO(postgraduate.Career) : null;
        }
    }
}
