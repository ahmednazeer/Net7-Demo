using Core.contracts;
using Net7Demo.Models;

namespace Core
{
    public class SuperHeroCoreService: ISuperHeroCoreService
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

        public SuperHero AddSuperHerro(SuperHero hero)
        {
            superHerolsLst.Add(hero);
            return hero;
        }

        public List<SuperHero> GetAllHeros()
        {
            return superHerolsLst;
        }

        public SuperHero GetHero(int id)
        {
            var hero = superHerolsLst.Find(x => x.Id == id);
            return hero;
        }

        public SuperHero DeleteHero(int id)
        {
            var hero = superHerolsLst.Find(x => x.Id == id);
            if( hero is null) return null;
            superHerolsLst.Remove(hero);
            return hero;
        }

        public SuperHero UpdateHero(int id, SuperHero superHero)
        {
            var hero = superHerolsLst.Find(x => x.Id == id);
            if (hero is null)
                return null;

            hero.Name = superHero.Name;
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.Place = superHero.Place;
            return hero;
        }
    }
}