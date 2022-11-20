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
        
        private readonly ISuperHeroCoreService _superHeroCoreService;
        public SuperHeroController(ISuperHeroCoreService superHeroCoreService)
        {
            _superHeroCoreService = superHeroCoreService;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var allHerosResult =await _superHeroCoreService.GetAllHeros();
            return Ok(allHerosResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero=await _superHeroCoreService.GetHero(id);
            if(hero is null)
                return NotFound(ErrorMessages.NotFoundHero);
            return Ok(hero);
        }
        [HttpPost]

        public async Task<ActionResult<SuperHero>> AddSuperHerro([FromBody] SuperHero hero)
        {
            var heroResult=await _superHeroCoreService.AddSuperHerro(hero);
            return Created(string.Empty,hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id,SuperHero superHero)
        {
            var hero =await _superHeroCoreService.UpdateHero(id,superHero);
            if (hero is null)
                return NotFound(ErrorMessages.NotFoundHero);

            return Ok(hero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero =await _superHeroCoreService.DeleteHero(id);
            if (hero is null)
                return NotFound(ErrorMessages.FailedToDeleteHero);

            return Ok(hero);
        }
    }
}
