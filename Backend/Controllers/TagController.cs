using Microsoft.AspNetCore.Mvc;

using Backend.DTO;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/tag")]
    public class TagController : ControllerBase
    {
        private readonly TagRepository tagRepository;

        public TagController(TagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return tagRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Tag Get(long id)
        {
            return tagRepository.GetById(id);
        }

        [HttpPost]
        public void Post(TagDto tagDto)
        {
            var tag = new Tag();
            tag.nameTag = tagDto.nameTag;

            tagRepository.Add(tag);
        }

        [HttpPut("{id}/put")]
        public void Put(TagDto tagDto, long id)
        {
            var tag = tagRepository.GetById(id);
            if (tag != null)
            {
                tag.nameTag = tagDto.nameTag;

                tagRepository.Update(tag);
            }
        }

        [HttpDelete("{id}/delete")]
        public void Delete(long id)
        {
            var tag = tagRepository.GetById(id);
            if (tag != null)
                tagRepository.Delete(tag);
        }
    }
}