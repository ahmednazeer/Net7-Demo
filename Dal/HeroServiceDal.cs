using Dal.contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Net7Demo.Models;

namespace Dal
{
    public class HeroServiceDal : IHeroServiceDal
    {
        private readonly SuperHeroContext _context;

        public HeroServiceDal(SuperHeroContext context)
        {
            _context = context;
        }
        public async Task<SuperHero> AddHero(SuperHero modle)
        {
            _context.SuperHeroes.Add(modle);
            await _context.SaveChangesAsync();
            return modle;
        }

        public async Task<SuperHero?> DeleteHero(int id)
        {
            var hero=_context.SuperHeroes.FirstOrDefault(her=>her.Id==id);
            if (hero is null) {
                return null;
            }
             _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            return await _context.SuperHeroes.FirstOrDefaultAsync(her => her.Id == id);
            
        }

        public async Task<List<SuperHero>> GetHeros()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> UpdateteHero(int id, SuperHero superHero)
        {
            var hero= await _context.SuperHeroes.FirstOrDefaultAsync(her => her.Id == id);
            if (hero is null)
                return null;
            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;
            await _context.SaveChangesAsync();
            return hero;
        }
    }
}