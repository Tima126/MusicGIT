using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

namespace API_Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public UserFavoriteController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserFavorite> userFavorites = Context.UserFavorites.ToList();
            return Ok(userFavorites);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserFavorite? userFavorite = Context.UserFavorites.FirstOrDefault(x => x.Id == id);
            if (userFavorite == null)
            {
                return NotFound("Not Found");
            }
            return Ok(userFavorite);
        }

        [HttpPost]
        public IActionResult Add(UserFavoriteCreate userFavoriteCreate)
        {
            var userFavorite = userFavoriteCreate.Adapt<UserFavorite>();

            Context.UserFavorites.Add(userFavorite);
            Context.SaveChanges();
            return Ok(userFavorite);
        }

        [HttpPut]
        public IActionResult Update(UserFavoriteCreate userFavoriteCreate)
        {
            var userFavorite = Context.UserFavorites.FirstOrDefault(u => u.Id == userFavoriteCreate.Id);
            if (userFavorite == null)
            {
                return NotFound("Not Found");
            }

            userFavoriteCreate.Adapt(userFavorite);
            Context.UserFavorites.Update(userFavorite);
            Context.SaveChanges();
            return Ok(userFavorite);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserFavorite? userFavorite = Context.UserFavorites.FirstOrDefault(x => x.Id == id);
            if (userFavorite == null)
            {
                return NotFound("Not Found");
            }
            Context.UserFavorites.Remove(userFavorite);
            Context.SaveChanges();
            return Ok(userFavorite);
        }
    }
}