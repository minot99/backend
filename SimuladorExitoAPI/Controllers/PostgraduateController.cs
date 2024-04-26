using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimuladorExitoAPI.DTO;
using SimuladorExitoAPI.Exceptions;
using SimuladorExitoAPI.Models;

namespace SimuladorExitoAPI.Controllers
{
    [Route("api/postgraduates")]
    [ApiController]
    public class PostgraduateController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<PostgraduateDTO> GetPostgraduates()
        {
            using (var context = new SimuladorDbContext())
            {
                var postgraduates = context.Postgraduates.ToList();
                return postgraduates.Select(p => new PostgraduateDTO(p)).ToList();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public PostgraduateDTO GetPostgraduate(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var postgraduate = context.Postgraduates.Find(id) ?? throw new NotFoundException(id);
                return new PostgraduateDTO(postgraduate);
            }
        }

        [HttpPost]
        [Route("")]
        public PostgraduateDTO PostPostgraduate(PostgraduateDTO postgraduateDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                Postgraduate postgraduate = new()
                {
                    Name = postgraduateDTO.name,
                    PostLevel = Enum.Parse<PostLevels>(postgraduateDTO.postLevel),
                    CareerId = postgraduateDTO.careerId
                };
                context.Postgraduates.Add(postgraduate);
                context.SaveChanges();
                return new PostgraduateDTO(postgraduate);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public PostgraduateDTO PutPostgraduate(int id, PostgraduateDTO postgraduateDTO)
        {
            using (var context = new SimuladorDbContext())
            {
                var postgraduate = context.Postgraduates.Find(id) ?? throw new NotFoundException(id);
                postgraduate.Name = postgraduateDTO.name;
                postgraduate.PostLevel = Enum.Parse<PostLevels>(postgraduateDTO.postLevel);
                postgraduate.CareerId = postgraduateDTO.careerId;
                context.SaveChanges();
                return new PostgraduateDTO(postgraduate);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeletePostgraduate(int id)
        {
            using (var context = new SimuladorDbContext())
            {
                var postgraduate = context.Postgraduates.Find(id) ?? throw new NotFoundException(id);
                context.Postgraduates.Remove(postgraduate);
                context.SaveChanges();
            }
        }
    }
}
