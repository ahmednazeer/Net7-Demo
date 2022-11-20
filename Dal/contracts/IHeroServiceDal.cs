using Net7Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.contracts
{
    public interface IHeroServiceDal
    {
        Task<SuperHero> AddHero(SuperHero modle);
        Task<List<SuperHero>> GetHeros();
        Task<SuperHero?> GetHero(int id);
        Task<SuperHero?> DeleteHero(int id);
        Task<SuperHero?> UpdateteHero(int id,SuperHero superHero);
    }
}
