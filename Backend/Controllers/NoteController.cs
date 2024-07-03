using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

using Backend.Repositories;
using Backend.DTO;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ODataController
    {
        private readonly NoteRepository noteRepository;

        public NoteController(NoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Note>>> Get()
        {
            System.Console.WriteLine("GET all");
            var result = await noteRepository.GetAll();
            return result == null ? NotFound() : Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> Get(long id)
        {
            System.Console.WriteLine("GET one");
            var result = await noteRepository.GetById(id);
            return result == null ? NoContent() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NoteDto noteDto)
        {
            var note = new Note();
            try
            {
                note.title = noteDto.title;
                note.content = noteDto.content;
                note.createAt = DateTime.UtcNow;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Data.ToString());
                return NotFound();
            }

            await noteRepository.Add(note, noteDto.tagId);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] NoteDto noteDto)
        {
            var note = await noteRepository.GetById(id);
            if (note != null)
            {
                note.title = noteDto.title;
                note.content = noteDto.content;
                await noteRepository.Update(note, noteDto.tagId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id) => await noteRepository.Delete(id);
    }
}