using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            Language? language = Context.Languages.FirstOrDefault(x => x.Id == id);
            if (language == null)
            {
                return NotFound("Not Found");
            }
            return Ok(language);
        }

        [HttpPost]
        public IActionResult Add(LanguageCreate languageCreate)
        {
            var language = languageCreate.Adapt<Language>();

            Context.Languages.Add(language);
            Context.SaveChanges();
            return Ok(language);
        }

        [HttpPut]
        public IActionResult Update(LanguageCreate languageCreate)
        {
            var language = Context.Languages.FirstOrDefault(l => l.Id == languageCreate.Id);
            if (language == null)
            {
                return NotFound("Not Found");
            }

            languageCreate.Adapt(language);
            Context.Languages.Update(language);
            Context.SaveChanges();
            return Ok(language);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Language? language = Context.Languages.FirstOrDefault(x => x.Id == id);
            if (language == null)
            {
                return NotFound("Not Found");
            }
            Context.Languages.Remove(language);
            Context.SaveChanges();
            return Ok(language);
        }
    }
}