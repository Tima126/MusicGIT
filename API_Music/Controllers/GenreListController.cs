using API_Music.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            GenreList? genre = Context.GenreLists.Where(x => x.Id == id).FirstOrDefault();
            if (genre == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Add(GenreList genre)
        {
            Context.GenreLists.Add(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        [HttpPut]
        public IActionResult Update(GenreList genre)
        {
            Context.GenreLists.Update(genre);
            Context.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GenreList? genre = Context.GenreLists.Where(x => x.Id == id).FirstOrDefault();
            if (genre == null)
            {
                return BadRequest("Not Found");
            }
            Context.GenreLists.Remove(genre);
            Context.SaveChanges();
            return Ok(genre);
        }
    }
}
