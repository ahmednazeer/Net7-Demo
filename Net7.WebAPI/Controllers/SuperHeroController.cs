using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net7Demo.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var superHerolsLst = new List<SuperHero> { 
                new SuperHero 
                { 
                    Id = 1, 
                    Name = "Spider man", 
                    FirstName = "Peter", 
                    LastName = "Parker", 
                    Place = "New york" 
                } 
            };
            return Ok(superHerolsLst);
        }

    }
}
