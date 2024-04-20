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

        public async Task<List<Note>> Get()
        {
            return await context.noteTable
            .AsNoTracking()
            .OrderBy(n => n.dateCreate)
            .Include(n => n.tags)
            .ToListAsync();
        }

        public async Task<List<Note>> GetByPgae(int page, int pageSize)
        {
            return await context.noteTable
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
        public async Task<Note?> GetById(long id)
        {
            return await context.noteTable
            .AsNoTracking()
            .FirstOrDefaultAsync(n => n.id == id);
        }

        public async Task Add(Note note, List<long>? tId)
        {
            
            await context.noteTable.AddAsync(note);
            note.tags = context.tagTable.Where(t => tId.Contains(t.id)).ToList();
            await context.SaveChangesAsync();
        }

        public async Task Update(Note note, List<long>? tId)
        {
            context.noteTable.Update(note);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await context.noteTable
                .Where(n => n.id == id)
                .ExecuteDeleteAsync();
        }
    }
}