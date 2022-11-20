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
        Task<List<SuperHero>> GetAllHeros();
        Task<SuperHero?> GetHero(int id);
        Task<SuperHero?> AddSuperHerro(SuperHero hero);
        Task<SuperHero?> UpdateHero(int id, SuperHero superHero);
        Task<SuperHero?> DeleteHero(int id);
    }
}
