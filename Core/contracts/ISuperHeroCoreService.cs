using Net7Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.contracts
{
    public interface ISuperHeroCoreService
    {
        List<SuperHero> GetAllHeros();
        SuperHero GetHero(int id);
        SuperHero AddSuperHerro(SuperHero hero);
        SuperHero UpdateHero(int id, SuperHero superHero);
        SuperHero DeleteHero(int id);
    }
}
