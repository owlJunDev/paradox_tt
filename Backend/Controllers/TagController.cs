using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

using Backend.DTO;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/tag")]
    public class TagController : ODataController
    {
        private readonly TagRepository tagRepository;

        public TagController(TagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<List<Tag>> Get()
        {
            return await tagRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Tag> Get(long id)
        {
            return await tagRepository.GetById(id);
        }

        [HttpPost]
        public async Task Post(TagDto tagDto)
        {
            var tag = new Tag();
            tag.nameTag = tagDto.nameTag;
            System.Console.WriteLine($"!==============={tagDto.nameTag}");

            await tagRepository.Add(tag);
        }

        [HttpPut("{id}/put")]
        public async Task Put(TagDto tagDto, long id)
        {
            var tag = await tagRepository.GetById(id);
            if (tag != null)
            {
                tag.nameTag = tagDto.nameTag;
                await tagRepository.Update(tag);
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task Delete(long id)
        {
            var tag = await tagRepository.GetById(id);
            if (tag != null)
                await tagRepository.Delete(id);
        }
    }
}