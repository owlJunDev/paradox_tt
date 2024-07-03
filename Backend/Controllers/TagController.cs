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
        public async Task<IActionResult> Get()
        {
            var result = await tagRepository.Get();
            return result.Count != 0? Ok(result) : NoContent(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await tagRepository.GetById(id);
            return result != null ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task Post(TagDto tagDto)
        {
            var tag = new Tag();
            tag.nameTag = tagDto.nameTag;
            await tagRepository.Add(tag);
        }

        [HttpPut("{id}")]
        public async Task Put(TagDto tagDto, long id)
        {
            var tag = await tagRepository.GetById(id);
            if (tag != null)
            {
                tag.nameTag = tagDto.nameTag;
                await tagRepository.Update(tag);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            var tag = await tagRepository.GetById(id);
            if (tag != null)
                await tagRepository.Delete(id);
        }
    }
}