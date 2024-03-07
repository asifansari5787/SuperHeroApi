using SuperHeroApi.Models;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAll();
        Task<SuperHero?> GetHeroById(int id);
        Task<List<SuperHero>> AddHero(SuperHero newHero);
        Task<SuperHero?> UpdateHero(SuperHero request);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
