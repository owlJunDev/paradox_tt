using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;

using Backend.Repositories;
using Backend.DTO;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/note")]
    public class NoteController : ODataController
    {
        private readonly NoteRepository noteRepository;

        public NoteController(NoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Note> Get()
        {
            return noteRepository.GetAll();
        }


        [HttpGet("{id}")]
        [EnableQuery]
        public Note Get(long id)
        {
            return noteRepository.GetById(id);
        }

        [HttpPost]
        [EnableQuery]
        public IActionResult Post([FromBody] NoteDto noteDto)
        {
            System.Console.WriteLine("put request start");
            var note = new Note();
            note.title = noteDto.title;
            note.content = noteDto.content;
            note.dateCreate = DateTime.UtcNow;
            
            System.Console.WriteLine("put go repos");

            noteRepository.Add(note, noteDto.tagId);
            return RedirectToAction("Get");
        }

        [HttpPut("{id}")]
        [EnableQuery]
        public void Put(long id, [FromBody] NoteDto noteDto) {
            var note = Get(id);
            note.title = noteDto.title;
            note.content = noteDto.content;
            noteRepository.Update(note, noteDto.tagId);
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public void Delete(long id) => noteRepository.Delete(id);
    }
}