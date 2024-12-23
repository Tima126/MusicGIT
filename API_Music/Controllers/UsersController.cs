using API_Music.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public UsersController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
