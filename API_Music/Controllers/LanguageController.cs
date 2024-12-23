using API_Music.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public LanguageController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Language> languages = Context.Languages.ToList();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Language? language = Context.Languages.Where(x => x.Id == id).FirstOrDefault();
            if (language == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(language);
        }

        [HttpPost]
        public IActionResult Add(Language language)
        {
            Context.Languages.Add(language);
            Context.SaveChanges();
            return Ok(language);
        }

        [HttpPut]
        public IActionResult Update(Language language)
        {
            Context.Languages.Update(language);
            Context.SaveChanges();
            return Ok(language);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Language? language = Context.Languages.Where(x => x.Id == id).FirstOrDefault();
            if (language == null)
            {
                return BadRequest("Not Found");
            }
            Context.Languages.Remove(language);
            Context.SaveChanges();
            return Ok(language);
        }
    }
}
