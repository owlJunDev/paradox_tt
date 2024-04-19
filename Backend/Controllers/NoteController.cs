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
        public async Task<List<Note>> Get()
        {
            return await noteRepository.Get();
        }


        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<Note> Get(long id)
        {
            return await noteRepository.GetById(id);
        }

        [HttpPost]
        [EnableQuery]
        public void Post([FromBody] NoteDto noteDto)
        {
            var note = new Note();
            note.title = noteDto.title;
            note.content = noteDto.content;
            note.dateCreate = DateTime.UtcNow;
            
            noteRepository.Add(note);
        }
        
        [HttpPut("{id}")]
        [EnableQuery]
        public async void Put(long id, [FromBody] NoteDto noteDto) {
            var note = await noteRepository.GetById(id);
            note.title = noteDto.title;
            note.content = noteDto.content;
            await noteRepository.Update();
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public void Delete(long id) => noteRepository.Delete(id);
    }
}