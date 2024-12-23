using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            SongList? song = Context.SongLists.FirstOrDefault(x => x.Id == id);
            if (song == null)
            {
                return NotFound("Not Found");
            }
            return Ok(song);
        }

        [HttpPost]
        public IActionResult Add(SongListCreate songListCreate)
        {
            var song = songListCreate.Adapt<SongList>();

            Context.SongLists.Add(song);
            Context.SaveChanges();
            return Ok(song);
        }

        [HttpPut]
        public IActionResult Update(SongListCreate songListCreate)
        {
            var song = Context.SongLists.FirstOrDefault(s => s.Id == songListCreate.Id);
            if (song == null)
            {
                return NotFound("Not Found");
            }

            songListCreate.Adapt(song);
            Context.SongLists.Update(song);
            Context.SaveChanges();
            return Ok(song);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SongList? song = Context.SongLists.FirstOrDefault(x => x.Id == id);
            if (song == null)
            {
                return NotFound("Not Found");
            }
            Context.SongLists.Remove(song);
            Context.SaveChanges();
            return Ok(song);
        }
    }
}