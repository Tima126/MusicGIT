using API_Music.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseListController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public ReleaseListController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReleaseList> releases = Context.ReleaseLists.ToList();
            return Ok(releases);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReleaseList? release = Context.ReleaseLists.Where(x => x.Id == id).FirstOrDefault();
            if (release == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(release);
        }

        [HttpPost]
        public IActionResult Add(ReleaseList release)
        {
            Context.ReleaseLists.Add(release);
            Context.SaveChanges();
            return Ok(release);
        }

        [HttpPut]
        public IActionResult Update(ReleaseList release)
        {
            Context.ReleaseLists.Update(release);
            Context.SaveChanges();
            return Ok(release);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReleaseList? release = Context.ReleaseLists.Where(x => x.Id == id).FirstOrDefault();
            if (release == null)
            {
                return BadRequest("Not Found");
            }
            Context.ReleaseLists.Remove(release);
            Context.SaveChanges();
            return Ok(release);
        }
    }
}
