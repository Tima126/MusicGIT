using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
                return NotFound("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(UserCreate userCreate)
        {
            var user = userCreate.Adapt<User>();
            user.Regdate = DateTime.Now;

            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(UserCreate userCreate)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == userCreate.Id);
            if (user == null)
            {
                return NotFound("Not Found");
            }

            userCreate.Adapt(user);
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}