using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            BandMember? member = Context.BandMembers.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                return NotFound("Not Found");
            }
            return Ok(member);
        }

        [HttpPost]
        public IActionResult Add(BandMemberCreate bandMemberCreate)
        {
            var bandMember = bandMemberCreate.Adapt<BandMember>();

            Context.BandMembers.Add(bandMember);
            Context.SaveChanges();
            return Ok(bandMember);
        }

        [HttpPut]
        public IActionResult Update(BandMemberCreate bandMemberCreate)
        {
            var bandMember = Context.BandMembers.FirstOrDefault(b => b.Id == bandMemberCreate.Id);
            if (bandMember == null)
            {
                return NotFound("Not Found");
            }

            bandMemberCreate.Adapt(bandMember);
            Context.BandMembers.Update(bandMember);
            Context.SaveChanges();
            return Ok(bandMember);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BandMember? member = Context.BandMembers.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                return NotFound("Not Found");
            }
            Context.BandMembers.Remove(member);
            Context.SaveChanges();
            return Ok(member);
        }
    }
}