using DartsApp.RestAPI.DAL;
using DartsApp.RestAPI.Entities;
using DartsApp.RestAPI.Repositories.Interfaces;

namespace DartsApp.RestAPI.Repositories.Infrastructure
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
