using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Backend.Contexts;
using Backend.Models;

namespace Backend.Repositories
{
    public class TagRepository
    {
        private readonly AppDbContext context;

        public TagRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Tag tag)
        {
            context.tagTable.Add(tag);
            context.SaveChanges();
        }

        public void Delete(Tag tag)
        {
            var notes = context.noteTable.Include(n => n.tags).Where(n => n.tags.Contains(tag)).ToList();
            foreach (var note in notes)
            {
                note.tags.Remove(tag);       
                context.noteTable.Update(note);
            }
            context.tagTable.Remove(tag);
            context.SaveChanges();
        }

        public void Update(Tag tag)
        {
            context.tagTable.Update(tag);
            context.SaveChanges();
        }
        public IEnumerable<Tag> GetAll()
        {
            return context.tagTable.ToList();
        }

        public Tag GetById(long id)
        {
            return context.tagTable.Find(id);
        }
    }
}