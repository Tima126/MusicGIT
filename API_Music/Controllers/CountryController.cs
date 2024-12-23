using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        public BandList_dbContext Context { get; }

        public CountryController(BandList_dbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Country> countries = Context.Countries.ToList();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Country? country = Context.Countries.Where(x => x.Id == id).FirstOrDefault();
            if (country == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult Add(Country country)
        {
            Context.Countries.Add(country);
            Context.SaveChanges();
            return Ok(country);
        }

        [HttpPut]
        public IActionResult Update(Country country)
        {
            Context.Countries.Update(country);
            Context.SaveChanges();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Country? country = Context.Countries.Where(x => x.Id == id).FirstOrDefault();
            if (country == null)
            {
                return BadRequest("Not Found");
            }
            Context.Countries.Remove(country);
            Context.SaveChanges();
            return Ok(country);
        }
    }
}
