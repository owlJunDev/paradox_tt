using Backend.Models;
using Microsoft.AspNetCore.Mvc;

using Backend.Repositories;
using Backend.DTO;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/note")]
    public class NoteController : ControllerBase
    {
        private readonly NoteRepository noteRepository;

        public NoteController(NoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet()]
        public IEnumerable<Note> GetAll([FromQuery]FilterDto? filterDto)
        {
            return noteRepository.GetAll(filterDto);
        }


        [HttpGet("{id}")]
        public Note GetById(int id)
        {
            return noteRepository.GetById(id);
        }

        [HttpPost(Name = "PostNote")]
        public IActionResult Post(NoteDto noteDto)
        {
            var note = new Note();

            note.title = noteDto.title;
            note.content = noteDto.content;
            note.dateCreate = DateTime.UtcNow;

            noteRepository.Add(note, noteDto.tagId);
            return RedirectToAction("GetAll");
        }

        [HttpPut("{id}")]
        public void Put() { }

        [HttpDelete("{id}")]
        public void Delete() { }
    }
}