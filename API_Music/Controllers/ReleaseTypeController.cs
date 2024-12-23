using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReleaseTypeController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public ReleaseTypeController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ReleaseType> releaseTypes = Context.ReleaseTypes.ToList();
            return Ok(releaseTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ReleaseType? releaseType = Context.ReleaseTypes.Where(x => x.Id == id).FirstOrDefault();
            if (releaseType == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(releaseType);
        }

        [HttpPost]
        public IActionResult Add(ReleaseType releaseType)
        {
            Context.ReleaseTypes.Add(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }

        [HttpPut]
        public IActionResult Update(ReleaseType releaseType)
        {
            Context.ReleaseTypes.Update(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReleaseType? releaseType = Context.ReleaseTypes.Where(x => x.Id == id).FirstOrDefault();
            if (releaseType == null)
            {
                return BadRequest("Not Found");
            }
            Context.ReleaseTypes.Remove(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }
    }
}
