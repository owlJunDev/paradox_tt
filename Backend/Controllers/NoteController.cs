using Backend.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<NoteController> _logger;

        public NoteController(ILogger<NoteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Note> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Note
            {
                id = index,
                dateCreate = DateTime.Now,
                text = "testText"
            })
            .ToArray();
        }
    }
}