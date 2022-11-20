using Core;
using Core.contracts;
using Heplers;
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
        private readonly ISuperHeroCoreService _superHeroCoreService;
        public SuperHeroController(ISuperHeroCoreService superHeroCoreService)
        {
            _superHeroCoreService = superHeroCoreService;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var allHerosResult = _superHeroCoreService.GetAllHeros();
            return Ok(allHerosResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero= _superHeroCoreService.GetHero(id);
            if(hero is null)
                return NotFound(ErrorMessages.NotFoundHero);
            return Ok(superHerolsLst);
        }
        [HttpPost]

        public async Task<ActionResult<SuperHero>> AddSuperHerro([FromBody] SuperHero hero)
        {
            var heroResult= _superHeroCoreService.AddSuperHerro(hero);
            return Created(string.Empty,hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id,SuperHero superHero)
        {
            var hero = _superHeroCoreService.UpdateHero(id,superHero);
            if (hero is null)
                return NotFound(ErrorMessages.NotFoundHero);

            return Ok(superHerolsLst);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero = _superHeroCoreService.DeleteHero(id);
            if (hero is null)
                return NotFound(ErrorMessages.FailedToDeleteHero);

            return Ok(hero);
        }
    }
}
