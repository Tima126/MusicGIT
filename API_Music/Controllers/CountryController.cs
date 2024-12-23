using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Music.Contacts;
using Mapster;

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
            Country? country = Context.Countries.FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                return NotFound("Not Found");
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult Add(CountryCreate countryCreate)
        {
            var country = countryCreate.Adapt<Country>();

            Context.Countries.Add(country);
            Context.SaveChanges();
            return Ok(country);
        }

        [HttpPut]
        public IActionResult Update(CountryCreate countryCreate)
        {
            var country = Context.Countries.FirstOrDefault(c => c.Id == countryCreate.Id);
            if (country == null)
            {
                return NotFound("Not Found");
            }

            countryCreate.Adapt(country);
            Context.Countries.Update(country);
            Context.SaveChanges();
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Country? country = Context.Countries.FirstOrDefault(x => x.Id == id);
            if (country == null)
            {
                return NotFound("Not Found");
            }
            Context.Countries.Remove(country);
            Context.SaveChanges();
            return Ok(country);
        }
    }
}