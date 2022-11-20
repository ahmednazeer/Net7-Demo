using Core.contracts;
using Dal.contracts;
using Net7Demo.Models;

namespace Core
{
    public class SuperHeroCoreService: ISuperHeroCoreService
    {
        private readonly IHeroServiceDal heroServiceDal;
        public SuperHeroCoreService(IHeroServiceDal heroServiceDal)
        {
            this.heroServiceDal = heroServiceDal;
        }
        
        public async Task<SuperHero> AddSuperHerro(SuperHero hero)
        {
            return await heroServiceDal.AddHero(hero);
        }

        public async Task<List<SuperHero>> GetAllHeros()
        {
            return await heroServiceDal.GetHeros();
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            return await heroServiceDal.GetHero(id);
        }

        public async Task<SuperHero?> DeleteHero(int id)
        {
            return await heroServiceDal.DeleteHero(id);
        }

        public async Task< SuperHero?> UpdateHero(int id, SuperHero superHero)
        {
            return await heroServiceDal.UpdateteHero(id, superHero);
        }
    }
}