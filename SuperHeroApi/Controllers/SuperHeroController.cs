using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //{
        //    new SuperHero
        //    {
        //        Id = 1,
        //        Name = "Spider Man",
        //        FirstName = "Peter",
        //        LastName = "Parker",
        //        Place = "New York City"
        //    },
        //    new SuperHero
        //    {
        //        Id = 2,
        //        Name = "Iron Man",
        //        FirstName = "Tony",
        //        LastName = "Stark",
        //        Place = "Malibu"
        //    }
        //};

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return await _superHeroService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHeroById(int id)
        {
            var result = await _superHeroService.GetHeroById(id);
            if (result == null) 
                return NotFound("Superhero not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            var result = await _superHeroService.AddHero(newHero);
            return Ok(result);
        }

       [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(request);
            if (result == null)
                return NotFound("Hero not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result == null)
                return NotFound("Hero not found");

            return Ok(result);
        }
    }
}
