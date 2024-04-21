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
        public async Task<Note> Get(long id)
        {
            return await noteRepository.GetById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] NoteDto noteDto)
        {
            var note = new Note();
            note.title = noteDto.title;
            note.content = noteDto.content;
            note.dateCreate = DateTime.UtcNow;
            
            await noteRepository.Add(note, noteDto.tagId);
        }
        
        [HttpPut("{id}")]
        public async Task Put(long id, [FromBody] NoteDto noteDto) {
            var note = await noteRepository.GetById(id);
            note.title = noteDto.title;
            note.content = noteDto.content;
            await noteRepository.Update(note, noteDto.tagId);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id) => await noteRepository.Delete(id);
    }
}