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

        public async Task<List<Tag>> Get()
        {
            return await context.tagTable
            .AsNoTracking()
            .OrderBy(t => t.nameTag)
            .ToListAsync();
        }

        public async Task<Tag?> GetById(long id)
        {
            return await context.tagTable
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task<List<Tag>> GetByTitle(string title)
        {
            return await context.tagTable
            .AsNoTracking()
            .Where(t => t.nameTag.Contains(title))
            .ToListAsync();
        }

        public async Task Add(Tag tag)
        {
            await context.tagTable.AddAsync(tag);
            await context.SaveChangesAsync();
        }

        public async Task Update(Tag tag)
        {
            context.Update(tag);
            await context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await context.tagTable
                .Where(t => t.id == id)
                .ExecuteDeleteAsync();
        }
    }
}