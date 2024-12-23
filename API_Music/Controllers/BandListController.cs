using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            BandList? band = Context.BandLists.Where(x => x.Id == id).FirstOrDefault();
            if (band == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(band);
        }

        [HttpPost]
        public IActionResult Add(BandList band)
        {
            Context.BandLists.Add(band);
            Context.SaveChanges();
            return Ok(band);
        }

        [HttpPut]
        public IActionResult Update(BandList band)
        {
            Context.BandLists.Update(band);
            Context.SaveChanges();
            return Ok(band);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BandList? band = Context.BandLists.Where(x => x.Id == id).FirstOrDefault();
            if (band == null)
            {
                return BadRequest("Not Found");
            }
            Context.BandLists.Remove(band);
            Context.SaveChanges();
            return Ok(band);
        }
    }
}
