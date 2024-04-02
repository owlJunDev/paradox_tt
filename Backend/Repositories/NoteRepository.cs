using System.Collections.Concurrent;
using System.Collections.Generic;

using Backend.Contexts;
using Backend.Models;
using Backend.DTO;

namespace Backend.Repositories
{
    public class NoteRepository
    {
        private readonly AppDbContext context;

        public NoteRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Note note, List<long> tagsId)
        {
            context.noteTable.Add(note);
            context.SaveChanges();
            System.Console.WriteLine($"note id:{note.id}");
            foreach (var tagId in tagsId)
            {
                if (context.tagTable.Find(tagId) != null)
                {
                    System.Console.WriteLine($"tag id:{tagId}");
                    var noteTags = new NoteTag();
                    noteTags.noteId = note.id;
                    noteTags.tagId = tagId;
                    context.noteTagTable.Add(noteTags);
                }
            }
            context.SaveChanges();
        }

        public void Update(Note note)
        {
            context.noteTable.Update(note);
            context.SaveChanges();
        }

        public void Delete(Note note)
        {
            var noteTags = context.noteTagTable.Where(nt => nt.noteId == note.id).ToList();
            foreach (var noteTag in noteTags)
            {
                context.noteTagTable.Remove(noteTag);
            }
            context.noteTable.Remove(note);
            context.SaveChanges();
        }

        public IEnumerable<Note> GetAll(FilterDto? filterDto)
        {
            IQueryable<Note> result = context.noteTable;
            if (filterDto == null)
                return result.ToList();

            System.Console.WriteLine("filter start");
            if (filterDto.date != null)
                result = result.Where(n => n.dateCreate.ToString("dd.mm.yyyy") == filterDto.date.ToUniversalTime().ToString("dd.mm.yyyy"));
            
            if (filterDto.content != null)
                result = result.Where(n => n.content.ToLower().Contains(filterDto.content.ToLower()));
            
            if (filterDto.title != null)
                result = result.Where(n => n.title.ToLower().Contains(filterDto.title.ToLower()));
            System.Console.WriteLine("filter end");

            return result.ToList();
        }

        public Note GetById(long id)
        {
            return context.noteTable.FirstOrDefault(n => n.id == id);
        }
    }
}