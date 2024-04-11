using System.Collections.Concurrent;
using System.Collections.Generic;

using Backend.Contexts;
using Backend.Models;
using Backend.DTO;
using Microsoft.EntityFrameworkCore;

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

            if (tagsId != null)
            {
                foreach (var tag in context.tagTable.Where(t => tagsId.Contains(t.id)))
                {
                    System.Console.WriteLine($"tag id: {tag.id}, name: {tag.nameTag}");
                    note.tags.Add(tag);
                    tag.notes.Add(note);
                    context.tagTable.Update(tag);
                }
            }
            context.noteTable.Update(note);
            context.SaveChanges();
        }

        public void Update(Note note, List<long> tagsId)
        {
            context.noteTable.Include(n => n.tags).FirstOrDefault(n => n.id == note.id).tags.Clear();

            foreach (var tag in context.tagTable.Where(t => tagsId.Contains(t.id)))
            {
                note.tags.Add(tag);
                tag.notes.Add(note);
                context.tagTable.Update(tag);
            }

            context.noteTable.Update(note);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.noteTable.Remove(GetById(id));
            context.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            return context.noteTable.Include(n => n.tags).ToList();
        }

        public Note GetById(long id)
        {
            return context.noteTable.FirstOrDefault(n => n.id == id);
        }
    }
}