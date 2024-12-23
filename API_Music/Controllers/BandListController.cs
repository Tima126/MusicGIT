using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandListController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public BandListController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BandList> bands = Context.BandLists.ToList();
            return Ok(bands);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BandList? band = Context.BandLists.FirstOrDefault(x => x.Id == id);
            if (band == null)
            {
                return NotFound("Not Found");
            }
            return Ok(band);
        }

        [HttpPost]
        public IActionResult Add(BandListCreate bandListCreate)
        {
            var band = bandListCreate.Adapt<BandList>();

            Context.BandLists.Add(band);
            Context.SaveChanges();
            return Ok(band);
        }

        [HttpPut]
        public IActionResult Update(BandListCreate bandListCreate)
        {
            var band = Context.BandLists.FirstOrDefault(b => b.Id == bandListCreate.Id);
            if (band == null)
            {
                return NotFound("Not Found");
            }

            bandListCreate.Adapt(band);
            Context.BandLists.Update(band);
            Context.SaveChanges();
            return Ok(band);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BandList? band = Context.BandLists.FirstOrDefault(x => x.Id == id);
            if (band == null)
            {
                return NotFound("Not Found");
            }
            Context.BandLists.Remove(band);
            Context.SaveChanges();
            return Ok(band);
        }
    }
}