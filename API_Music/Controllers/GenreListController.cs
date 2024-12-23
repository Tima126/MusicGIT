using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreListController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public GenreListController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GenreList> genres = Context.GenreLists.ToList();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GenreList? genre = Context.GenreLists.FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                return NotFound("Not Found");
            }
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Add(GenreCreate genreCreate)
        {
            var genre = genreCreate.Adapt<GenreList>();

            Context.GenreLists.Add(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        [HttpPut]
        public IActionResult Update(GenreCreate genreCreate)
        {
            var genre = Context.GenreLists.FirstOrDefault(g => g.Id == genreCreate.Id);
            if (genre == null)
            {
                return NotFound("Not Found");
            }

            genreCreate.Adapt(genre);
            Context.GenreLists.Update(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GenreList? genre = Context.GenreLists.FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                return NotFound("Not Found");
            }
            Context.GenreLists.Remove(genre);
            Context.SaveChanges();
            return Ok(genre);
        }
    }
}