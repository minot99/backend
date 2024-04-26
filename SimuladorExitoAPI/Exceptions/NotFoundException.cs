using System.Net;

namespace SimuladorExitoAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public int statusCode = StatusCodes.Status404NotFound;
        public IDictionary<string, object> data { get; set; } = new Dictionary<string, object>();
        public NotFoundException(object id) : base($"No se encuentra la entidad con id = {id}")
        {
            data.Add("message", base.Message);
            data.Add("data", new { id });
        }

        public NotFoundException(string message) : base(message)
        {
            data.Add("message", message);
            data.Add("data", new object());
        }
    }
}
