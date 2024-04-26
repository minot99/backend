using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorExitoAPI.DTO;
using SimuladorExitoAPI.Exceptions;
using SimuladorExitoAPI.Models;

namespace SimuladorExitoAPI.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<PositionDTO> GetPositions()
        {
            using (var context = new SimuladorDbContext())
            {
                var positions = context.Positions.ToList();
                return positions.Select(p => new PositionDTO(p)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public PositionDTO GetPosition(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var position = context.Positions.Find(id) ?? throw new NotFoundException(id);
                return new PositionDTO(position);
            }
        }

        [HttpPost]
        [Route("")]
        public PositionDTO PostPosition(PositionDTO positionDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                Position position = new()
                {
                    Name = positionDTO.name,
                    Description = positionDTO.description,
                    EstimatedRemuneration = positionDTO.estimatedRemuneration,
                    InfoSource = positionDTO.infoSource,
                    PossibleWorkplaces = positionDTO.possibleWorkplaces,
                    Sector = Enum.Parse<Sectors>(positionDTO.sector),
                    CarrerId = positionDTO.carrerId
                };
                context.Positions.Add(position);
                context.SaveChanges();
                return new PositionDTO(position);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public PositionDTO PutPosition(int id, PositionDTO positionDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var position = context.Positions.Find(id) ?? throw new NotFoundException(id);
                position.Name = positionDTO.name;
                position.Description = positionDTO.description;
                position.EstimatedRemuneration = positionDTO.estimatedRemuneration;
                position.InfoSource = positionDTO.infoSource;
                position.PossibleWorkplaces = positionDTO.possibleWorkplaces;
                position.Sector = Enum.Parse<Sectors>(positionDTO.sector);
                position.CarrerId = positionDTO.carrerId;
                context.SaveChanges();
                return new PositionDTO(position);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeletePosition(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var position = context.Positions.Find(id) ?? throw new NotFoundException(id);
                context.Positions.Remove(position);
                context.SaveChanges();
            }
        }
    }
}
