using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

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
        public void Post([FromBody] NoteDto noteDto)
        {
            var note = new Note();
            note.title = noteDto.title;
            note.content = noteDto.content;
            note.dateCreate = DateTime.UtcNow;
            
            noteRepository.Add(note, noteDto.tagId);
        }

        [HttpPut("{id}")]
        [EnableQuery]
        public void Put(long id, [FromBody] NoteDto noteDto) {
            var note = noteRepository.GetById(id);
            note.title = noteDto.title;
            note.content = noteDto.content;
            noteRepository.Update(note, noteDto.tagId);
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public void Delete(long id) => noteRepository.Delete(id);
    }
}