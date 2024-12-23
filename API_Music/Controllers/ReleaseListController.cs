using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            ReleaseList? release = Context.ReleaseLists.FirstOrDefault(x => x.Id == id);
            if (release == null)
            {
                return NotFound("Not Found");
            }
            return Ok(release);
        }

        [HttpPost]
        public IActionResult Add(ReleaseListCreate releaseListCreate)
        {
            var release = releaseListCreate.Adapt<ReleaseList>();

            Context.ReleaseLists.Add(release);
            Context.SaveChanges();
            return Ok(release);
        }

        [HttpPut]
        public IActionResult Update(ReleaseListCreate releaseListCreate)
        {
            var release = Context.ReleaseLists.FirstOrDefault(r => r.Id == releaseListCreate.Id);
            if (release == null)
            {
                return NotFound("Not Found");
            }

            releaseListCreate.Adapt(release);
            Context.ReleaseLists.Update(release);
            Context.SaveChanges();
            return Ok(release);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReleaseList? release = Context.ReleaseLists.FirstOrDefault(x => x.Id == id);
            if (release == null)
            {
                return NotFound("Not Found");
            }
            Context.ReleaseLists.Remove(release);
            Context.SaveChanges();
            return Ok(release);
        }
    }
}