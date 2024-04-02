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

        [HttpGet(Name = "GetTag")]
        public IEnumerable<Tag> GetAll()
        {
            return tagRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Tag GetById(long id)
        {
            return tagRepository.GetById(id);
        }

        [HttpPost(Name = "PostTag")]
        public IActionResult Post(TagDto tagDto)
        {
            var tag = new Tag();
            tag.nameTag = tagDto.nameTag;

            tagRepository.Add(tag);
            return RedirectToAction("GetAll");
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
            System.Console.WriteLine($"--- -- {tag} -- ---");
            if (tag != null)
                tagRepository.Delete(tag);
        }
    }
}