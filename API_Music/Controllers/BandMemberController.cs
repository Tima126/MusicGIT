using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandMemberController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public BandMemberController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<BandMember> members = Context.BandMembers.ToList();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BandMember? member = Context.BandMembers.Where(x => x.Id == id).FirstOrDefault();
            if (member == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(member);
        }

        [HttpPost]
        public IActionResult Add(BandMember member)
        {
            Context.BandMembers.Add(member);
            Context.SaveChanges();
            return Ok(member);
        }

        [HttpPut]
        public IActionResult Update(BandMember member)
        {
            Context.BandMembers.Update(member);
            Context.SaveChanges();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BandMember? member = Context.BandMembers.Where(x => x.Id == id).FirstOrDefault();
            if (member == null)
            {
                return BadRequest("Not Found");
            }
            Context.BandMembers.Remove(member);
            Context.SaveChanges();
            return Ok(member);
        }
    }
}
