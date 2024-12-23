using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            ReleaseType? releaseType = Context.ReleaseTypes.FirstOrDefault(x => x.Id == id);
            if (releaseType == null)
            {
                return NotFound("Not Found");
            }
            return Ok(releaseType);
        }

        [HttpPost]
        public IActionResult Add(ReleaseTypeCreate releaseTypeCreate)
        {
            var releaseType = releaseTypeCreate.Adapt<ReleaseType>();

            Context.ReleaseTypes.Add(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }

        [HttpPut]
        public IActionResult Update(ReleaseTypeCreate releaseTypeCreate)
        {
            var releaseType = Context.ReleaseTypes.FirstOrDefault(r => r.Id == releaseTypeCreate.Id);
            if (releaseType == null)
            {
                return NotFound("Not Found");
            }

            releaseTypeCreate.Adapt(releaseType);
            Context.ReleaseTypes.Update(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReleaseType? releaseType = Context.ReleaseTypes.FirstOrDefault(x => x.Id == id);
            if (releaseType == null)
            {
                return NotFound("Not Found");
            }
            Context.ReleaseTypes.Remove(releaseType);
            Context.SaveChanges();
            return Ok(releaseType);
        }
    }
}