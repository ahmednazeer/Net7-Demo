using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net7Demo.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHerolsLst = new List<SuperHero> {
            new SuperHero
            {
                Id = 1,
                Name = "Spider man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New york"
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return Ok(superHerolsLst);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero= superHerolsLst.Find(x => x.Id == id);
            if(hero is null)
                return NotFound("sorry , we can not find this here");
            return Ok(superHerolsLst);
        }
        [HttpPost]

        public async Task<ActionResult<SuperHero>> AddSuperHerro([FromBody] SuperHero hero)
        {
            superHerolsLst.Add(hero);
            return Created(string.Empty,hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id,SuperHero superHero)
        {
            var hero = superHerolsLst.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("sorry , we can not find this here");

            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;

            return Ok(superHerolsLst);
        }

    }
}
