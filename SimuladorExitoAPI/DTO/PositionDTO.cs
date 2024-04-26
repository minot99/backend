using Microsoft.EntityFrameworkCore;
using SimuladorExitoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimuladorExitoAPI.DTO
{
    public class PositionDTO
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal estimatedRemuneration { get; set; } = 0;
        public string sector { get; set; } = string.Empty;
        public string infoSource { get; set; } = string.Empty;
        public string possibleWorkplaces { get; set; } = string.Empty;
        public int carrerId { get; set; }

        public CareerDTO? carrer { get; set; }

        public PositionDTO()
        {
            
        }

        public PositionDTO(Position position)
        {
            id = position.Id;
            name = position.Name;
            description = position.Description;
            estimatedRemuneration = position.EstimatedRemuneration;
            sector = position.Sector.ToString();
            infoSource = position.InfoSource;
            possibleWorkplaces = position.PossibleWorkplaces;
            carrerId = position.CarrerId;
            carrer = carrerId > 0 ? new CareerDTO(position.Carrer) : null;
        }
    }
}
