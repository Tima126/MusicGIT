using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongListController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public SongListController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<SongList> songs = Context.SongLists.ToList();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SongList? song = Context.SongLists.Where(x => x.Id == id).FirstOrDefault();
            if (song == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(song);
        }

        [HttpPost]
        public IActionResult Add(SongList song)
        {
            Context.SongLists.Add(song);
            Context.SaveChanges();
            return Ok(song);
        }

        [HttpPut]
        public IActionResult Update(SongList song)
        {
            Context.SongLists.Update(song);
            Context.SaveChanges();
            return Ok(song);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SongList? song = Context.SongLists.Where(x => x.Id == id).FirstOrDefault();
            if (song == null)
            {
                return BadRequest("Not Found");
            }
            Context.SongLists.Remove(song);
            Context.SaveChanges();
            return Ok(song);
        }
    }
}
